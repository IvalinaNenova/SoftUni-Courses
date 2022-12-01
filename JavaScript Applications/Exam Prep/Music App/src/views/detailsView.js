import { html } from '../../node_modules/lit-html/lit-html.js';

//user && user._id == item._ownerId - check if user or guest and owner


const detailsTemplate = (ctx) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src="${ctx.data.imgUrl}">
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${ctx.data.name}</h1>
                <h3>Artist: ${ctx.data.artist}</h3>
                <h4>Genre: ${ctx.data.genre}</h4>
                <h4>Price: $${ctx.data.price}</h4>
                <h4>Date: ${ctx.data.releaseDate}</h4>
                <p>${ctx.data.description}</p>
            </div>

            ${ctx.isOwner
            ? html`<div class="actionBtn">
                <a href="/edit/${ctx.data._id}" class="edit">Edit</a>
                <a href="/delete/${ctx.data._id}" class="remove">Delete</a>
            </div>`
            : null}
            
        </div>
    </div>
</section>
`

export const detailsView = async (ctx) => {
    ctx.display(detailsTemplate(ctx))
}