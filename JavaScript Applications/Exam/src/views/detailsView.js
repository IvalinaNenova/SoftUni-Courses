import { html } from '../../node_modules/lit-html/lit-html.js';
import { addLike } from '../services/dataService.js';

const detailsTemplate = (ctx, onLike) => html`
<section id="details">
    <div id="details-wrapper">
        <p id="details-title">Album Details</p>
        <div id="img-wrapper">
            <img src="${ctx.data.imageUrl}" />
        </div>
        <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${ctx.data.singer}</span></p>
            <p>
                <strong>Album name:</strong><span id="details-album">${ctx.data.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${ctx.data.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${ctx.data.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${ctx.data.sales}</span></p>
        </div>
        <div id="likes">Likes: <span id="likes-count">${ctx.data.likes}</span></div>

        <div id="action-buttons">
            ${ctx.isLogged && !ctx.isOwner && ctx.user.likes == 0
            ? html`<a href="javascript:void(0)" id="like-btn" @click=${onLike}>Like</a>` 
            : null}
            

        ${ctx.isOwner
        ? html`
            <a href="/edit/${ctx.data._id}" id="edit-btn">Edit</a>
            <a href="/delete/${ctx.data._id}" id="delete-btn">Delete</a>`
        : null}

        </div>
    </div>
</section>
`

export const detailsView = async (ctx) => {
    console.log(ctx.data);
    const onLike = async(e) => {
        e.preventDefault();
        await addLike({albumId: ctx.data._id});

        ctx.page.redirect(`/details/${ctx.data._id}`)
    }
    ctx.display(detailsTemplate(ctx, onLike))
}