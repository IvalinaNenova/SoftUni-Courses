import page from './node_modules/page/page.mjs'
import { loginView } from './views/login.js';
import { catalogView } from './views/catalog.js';
import { registerView } from './views/register.js';
import { logout } from './views/logout.js';
import { createView } from './views/create.js';
import { detailsView} from './views/details.js';
import { myFurnitureView } from './views/my-furniture.js';
import { editView } from './views/edit.js';
import { deleteView } from './views/delete.js';

page('/', '/catalog')
page('/login', loginView);
page('/catalog', catalogView);
page('/register', registerView);
page('/create', createView);
page('/details/:detailsId', detailsView);
page('/my-publications', myFurnitureView)
page('/edit/:detailsId', editView);
page('/delete/:detailsId', deleteView);
page.start()

document.querySelector('#logoutBtn').addEventListener('click', logout);
updateNav();
export function updateNav() {
    if (sessionStorage.getItem('token') != undefined) {
        document.querySelector('#user').style.display = 'inline-block';
        document.querySelector('#guest').style.display = 'none';
    } else {
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'inline-block';
    }
}