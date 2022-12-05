import { logout } from '../services/userService.js';
import { deleteItem } from '../services/dataService.js';

export const logoutHandler = async (ctx) => {
    await logout();
    ctx.page.redirect('/');
}

export const deleteHandler = async (ctx) => {
    if (confirm('Are you sure you want to delete?')){
        await deleteItem(ctx.params.id);
        ctx.page.redirect('/catalog');
    }
}

export const formHandler = (e) => {
    e.preventDefault();

    let data = Object.fromEntries(new FormData(e.target));
    console.log(Object.values(data));
    if (Object.values(data).includes('')) {
        throw new Error('All fields are required');
    }

    return data;
}