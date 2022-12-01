import { html } from '../../node_modules/lit-html/lit-html.js';
import { search } from '../services/dataService.js';

const resultCard = (car) => html`
<div class="listing">
    <div class="preview">
        <img src="${car.imageUrl}">
    </div>
    <h2>${car.brand} ${car.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>
`

const searchTemplate = (onSubmit, result) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button class="button-list" @click=${onSubmit}>Search</button>
    </div>

    <h2>Results:</h2>
    <div class="listings">

        ${result?.length > 0
        ? result.map(resultCard)
        :html`<p class="no-cars"> No results.</p>`}
        
    </div>
</section>
`

export const searchView = (ctx) => {
    let result;
    const onSubmit = async (e) => {
        e.preventDefault();
        let searched = e.target.parentNode.children[0].value;

        let result = await search(searched);

        ctx.display(searchTemplate(onSubmit, result))
    }

    ctx.display(searchTemplate(onSubmit, result));
}