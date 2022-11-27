import { html } from '../../node_modules/lit-html/lit-html.js';
import { getData } from '../services/dataService.js';

const cardTemplate = (s) => html`
<div class="meme">
    <div class="card">
        <div class="info">
            <p class="meme-title">${s.title}</p>
            <img class="meme-image" alt="meme-img" src="${s.imageUrl}">
        </div>
        <div id="data-buttons">
            <a class="button" href="/details/${s._id}">Details</a>
        </div>
    </div>
</div>
`
const catalogTemplate = (catalog) => html`
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">

        ${catalog.length > 0
        ? catalog.map(cardTemplate)
        : html`<p class="no-memes">No memes in database.</p>`}
        
    </div>
</section>
`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    console.log(catalog);
    ctx.display(catalogTemplate(catalog));
}