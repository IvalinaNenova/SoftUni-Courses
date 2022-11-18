import page from '../node_modules/page/page.mjs';
import { updateNav } from '../app.js';
import { onLogout } from '../api.js';

export async function logout(e) {
    e.preventDefault();

    await onLogout();
    sessionStorage.clear();
    page.redirect('/catalog');
    updateNav();
}