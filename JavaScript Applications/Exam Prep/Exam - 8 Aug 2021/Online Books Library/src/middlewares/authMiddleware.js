import * as sessionService from '../services/authService.js';

export function saveUserStatus(ctx, next){
    ctx.user = sessionService.getUser();
    next();
}