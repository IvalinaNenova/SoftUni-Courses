import {render} from '../../node_modules/lit-html/lit-html.js';
import { navigationView } from '../views/navigationView.js';
const headerElement = document.querySelector('.header-navigation');
const rootElement = document.querySelector('#root');

const display = (templateResult) => render(templateResult, rootElement);

export const displayNavigation = (ctx, next) => {
    render(navigationView(ctx), headerElement);
    next();
}

export const displayContent = (ctx, next) => {
    ctx.display = display;
    next();
}