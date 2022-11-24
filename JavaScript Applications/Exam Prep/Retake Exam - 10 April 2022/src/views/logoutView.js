import { logout } from '../services/userService.js';

export const logoutView = async (ctx) => {
    await logout();
    ctx.page.redirect('/home');
}
