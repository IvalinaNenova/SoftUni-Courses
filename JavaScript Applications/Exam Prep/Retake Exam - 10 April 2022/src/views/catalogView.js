import { html } from '../../node_modules/lit-html/lit-html.js';
import { getData } from '../services/dataService.js';

export const cardTemplate = (s) => html`
<div class="post">
    <h2 class="post-title">${s.title}</h2>
    <img class="post-image" src="${s.imageUrl}" alt="Material Image">
    <div class="btn-wrapper">
        <a href="/details/${s._id}"  class="details-btn btn">Details</a>
    </div>
</div>
`
const catalogTemplate = (catalog) => html`
<section id="dashboard-page">
    <h1 class="title">All Posts</h1>
    ${catalog.length > 0
    ? html`
    <div class="all-posts">
        ${catalog.map(post => cardTemplate(post))}
    </div>`
    : html`<h1 class="title no-posts-title">No posts yet!</h1>`}
</section>
`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    ctx.display(catalogTemplate(catalog));
}