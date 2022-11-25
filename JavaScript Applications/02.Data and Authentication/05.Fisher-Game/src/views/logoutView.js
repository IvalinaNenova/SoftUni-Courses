import { logout } from '../services/userService.js';
import { homeView } from './homeView.js';

export const logoutView = async (ctx) => {
console.log('logout');

    await logout();
    ctx.page.redirect('/');
}
