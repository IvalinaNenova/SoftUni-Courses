import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAllItems } from '../services/dataService.js';

function cardTemplate(x) {
    return html`
<li class="otherBooks">
    <h3>${x.title}</h3>
    <p>Type: ${x.type}</p>
    <p class="img"><img src="${x.imageUrl}"></p>
    <a class="button" href="/details/${x._id}">Details</a>
</li>
`}

function dashboardTemplate(allItems) {
    return html`
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <ul class="other-books-list">

        ${allItems.length > 0
        ? allItems.map(x => cardTemplate(x))
        : html`<p class="no-books">No books in database!</p>`}
    </ul>

</section>
`}

export async function dashboardView (ctx) {
    const allItems = await getAllItems();
    ctx.render(dashboardTemplate(allItems));
}