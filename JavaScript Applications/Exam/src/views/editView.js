import { html } from '../../node_modules/lit-html/lit-html.js';
import { editItem } from '../services/dataService.js';
import { formHandler } from '../utils/util.js';

const editTemplate = (album, onSubmit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit Album</h2>
        <form class="edit-form" @submit=${onSubmit}>
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" value=${album.singer} />
            <input type="text" name="album" id="album-album" placeholder="Album" value=${album.album} />
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" value=${album.imageUrl} />
            <input type="text" name="release" id="album-release" placeholder="Release date" value=${album.release} />
            <input type="text" name="label" id="album-label" placeholder="Label" value=${album.label} />
            <input type="text" name="sales" id="album-sales" placeholder="Sales" value=${album.sales} />

            <button type="submit">post</button>
        </form>
    </div>
</section>

`
export const editView = async (ctx) => {

    const onSubmit = async (e) => {
        e.preventDefault();

        try {
            let data = formHandler(e);
            await editItem(ctx.params.id, data);
            ctx.page.redirect(`/details/${ctx.params.id}`)
        } catch (error) {
            alert(error.message);
        }
    }
    console.log(ctx.data);
    ctx.display(editTemplate(ctx.data, onSubmit));
}