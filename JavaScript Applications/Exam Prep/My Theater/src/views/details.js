import { html } from '../../node_modules/lit-html/lit-html.js';
import { addLike, getItem, getLikes, getUserLikes} from '../services/dataService.js';


//user && user._id == item._ownerId - check if user or guest and owner


const detailsTemplate = (event, user, onLike, userLikes, countLikes) => html`
<section id="detailsPage">
    <div id="detailsBox">
        <div class="detailsInfo">
            <h1>Title: ${event.title}</h1>
            <div>
                <img src="${event.imageUrl}" />
            </div>
        </div>

        <div class="details">
            <h3>Theater Description</h3>
            <p>${event.description}</p>
            <h4>Date: ${event.date}</h4>
            <h4>Author: ${event.author}</h4>
            <div class="buttons">
                ${user?._id == event._ownerId 
                ? html`<a class="btn-delete" href="/delete/${event._id}">Delete</a>
                <a class="btn-edit" href="/edit/${event._id}">Edit</a>`
                : null}
                
                ${user && user?._id !== event._ownerId && userLikes == 0
                ? html`<a class="btn-like" href="javascript:void(0)" @click=${onLike} >Like</a>`
                :null}
                
            </div>
            <p class="likes">Likes: ${countLikes}</p>
        </div>
    </div>
</section>
`

export const detailsView = async (ctx) => {
    let theater = await getItem(ctx.params.id);
    let likes = await getLikes(theater._id);
    let userLikes;
    if (ctx.user) {
        userLikes = await getUserLikes(theater._id, ctx.user._id)
    }

    console.log(userLikes);

    const onLike = async(e) => {
        e.preventDefault();
        await addLike({theaterId: theater._id});
        console.log(userLikes);
        ctx.page.redirect(`/details/${theater._id}`);
        //ctx.display(detailsTemplate(theater, ctx.user, onLike, userLikes, likes));
    }

    ctx.display(detailsTemplate(theater, ctx.user, onLike, userLikes, likes));
}