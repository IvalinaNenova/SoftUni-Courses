import { html } from '../../node_modules/lit-html/lit-html.js';
import { editItem, getItem } from '../services/dataService.js';

const editTemplate = (item, onSubmit) => html`
<section id="edit-meme">
    <form id="edit-form" @submit=${onSubmit}>
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" value=${item.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description">
                            ${item.description}
                        </textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" value=${item.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>
`

export const editView = async (ctx) => {
    const item = await getItem(ctx.params.id);

    const onSubmit = async (e) => {
        e.preventDefault();

        try {
            let data = Object.fromEntries(new FormData(e.target));
        let values = Object.values(data);

        if (values.includes('')) throw new Error('All fields are required')

        await editItem(ctx.params.id, data);
        ctx.page.redirect('/catalog')
        } catch (error) {
            ctx.displayError(error.message)
        }
    }

    ctx.display(editTemplate(item, onSubmit));
}