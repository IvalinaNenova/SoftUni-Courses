import { html } from '../../node_modules/lit-html/lit-html.js';
import { getData } from '../services/dataService.js';

const cardTemplate = (s) => html`
<div class="animals-board">
    <article class="service-img">
        <img class="animal-image-cover" src="${s.image}">
    </article>
    <h2 class="name">${s.name}</h2>
    <h3 class="breed">${s.breed}</h3>
    <div class="action">
        <a class="btn" href="/details/${s._id}">Details</a>
    </div>
</div>
`
const catalogTemplate = (catalog) => html`
<section id="dashboard">
    <h2 class="dashboard-title">Services for every animal</h2>
    <div class="animals-dashboard">

    ${catalog.length > 0 
    ? catalog.map(cardTemplate)
    : html`
    <div>
        <p class="no-pets">No pets in dashboard</p>
    </div>`}

    </div>
</section>

`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    console.log(catalog);
    ctx.display(catalogTemplate(catalog));
}