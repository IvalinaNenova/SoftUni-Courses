import { html } from '../../node_modules/lit-html/lit-html.js';
import { createItem } from '../services/dataService.js';
import { formHandler } from '../utils/util.js';

const createTemplate = (onSubmit) => html`
<section id="create-listing">
    <div class="container">
        <form id="create-form" @submit=${onSubmit}>
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>
</section>
`

export const createView = (ctx) => {
    const onSubmit = async (e) => {
        
        try {
            let data = formHandler(e);
            data.year = Number(data.year);
            data.price = Number(data.price);

            if (data.year < 0 || data.price < 0) return alert('Invalid input');

            await createItem(data);
            ctx.page.redirect('/catalog')

        } catch (error) { }
    }

    ctx.display(createTemplate(onSubmit))
}