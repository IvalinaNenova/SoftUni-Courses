import { html } from '../../node_modules/lit-html/lit-html.js';
import { createItem } from '../services/dataService.js';

const createTemplate = (onSubmit) => html`
<section id="add-movie" class="view-section">
    <form id="add-movie-form" class="text-center border border-light p-5" action="#" method="" @submit=${onSubmit}>
        <h1>Add Movie</h1>
        <div class="form-group">
            <label for="title">Movie Title</label>
            <input id="title" type="text" class="form-control" placeholder="Title" name="title" value="" />
        </div>
        <div class="form-group">
            <label for="description">Movie Description</label>
            <textarea class="form-control" placeholder="Description" name="description"></textarea>
        </div>
        <div class="form-group">
            <label for="imageUrl">Image url</label>
            <input id="imageUrl" type="text" class="form-control" placeholder="Image Url" name="img" value="" />
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
</section>
`

export const createView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        let values = Object.values(data);

        if (values.includes('')) return alert('All fields are required')

        await createItem(data);
        ctx.page.redirect('/home')
    }

    ctx.display(createTemplate(onSubmit))
}