import { html } from '../../node_modules/lit-html/lit-html.js';
import { createItem } from '../services/dataService.js';
import { formHandler } from '../utils/util.js';

const createTemplate = (onSubmit) => html`
<section id="create">
        <div class="form">
          <h2>Add Album</h2>
          <form class="create-form" @submit=${onSubmit}>
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
            <input type="text" name="album" id="album-album" placeholder="Album" />
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
            <input type="text" name="release" id="album-release" placeholder="Release date" />
            <input type="text" name="label" id="album-label" placeholder="Label" />
            <input type="text" name="sales" id="album-sales" placeholder="Sales" />

            <button type="submit">post</button>
          </form>
        </div>
      </section>
`

export const createView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();
        try {
            let data = formHandler(e);

            await createItem(data);
            ctx.page.redirect('/catalog') 
        } catch (error) {
            alert(error.message);
        }

    }

    ctx.display(createTemplate(onSubmit))
}