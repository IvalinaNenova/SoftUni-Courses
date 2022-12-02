import { html } from '../../node_modules/lit-html/lit-html.js';
import { search } from '../services/dataService.js';

const resultCard = (car) => html`

`

const searchTemplate = (onSubmit, result) => html`

`

export const searchView = (ctx) => {
    let result;
    const onSubmit = async (e) => {
        e.preventDefault();
        let searched = e.target.parentNode.children[0].value;

        let result = await search(searched);

        ctx.display(searchTemplate(onSubmit, result))
    }

    ctx.display(searchTemplate(onSubmit, result));
}