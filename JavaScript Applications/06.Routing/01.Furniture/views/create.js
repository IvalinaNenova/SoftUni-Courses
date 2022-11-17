import { html, render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

function createTemplate() {
    return html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Create New Furniture</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    <form @submit=${onSubmit}>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-make">Make</label>
                    <input class="form-control valid" id="new-make" type="text" name="make">
                </div>
                <div class="form-group has-success">
                    <label class="form-control-label" for="new-model">Model</label>
                    <input class="form-control is-valid" id="new-model" type="text" name="model">
                </div>
                <div class="form-group has-danger">
                    <label class="form-control-label" for="new-year">Year</label>
                    <input class="form-control is-invalid" id="new-year" type="number" name="year">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-description">Description</label>
                    <input class="form-control" id="new-description" type="text" name="description">
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-price">Price</label>
                    <input class="form-control" id="new-price" type="number" name="price">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-image">Image</label>
                    <input class="form-control" id="new-image" type="text" name="img">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-material">Material (optional)</label>
                    <input class="form-control" id="new-material" type="text" name="material">
                </div>
                <input type="submit" class="btn btn-primary" value="Create" />
            </div>
        </div>
    </form>
    `
}

async function onSubmit(e) {
    e.preventDefault();

    let [make, model, year, description, price, image, material] = [...e.currentTarget.elements].slice(0, -1);
    let isValid = true;
    
    make.value.length >= 4 ? decorate(make, true) : decorate(make, false);
    model.value.length >= 4 ? decorate(model, true) : decorate(model, false);
    description.value.length > 10 ? decorate(description, true) : decorate(description, false);
    Number(year.value) > 1950 && Number(year.value) < 2050 ? decorate(year, true) : decorate(year, false);
    Number(price.value) > 0 ? decorate(price, true) : decorate(price, false);
    image.value != '' ? decorate(image, true) : decorate(image, false);

    function decorate(element, bool) {
        if (bool) {
            element.classList.add('is-valid');
            element.classList.remove('is-invalid');
        } else {
            isValid = false;
            element.classList.add('is-invalid');
            element.classList.remove('is-valid');
        }
    }

    if (!isValid) return;

    let response = await fetch('http://localhost:3030/data/catalog', {
        method: 'POST',
        headers: {
            'X-Authorization': sessionStorage.token
        },
        body: JSON.stringify({
            make: make.value,
            model: model.value,
            description: description.value,
            year: year.value,
            price: price.value,
            img: image.value,
            material: material.value,
        })
    })
    if (response.ok) {
        let result = await response.json();
        page.redirect('/catalog');
    }

}

export function createView() {
    render(createTemplate(), document.querySelector('.container'));
}