import { html } from '../../node_modules/lit-html/lit-html.js';
import { createItem } from '../services/dataService.js';

const createTemplate = (onSubmit) => html`
<section id="create-meme">
    <form id="create-form" @submit=${onSubmit}>
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
        </div>
    </form>
</section>
`

export const createView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();

        try {
            let data = Object.fromEntries(new FormData(e.target));
            let values = Object.values(data);

            if (values.includes('')) throw new Error('All fields are required')

            await createItem(data);
            ctx.page.redirect('/catalog')
        } catch (error) {
            ctx.displayError(error.message)
        }
    }

    ctx.display(createTemplate(onSubmit))
}