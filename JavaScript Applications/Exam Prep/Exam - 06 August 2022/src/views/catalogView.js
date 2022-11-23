import { html } from '../../node_modules/lit-html/lit-html.js';
import {getData} from '../services/dataService.js';

const cardTemplate = (s, onDetails) => html`

`
const catalogTemplate = (catalog, onDetails) => html`


`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    ctx.display(catalogTemplate(catalog));
}