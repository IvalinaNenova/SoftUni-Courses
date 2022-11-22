import { html } from '../../node_modules/lit-html/lit-html.js';
import { filter } from '../services/dataService.js';

const resultCard = (r, user) => html`
<li class="card">
    <img src="${r.imageUrl}" alt="travis" />
    <p>
        <strong>Brand: </strong><span class="brand">${r.brand}</span>
    </p>
    <p>
        <strong>Model: </strong><span class="model">${r.model}</span>
    </p>
    <p><strong>Value:</strong><span class="value">${r.value}</span>$</p>
    ${user ? html`<a class="details-btn" href="/details/${r._id}">Details</a>` : null}
    </li>
`

const searchTemplate = (onSubmit, result, user) => html`
<section id="search">
    <h2>Search by Brand</h2>

    <form class="search-wrapper cf" @submit=${onSubmit}>
        <input id="#search-input" type="text" name="search" placeholder="Search here..." required />
        <button type="submit">Search</button>
    </form>

    <h3>Results:</h3>

    <div id="search-container">
    <ul class="card-wrapper">
        ${result && result.length > 0 
        ? result.map(r => resultCard(r, user))
        : html`<h2>There are no results found.</h2>`}
    </ul>
    </div>
</section>
`

export const searchView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();
        let searched = e.target.elements[0].value;

        let result = await filter(searched);

        ctx.display(searchTemplate (onSubmit, result, ctx.user))
    }

    ctx.display(searchTemplate(onSubmit));
}