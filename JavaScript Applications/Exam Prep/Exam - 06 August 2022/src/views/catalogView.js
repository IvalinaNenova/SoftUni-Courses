import { html } from '../../node_modules/lit-html/lit-html.js';
import { getData } from '../services/dataService.js';

const cardTemplate = (s, onDetails) => html`
<div class="offer">
    <img src="${s.imageUrl}" alt="example1" />
    <p>
        <strong>Title: </strong><span class="title">${s.title}</span>
    </p>
    <p><strong>Salary:</strong><span class="salary">${s.salary}</span></p>
    <a class="details-btn" @click=${onDetails} href="/details/${s._id}">Details</a>
</div>
`
const catalogTemplate = (catalog, onDetails) => html`
<section id="dashboard">
    <h2>Job Offers</h2>

    ${catalog.length > 0 
    ? catalog.map(offer=> cardTemplate(offer, onDetails))
    : html`<h2>No offers yet.</h2>`}

</section>
`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    ctx.display(catalogTemplate(catalog));
}