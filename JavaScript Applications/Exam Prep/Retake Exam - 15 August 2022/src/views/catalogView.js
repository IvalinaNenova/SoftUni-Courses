import { html } from '../../node_modules/lit-html/lit-html.js';
import {getData} from '../services/dataService.js';
const cardTemplate = (s, onDetails) => html`
<li class="card">
    <img src="${s.imageUrl}" alt="travis" />
        <p>
    <strong>Brand: </strong><span class="brand">${s.brand}</span>
        </p>
        <p>
    <strong>Model: </strong><span class="model">${s.model}</span>
        </p>
    <p><strong>Value:</strong><span class="value">${s.value}</span>$</p>
    <a class="details-btn" href="/details/${s._id}" @click=${onDetails}>Details</a>
</li>
`
const catalogTemplate = (catalog, onDetails) => html`
<section id="dashboard">
    ${catalog.length > 0 
    ? html`
          <h2>Collectibles</h2>
          <ul class="card-wrapper">
            ${catalog.map(s => cardTemplate(s, onDetails))}
          </ul>
    `
    : html`<h2>There are no items added yet.</h2>`
    }
</section>
`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    ctx.display(catalogTemplate(catalog));
}