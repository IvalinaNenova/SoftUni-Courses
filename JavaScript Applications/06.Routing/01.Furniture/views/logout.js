import page from '../node_modules/page/page.mjs';
import { updateNav } from '../app.js';

export async function onLogout(event){
    await fetch('http://localhost:3030/users/logout', {
        method: 'POST',
        headers: {
            'X-Authorization': sessionStorage.token
        }
    });

    sessionStorage.clear();
    updateNav();
    page.redirect('/catalog');
}