import { html, render } from '../node_modules/lit-html/lit-html.js';
import { getMyFurnitures } from '../api.js';

function myFurnitureTemplate(catalog) {
    return html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>My Furniture</h1>
            <p>This is a list of your publications.</p>
        </div>
    </div>
    <div class="row space-top">
        ${catalog.map(item => html`
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
        </div>
        `)}
    </div>
    `
}

export async function myFurnitureView(ctx) {
    let userId = sessionStorage.getItem('ownerId');
    let catalog = await getMyFurnitures(userId);
    render(myFurnitureTemplate(catalog), document.querySelector('.container'))
}