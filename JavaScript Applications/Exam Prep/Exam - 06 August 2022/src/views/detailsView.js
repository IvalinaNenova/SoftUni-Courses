import { html } from '../../node_modules/lit-html/lit-html.js';
import {getItem} from '../services/dataService.js';


//user && user._id == item._ownerId - check if user or guest and owner


const detailsTemplate = (item, user) => html `


`

export const detailsView = async (ctx) => {
    let item = await getItem(ctx.params.id);
    ctx.display(detailsTemplate(item, ctx.user))
}