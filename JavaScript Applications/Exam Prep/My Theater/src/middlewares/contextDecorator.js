import {render} from '../../node_modules/lit-html/lit-html.js';
import * as api from '../services/dataService.js';
import * as sessionService from '../services/sessionService.js';


const roots = {
    header : document.querySelector('header'),
    main: document.querySelector('#content'),
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
export const getData = async (ctx, next) => {
    ctx.data = await api.getItem(ctx.params.id);
    next();
}
export const getSpecifics = async(ctx, next) => {
    ctx.isOwner = ctx.user?._id == ctx.data._ownerId;
    ctx.isLogged = Boolean(ctx.user);
    if (ctx.isLogged) { //this could be different depending on guest availability to like
        ctx.user.likes = await api.userLikes(ctx.data._id, ctx.user._id)
    }
    ctx.data.likes = await api.countTotal(ctx.data._id);

    next();
}

export const saveUserProperties = async(ctx, next) => {
    const userListings = await api.getMyListings(ctx.user._id);
    ctx.data = userListings;

    next();
}

