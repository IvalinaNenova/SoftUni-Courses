import { html } from '../../node_modules/lit-html/lit-html.js';
import { editItem, getItem } from '../services/dataService.js';

const editTemplate = (event, onSubmit) => html`
<section id="editPage">
    <form class="theater-form" @submit=${onSubmit}>
        <h1>Edit Theater</h1>
        <div>
            <label for="title">Title:</label>
            <input id="title" name="title" type="text" placeholder="Theater name" value="${event.title}">
        </div>
        <div>
            <label for="date">Date:</label>
            <input id="date" name="date" type="text" placeholder="Month Day, Year" value="${event.date}">
        </div>
        <div>
            <label for="author">Author:</label>
            <input id="author" name="author" type="text" placeholder="Author" value="${event.author}">
        </div>
        <div>
            <label for="description">Theater Description:</label>
            <textarea id="description" name="description" placeholder="Description">${event.description}</textarea>
        </div>
        <div>
            <label for="imageUrl">Image url:</label>
            <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url" value="${event.imageUrl}">
        </div>
        <button class="btn" type="submit">Submit</button>
    </form>
</section>
`

export const editView = async (ctx) => {
    const event = await getItem(ctx.params.id);

    const onSubmit = async (e) => {
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        let values = Object.values(data);

        if (values.includes('')) return alert('All fields are required')

        await editItem(ctx.params.id, data);
        ctx.page.redirect(`/details/${event._id}`);
    }

    ctx.display(editTemplate(event, onSubmit));
}