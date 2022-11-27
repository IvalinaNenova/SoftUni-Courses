import * as sessionService from '.././services/sessionService.js';
import { render } from '../../node_modules/lit-html/lit-html.js';

export const saveUserStatus = (ctx, next) => {
    ctx.user = sessionService.getUser();
    next();
}


export const decorateContext = (rootElement, headerElement, user) => {
    return function (ctx, next) {
        ctx.user = user();

        ctx.display = (templateResult) => render(templateResult, rootElement);

        ctx.displayNavigation = (content) => {
            render(content, headerElement);
        }

        next();
    }
}