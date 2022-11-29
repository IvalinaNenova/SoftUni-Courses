import { render } from '../../node_modules/lit-html/lit-html.js';
import { navigationView } from '../views/navigation.js';

const headerElement = document.querySelector('#site-header');
const rootElement = document.querySelector('#site-content');

export function displayNav(ctx, next) {
    render(navigationView(ctx), headerElement);
    next();
}

export function displayContent(ctx, next) {
    ctx.render = function (templateResult) {
        render(templateResult, rootElement);
    }
    next();
}