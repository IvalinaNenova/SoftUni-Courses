import page from '../node_modules/page/page.mjs';
import { html, render } from '../node_modules/lit-html/lit-html.js';

function catalogTemplate(catalog) {
    return html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Welcome to Furniture System</h1>
            <p>Select furniture from the catalog to view details.</p>
        </div>
    </div>
    <div class="row space-top">
        ${catalog.map(item => itemCard(item))}
    </div>
    `
}

function itemCard(item) {
    return html`
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="${item.img}" />
                <p>${item.description}</p>
                <footer>
                    <p>Price: <span>${item.price} $</span></p>
                </footer>
                <div>
                    <a href="/details/${item._id}" class="btn btn-info">Details</a>
                </div>
            </div>
        </div>
    </div>`
}
async function getCatalog() {
    let response = await fetch('http://localhost:3030/data/catalog');
    let result = await response.json();

    return Object.values(result);
}

export async function catalogView(ctx) {
    let catalog = await getCatalog();
    render(catalogTemplate(catalog), document.querySelector('.container'));
}