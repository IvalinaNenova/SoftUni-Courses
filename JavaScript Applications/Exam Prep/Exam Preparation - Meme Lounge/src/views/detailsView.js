import { html } from '../../node_modules/lit-html/lit-html.js';
import { getItem } from '../services/dataService.js';
import {deleteItem} from '../services/dataService.js';



const detailsTemplate = (item, user, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${item.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src="${item.imageUrl}">
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>${item.description}</p>

            <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
            ${user?._id == item._ownerId
            ?html`<a class="button warning" href="/edit/${item._id}">Edit</a>
            <button @click=${onDelete} class="button danger">Delete</button>`
            : null}


        </div>
    </div>
</section>
`

export const detailsView = async (ctx) => {
    let item = await getItem(ctx.params.id);
    const onDelete = async (e) => {
        await deleteItem(ctx.params.id);
        ctx.page.redirect('/catalog')
    }
    ctx.display(detailsTemplate(item, ctx.user, onDelete))
}