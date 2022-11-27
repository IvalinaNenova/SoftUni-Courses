import {render} from '../../node_modules/lit-html/lit-html.js';
import * as sessionService from '../services/sessionService.js';

const roots = {
    header : document.querySelector('#navigation'),
    main: document.querySelector('#root'),
    error: document.querySelector('#notifications'),
}

const display = (templateResult, root = 'main') => render(templateResult, roots[root]);


export const displayContent = (ctx, next) => {
    ctx.display = display;
    ctx.displayError = (message) => {
        document.querySelector('#errorBox span').textContent = message;
        document.querySelector('#errorBox').style.display = 'block';

        setTimeout(() => document.querySelector('#errorBox').style.display = 'none', 3000)
    }
    next();
}

export const saveUserStatus = (ctx, next) => {
    ctx.user = sessionService.getUser();
    next();
}

