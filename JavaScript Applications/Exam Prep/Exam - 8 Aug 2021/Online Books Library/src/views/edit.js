import { html } from '../../node_modules/lit-html/lit-html.js';
import { editItem, getItem } from '../services/dataService.js';

function editTemplate(item, submitHandler) {
    return html`
<section id="edit-page" class="edit">
    <form id="edit-form" action="#" method="" @submit=${submitHandler}>
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" value="${item.title}">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description">${item.description}</textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" value="${item.imageUrl}">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" value="Fiction">
                        <option value="Fiction" selected>Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
        </fieldset>
    </form>
</section>

`}

export async function editView(ctx) {
    const item = await getItem(ctx.params.id);

    async function submitHandler(e) {
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        let values = Object.values(data);

        if (values.includes('')) {
            return alert('All fields must be filled')
        }

        await editItem(ctx.params.id, data);
        ctx.page.redirect(`/details/${item._id}`)
    }

    ctx.render(editTemplate(item, submitHandler));
}