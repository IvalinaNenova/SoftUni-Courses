import { html } from '../../node_modules/lit-html/lit-html.js';
import { getItem, deleteItem, totalLikes, userLikes, addLike } from '../services/dataService.js';


async function detailsTemplate(item, user, onDelete, onLike) {
    let countLikes = await totalLikes(item._id);
    let userCountLikes ;
    if (user) {
        userCountLikes = await userLikes(item._id, user._id);
    }

    return html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${item.title}</h3>
        <p class="type">Type: ${item.type}</p>
        <p class="img"><img src="${item.imageUrl}"></p>
        <div class="actions">

            ${user?._id == item._ownerId
            ? html`
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            <a class="button" href="/edit/${item._id}">Edit</a>
            <a class="button" href="#" @click=${onDelete}>Delete</a>`
            : null}


            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            ${user && user._id !== item._ownerId && userCountLikes == 0
            ? html`<a class="button" href="#" @click=${onLike}>Like</a>`
            : null}
            

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${countLikes}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${item.description}</p>
    </div>
</section>
`}

export async function detailsView(ctx) {
    let item = await getItem(ctx.params.id);
    
    async function onLike (e) {
        e.preventDefault();
        await addLike({bookId: item._id})

        ctx.page.redirect(`/details/${item._id}`);
    }

    async function onDelete(e) {
        e.preventDefault();

        await deleteItem(ctx.params.id);
        ctx.page.redirect('/dashboard');
    }
    ctx.render(await detailsTemplate(item, ctx.user, onDelete, onLike));
}