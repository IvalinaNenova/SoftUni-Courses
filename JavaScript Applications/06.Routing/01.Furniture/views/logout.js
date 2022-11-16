import page from '../node_modules/page/page.mjs';
import { updateNav } from '../app.js';

export async function onLogout(event){
    await fetch('http://localhost:3030/users/logout', {
        method: 'GET',
        headers: {
            'X-Authorization': sessionStorage.token
        }
    });

    sessionStorage.clear();
    updateNav();
    page.redirect('/catalog');
}