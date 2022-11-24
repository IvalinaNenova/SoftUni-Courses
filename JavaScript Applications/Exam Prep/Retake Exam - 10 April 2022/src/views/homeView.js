import { html } from '../../node_modules/lit-html/lit-html.js';

const homeTemplate = () => html`

`
export const homeView = (ctx) => {
    ctx.page.redirect('/catalog')
}