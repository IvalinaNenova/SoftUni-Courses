import { html } from '../../node_modules/lit-html/lit-html.js';

const detailsTemplate = (ctx) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${ctx.data.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${ctx.data.brand}</li>
            <li><span>Model:</span>${ctx.data.model}</li>
            <li><span>Year:</span>${ctx.data.year}</li>
            <li><span>Price:</span>${ctx.data.price}$</li>
        </ul>

        <p class="description-para">${ctx.data.description}</p>

        ${ctx.isOwner?
        html`
        <div class="listings-buttons">
            <a href="/edit/${ctx.data._id}" class="button-list">Edit</a>
            <a href="/delete/${ctx.data._id}" class="button-list">Delete</a>
        </div>`
        : null}
        
    </div>
</section>
`

export const detailsView = async (ctx) => {
    ctx.display(detailsTemplate(ctx))
}