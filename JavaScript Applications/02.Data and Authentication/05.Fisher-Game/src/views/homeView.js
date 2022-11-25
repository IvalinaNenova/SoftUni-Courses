import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { getData, deleteItem, editItem, createItem } from '../services/dataService.js';
import { resultTemplate } from './detailsView.js';

const homeTemplate = (onLoad, onAdd, user) => html`
<section id="home-view">
    <fieldset id="main">

    </fieldset>
    <aside>
        <button @click=${onLoad} class="load">Load</button>
        <form id="addForm" @submit=${onAdd}>
            <fieldset>
                <legend>Add Catch</legend>
                <label>Angler</label>
                <input type="text" name="angler" class="angler" />
                <label>Weight</label>
                <input type="number" name="weight" class="weight" />
                <label>Species</label>
                <input type="text" name="species" class="species" />
                <label>Location</label>
                <input type="text" name="location" class="location" />
                <label>Bait</label>
                <input type="text" name="bait" class="bait" />
                <label>Capture Time</label>
                <input type="number" name="captureTime" class="captureTime" />
                <button ?disabled=${!user} class="add">Add</button>
            </fieldset>
        </form>
    </aside>
</section>
`

export const homeView = (ctx) => {
    const onLoad = async (e) => {
        let results = await getData();
        console.log(results);

        const onDelete = async (e) => {
            await deleteItem(e.target.dataset.id);
            console.log(e.target.dataset.id);
            onLoad();
        }

        const onUpdate = async (e) => {
            console.log(e.currentTarget.parentNode);
            let entries = [...e.currentTarget.parentNode.querySelectorAll('input')].map(e => e.value);
            if (entries.includes('')) return alert('All fields are required')
            let data = {
                angler: entries[0],
                weight: entries[1],
                species: entries[2],
                location: entries[3],
                bait: entries[4],
                captureTime: entries[5]
            }
            await editItem(e.target.dataset.id, data)

        }

        render(resultTemplate(results, ctx.user, onDelete, onUpdate), document.querySelector('#main'))
    }

    const onAdd = async (e) => {
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        if (Object.values(data).includes('')) return alert('All fields are required')

        await createItem(data);
        onLoad()
    }

    ctx.display(homeTemplate(onLoad, onAdd, ctx.user))
}