import {render} from '../../node_modules/lit-html/lit-html.js';
import * as sessionService from '../services/sessionService.js';

const roots = {
    header : document.querySelector('nav'),
    main: document.querySelector('#root')
}

const display = (templateResult, root = 'main') => render(templateResult, roots[root]);


export const displayContent = (ctx, next) => {
    ctx.display = display;
    next();
}

export const saveUserStatus = (ctx, next) => {
    ctx.user = sessionService.getUser();
    next();
}