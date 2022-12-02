import { logout } from '../services/userService.js';
import { deleteItem, addLike} from '../services/dataService.js';

export const logoutHandler = async (ctx) => {
    await logout();
    ctx.page.redirect('/home');
}

export const deleteHandler = async (ctx) => {
    await deleteItem(ctx.params.id);
    ctx.page.redirect('/');
}

// export const likeHandler = async (ctx) => {
//     console.log(ctx);
//     await addLike({theaterId : ctx.params.id});
//     document.querySelector('.btn-like').style.display = 'none';
//     let previous = document.querySelector('.likes').textContent.split(' ')[1];
//     document.querySelector('.likes').textContent = `Likes: ${Number(previous)+1}`;
//     //ctx.page.redirect(`/details/${ctx.params.id}`);
// }

export const formHandler = (e) => {
    e.preventDefault();

    let data = Object.fromEntries(new FormData(e.target));
    console.log(Object.values(data));
    if (Object.values(data).includes('')) {
        throw new Error('All fields are required');
    }

    return data;
}
