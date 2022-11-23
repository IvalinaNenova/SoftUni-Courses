import * as sessionService from '.././services/sessionService.js';

export const saveUserStatus = (ctx, next) => {
    ctx.user = sessionService.getUser();
    next();
}