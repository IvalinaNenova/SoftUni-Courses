import { html } from '../../node_modules/lit-html/lit-html.js';
import { editItem, getItem } from '../services/dataService.js';

const editTemplate = (game, onSubmit) => html`
<section id="edit-page" class="auth">
    <form id="edit" @submit=${onSubmit}>
        <div class="container">

            <h1>Edit Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" value="${game.title}">

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" value="${game.category}">

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" value="${game.maxLevel}">

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" value="${game.imageUrl}">

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary">${game.summary}</textarea>
            <input class="btn submit" type="submit" value="Edit Game">

        </div>
    </form>
</section>

`

export const editView = async (ctx) => {
    const item = await getItem(ctx.params.id);

    const onSubmit = async (e) => {
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        let values = Object.values(data);
        console.log(data);

        if (values.includes('')) return alert('All fields are required')

        await editItem(ctx.params.id, data);
        ctx.page.redirect(`/details/${item._id}`);
    }

    ctx.display(editTemplate(item, onSubmit));
}