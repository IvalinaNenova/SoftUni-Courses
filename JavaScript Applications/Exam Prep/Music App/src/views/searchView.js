import { html } from '../../node_modules/lit-html/lit-html.js';
import { search } from '../services/dataService.js';

const resultCard = (album, user) => html`
<div class="card-box">
    <img src="${album.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: $${album.genre}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>

        ${user? html`
        <div class="btn-group">
            <a href="#" id="details">Details</a>
        </div>`
        : null}
        
    </div>
</div>`


const searchTemplate = (onSubmit, result, user) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button class="button-list" @click=${onSubmit}>Search</button>
    </div>

    <h2>Results:</h2>

    <div class="search-result">
    ${result?.length > 0
    ? result.map(album => (resultCard(album, user)))
    : html`<p class="no-result">No result.</p>`}

    </div>
</section>
`

export const searchView = (ctx) => {
    let result;
    const onSubmit = async (e) => {
        e.preventDefault();
        let searched = e.target.parentNode.children[0].value;

        let result = await search(searched);

        ctx.display(searchTemplate(onSubmit, result, ctx.user));
    }

    ctx.display(searchTemplate(onSubmit, result, ctx.user));
}