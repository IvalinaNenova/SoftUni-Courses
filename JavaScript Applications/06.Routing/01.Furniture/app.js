import page from './node_modules/page/page.mjs'
import { loginView } from './views/login.js';
import { catalogView } from './views/catalog.js';
import { registerView } from './views/register.js';
import { onLogout } from './views/logout.js';
import { createView } from './views/create.js';
import { detailsView} from './views/details.js';

page('/login', loginView);
page('/catalog', catalogView);
page('/register', registerView);
page('/create', createView);
page('/details/:detailsId', detailsView);
page.start()

document.querySelector('#logoutBtn').addEventListener('click', onLogout);

export function updateNav() {
    if (sessionStorage.getItem('token') != null) {
        document.querySelector('#user').style.display = 'inline';
        document.querySelector('#guest').style.display = 'none';
    } else {
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'inline';
    }
}
updateNav();


