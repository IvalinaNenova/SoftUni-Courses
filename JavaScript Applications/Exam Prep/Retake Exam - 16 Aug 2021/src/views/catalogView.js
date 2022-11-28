import { html } from '../../node_modules/lit-html/lit-html.js';
import { getData } from '../services/dataService.js';

const cardTemplate = (game) => html`
<div class="allGames">
    <div class="allGames-info">
        <img src="${game.imageUrl}">
        <h6>${game.category}</h6>
        <h2>${game.title}</h2>
        <a href="/details/${game._id}" class="details-button">Details</a>
    </div>

</div>
`
const catalogTemplate = (catalog) => html`
<section id="catalog-page">
    <h1>All Games</h1>

    ${catalog.length > 0 
    ? catalog.map(cardTemplate)
    : html`<h3 class="no-articles">No articles yet</h3>`}
    
</section>
`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    ctx.display(catalogTemplate(catalog));
}