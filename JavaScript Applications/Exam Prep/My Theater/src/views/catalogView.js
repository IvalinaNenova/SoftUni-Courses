import { html } from '../../node_modules/lit-html/lit-html.js';
import { getData } from '../services/dataService.js';

const cardTemplate = (car) => html`

`
const catalogTemplate = (catalog) => html`

`

export const catalogView = async (ctx) => {
    const catalog = await getData();
    ctx.display(catalogTemplate(catalog));
}