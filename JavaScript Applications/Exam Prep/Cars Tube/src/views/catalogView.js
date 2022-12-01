import { html } from '../../node_modules/lit-html/lit-html.js';
import { getData } from '../services/dataService.js';

const cardTemplate = (car) => html`
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
const catalogTemplate = (catalog) => html`
<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">

        ${catalog.length > 0 
        ? catalog.map(cardTemplate)
        : html`<p class="no-cars">No cars in database.</p>`}
        
    </div>
</section>
`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    ctx.display(catalogTemplate(catalog));
}