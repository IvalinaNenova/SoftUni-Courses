import { html } from '../../node_modules/lit-html/lit-html.js';
import { getItem } from '../services/dataService.js';


//user && user._id == item._ownerId - check if user or guest and owner


export const resultTemplate = (catalog, user, onDelete, onUpdate) => html`
<legend>Catches</legend>
<div id="catches">
    ${catalog.map(c => html`
    <div class="catch">
        <label>Angler</label>
        <input type="text" class="angler" value="${c.angler}">
        <label>Weight</label>
        <input type="text" class="weight" value="${c.weight}">
        <label>Species</label>
        <input type="text" class="species" value="${c.species}">
        <label>Location</label>
        <input type="text" class="location" value="${c.location}">
        <label>Bait</label>
        <input type="text" class="bait" value="${c.bait}">
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${c.captureTime}">
        <button class="update" @click=${onUpdate} data-id=${c._id} ?disabled=${!user || user._id != c._ownerId} >Update</button>
        <button class="delete" @click=${onDelete} data-id=${c._id} ?disabled=${!user || user._id != c._ownerId} >Delete</button>
    </div>`)}
`

// export const detailsView = async (ctx) => {
//     let item = await getItem(ctx.params.id);
//     ctx.display(detailsTemplate(item, ctx.user))
// }