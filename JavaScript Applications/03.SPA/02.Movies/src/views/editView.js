import { html } from '../../node_modules/lit-html/lit-html.js';
import { editItem, getItem } from '../services/dataService.js';

const editTemplate = (movie, onSubmit) => html`
<section id="edit-movie" class="view-section">
    <form class="text-center border border-light p-5" action="#" method="" @submit=${onSubmit}>
        <h1>Edit Movie</h1>
        <div class="form-group">
            <label for="title">Movie Title</label>
            <input id="title" type="text" class="form-control" placeholder="Movie Title" value="${movie.description}" name="title" />
        </div>
        <div class="form-group">
            <label for="description">Movie Description</label>
            <textarea class="form-control" placeholder="Movie Description..." name="description">${movie.title}</textarea>
        </div>
        <div class="form-group">
            <label for="imageUrl">Image url</label>
            <input id="imageUrl" type="text" class="form-control" placeholder="Image Url" value="${movie.description}" name="img" />
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
</section>
`

export const editView = async (ctx) => {
    const item = await getItem(ctx.params.id);

    const onSubmit = async (e) => {
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        let values = Object.values(data);

        if (values.includes('')) return alert('All fields are required')

        await editItem(ctx.params.id, data);
        ctx.page.redirect(`/details/${item._id}`);
    }

    ctx.display(editTemplate(item, onSubmit));
}