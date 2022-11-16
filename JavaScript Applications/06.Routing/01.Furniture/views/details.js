import { html, render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

function detailsTemplate(furniture){
    return html`<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src=".${furniture.img}" />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${furniture.make}</span></p>
        <p>Model: <span>${furniture.model}</span></p>
        <p>Year: <span>${furniture.year}</span></p>
        <p>Description: <span>${furniture.description}</span></p>
        <p>Price: <span>${furniture.price}</span></p>
        <p>Material: <span>${furniture.material}</span></p>
        <div>
            <a href="/edit/${furniture._id}" class="btn btn-info" style="display:${furniture._ownerId == sessionStorage.ownerId ?'inline' : 'none'}">Edit</a>
            <a href="#" .id=${furniture._id} class="btn btn-red" style="display:${furniture._ownerId == sessionStorage.ownerId ?'inline' : 'none'}" @click=${onDelete}>Delete</a>
        </div>
    </div>
</div>`
}

async function onDelete(e){
    console.log(e.target.id);

    let response = await fetch (`http://localhost:3030/data/catalog/${e.target.id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': sessionStorage.token
        }
    })

    if (response.ok) {
        page.redirect('/catalog')
    }
}
async function getDetails(detailsId){
    let response = await fetch(`http://localhost:3030/data/catalog/${detailsId}`);
    let result = await response.json();
    return result;
}
export async function detailsView(ctx){
    let furniture = await getDetails(ctx.params.detailsId);
    console.log(ctx);
    console.log(furniture);
    render(detailsTemplate(furniture), document.querySelector('.container'))
}