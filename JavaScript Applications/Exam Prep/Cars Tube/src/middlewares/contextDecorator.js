import {render} from '../../node_modules/lit-html/lit-html.js';
import { getItem, getMyListings } from '../services/dataService.js';
import * as sessionService from '../services/sessionService.js';

const roots = {
    header : document.querySelector('header'),
    main: document.querySelector('#site-content'),
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

export const ownerStatus = async(ctx, next) => {
    let data = await getItem(ctx.params.id);
    ctx.isOwner = ctx.user?._id == data._ownerId;
    ctx.data = data;

    next();
}

export const saveUserProperties = async(ctx, next) => {
    const userListings = await getMyListings(ctx.user._id);
    ctx.data = userListings;

    next();
}