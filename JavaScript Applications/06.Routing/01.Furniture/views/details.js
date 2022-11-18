import { html, render } from '../node_modules/lit-html/lit-html.js';
import { onDetails } from '../api.js';

function detailsTemplate(furniture){
    return html`
<div class="row space-top">
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
        ${sessionStorage.ownerId !== undefined && sessionStorage.ownerId == furniture._ownerId
          ? html`
              <div>
                <a href="/edit/${furniture._id}" class="btn btn-info">Edit</a>
                <a href="/delete/${furniture._id}" class="btn btn-red">Delete</a>
              </div>
            `
          : null}
        <!-- <div>
            <a href="/edit/${furniture._id}" class="btn btn-info" style="display:${furniture._ownerId == sessionStorage.ownerId ?'inline' : 'none'}">Edit</a>
            <a href="/delete/${furniture._id}" class="btn btn-red" style="display:${furniture._ownerId == sessionStorage.ownerId ?'inline' : 'none'}">Delete</a>
        </div> -->
    </div>
</div>`
}

export async function detailsView(ctx){
    let furniture = await onDetails(ctx.params.detailsId);
    render(detailsTemplate(furniture), document.querySelector('.container'))
}