import { html } from '../../node_modules/lit-html/lit-html.js';
import { filter } from '../services/dataService.js';

const resultCard = (r, user) => html`

`

const searchTemplate = (onSubmit, result, user) => html`

`

export const searchView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();
        let searched = e.target.elements[0].value;

        let result = await filter(searched);

        ctx.display(searchTemplate (onSubmit, result, ctx.user))
    }

    ctx.display(searchTemplate(onSubmit));
}