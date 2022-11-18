import { html, render } from '../node_modules/lit-html/lit-html.js';
import { validator } from '../validate.js';
import { onUpdate, onDetails } from '../api.js';
import page from '../node_modules/page/page.mjs';

function editTemplate(furniture) {
    return html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Edit Furniture</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    <form @submit=${onSubmit}>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-make">Make</label>
                    <input class="form-control" id="new-make" type="text" name="make" value="${furniture.make}">
                </div>
                <div class="form-group has-success">
                    <label class="form-control-label" for="new-model">Model</label>
                    <input class="form-control is-valid" id="new-model" type="text" name="model" value="${furniture.model}">
                </div>
                <div class="form-group has-danger">
                    <label class="form-control-label" for="new-year">Year</label>
                    <input class="form-control is-invalid" id="new-year" type="number" name="year"
                        value="${furniture.year}">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-description">Description</label>
                    <input class="form-control" id="new-description" type="text" name="description"
                        value="${furniture.description}">
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-price">Price</label>
                    <input class="form-control" id="new-price" type="number" name="price" value="${furniture.price}">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-image">Image</label>
                    <input class="form-control" id="new-image" type="text" name="img" value="${furniture.img}">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-material">Material (optional)</label>
                    <input class="form-control" id="new-material" type="text" name="material" value="${furniture.material}">
                </div>
                <input type="submit" id=${furniture._id} class="btn btn-info" value="Edit" />
            </div>
        </div>
    </form>
    `
}

async function onSubmit(e) {
    e.preventDefault();
    let data = [...e.currentTarget.elements].slice(0, -1);

    let info = validator(data);

    if (info == false) {
        return alert('Invalid fields');
    }

    let id = e.currentTarget.querySelector('input[type="submit"]').id;

    await onUpdate(info, id);
    page.redirect('/catalog');
}

export async function editView(ctx) {
    let furniture = await onDetails(ctx.params.detailsId);
    render(editTemplate(furniture), document.querySelector('.container'));
}