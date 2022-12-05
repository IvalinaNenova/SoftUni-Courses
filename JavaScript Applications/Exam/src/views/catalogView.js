import { html } from '../../node_modules/lit-html/lit-html.js';
import { getData } from '../services/dataService.js';

const cardTemplate = (album) => html`
<li class="card">
    <img src="${album.imageUrl}" alt="travis" />
    <p>
        <strong>Singer/Band: </strong><span class="singer">${album.singer}</span>
    </p>
    <p>
        <strong>Album name: </strong><span class="album">${album.album}</span>
    </p>
    <p><strong>Sales:</strong><span class="sales">${album.sales}</span></p>
    <a class="details-btn" href="/details/${album._id}">Details</a>
</li>
`
const catalogTemplate = (catalog) => html`
<section id="dashboard">
    <h2>Albums</h2>

    ${catalog.length > 0
    ? html`<ul class="card-wrapper">
        
        ${catalog.map(cardTemplate)}
        
    </ul>`
    : html`<h2>There are no albums added yet.</h2>`}
    
</section>

`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    ctx.display(catalogTemplate(catalog));
}