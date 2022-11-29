import { html } from '../../node_modules/lit-html/lit-html.js';
import { createItem } from '../services/dataService.js';

function createTemplate (submitHandler) {
    return html`
<section id="create-page" class="create">
    <form id="create-form" action="" method="" @submit=${submitHandler}>
        <fieldset>
            <legend>Add new Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" placeholder="Title">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description" placeholder="Description"></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" placeholder="Image">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type">
                        <option value="Fiction">Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Add Book">
        </fieldset>
    </form>
</section>
`}

export function createView (ctx) {
    async function submitHandler (e){
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        console.log(data);
        let values = Object.values(data);

        if (values.includes('')) {
            return alert('All fields are required');
        }

        await createItem(data);
        ctx.page.redirect('/dashboard')
    }

    ctx.render(createTemplate(submitHandler))
}