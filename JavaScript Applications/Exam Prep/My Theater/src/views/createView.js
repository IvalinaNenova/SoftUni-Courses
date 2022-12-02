import { html } from '../../node_modules/lit-html/lit-html.js';
import { createItem } from '../services/dataService.js';
import { formHandler } from '../utils/util.js';

const createTemplate = (onSubmit) => html`
<section id="createPage">
    <form class="create-form" @submit=${onSubmit}>
        <h1>Create Theater</h1>
        <div>
            <label for="title">Title:</label>
            <input id="title" name="title" type="text" placeholder="Theater name" value="">
        </div>
        <div>
            <label for="date">Date:</label>
            <input id="date" name="date" type="text" placeholder="Month Day, Year">
        </div>
        <div>
            <label for="author">Author:</label>
            <input id="author" name="author" type="text" placeholder="Author">
        </div>
        <div>
            <label for="description">Description:</label>
            <textarea id="description" name="description" placeholder="Description"></textarea>
        </div>
        <div>
            <label for="imageUrl">Image url:</label>
            <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url" value="">
        </div>
        <button class="btn" type="submit">Submit</button>
    </form>
</section>
`

export const createView = (ctx) => {
    const onSubmit = async (e) => {

        try {
            let data = formHandler(e);
            await createItem(data);
            ctx.page.redirect('/')

        } catch (error) { 
            alert(error.message)
        }
    }

    ctx.display(createTemplate(onSubmit))
}