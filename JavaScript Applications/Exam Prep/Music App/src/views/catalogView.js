import { html } from '../../node_modules/lit-html/lit-html.js';
import { getData } from '../services/dataService.js';

const albumCard = (album, user) => html`
<div class="card-box">
    <img src="${album.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: $${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>
        ${user
        ? html`
        <div class="btn-group">
            <a href="/details/${album._id}" id="details">Details</a>
        </div>`
        : null}
        
    </div>
</div>
`
const catalogTemplate = (catalog, user) => html`
<section id="catalogPage">
    <h1>All Albums</h1>

    ${catalog.length > 0 
    ? catalog.map(album => albumCard(album, user))
    : html`<p>No Albums in Catalog!</p>`}

</section>
`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    ctx.display(catalogTemplate(catalog, ctx.user));
}