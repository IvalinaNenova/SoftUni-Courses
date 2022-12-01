import { logout } from '../services/userService.js';
import { deleteItem } from '../services/dataService.js';

export const logoutView = async (ctx) => {
    await logout();
    ctx.page.redirect('/home');
}

export const deleteView = async (ctx) => {
    await deleteItem(ctx.params.id);
    ctx.page.redirect('/catalog');
}

export const formHandler = (e) => {
    e.preventDefault();

    let data = Object.fromEntries(new FormData(e.target));

    if (Object.values(data).includes('')) {
        return alert('All fields are required');
    }

    return data;
}
