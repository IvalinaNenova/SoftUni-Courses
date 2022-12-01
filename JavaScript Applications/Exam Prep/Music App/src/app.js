import page from '../node_modules/page/page.mjs';
import { displayContent, ownerStatus, saveUserStatus } from './middlewares/contextDecorator.js';
import { catalogView } from './views/catalogView.js';
import { detailsView } from './views/detailsView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';
import {createView } from './views/createView.js';
import { editView } from './views/editView.js';
import { deleteView } from './views/deleteView.js';
import { navigationView } from './views/navigationView.js';
import {searchView} from './views/searchView.js';

page(saveUserStatus);
page(displayContent);
page(navigationView);
page('/', homeView)
page('/home', homeView);
page('/login', loginView);
page('/logout', logoutView);
page('/register', registerView);
page('/catalog', catalogView);
page('/details/:id', ownerStatus, detailsView);
page('/create', createView);
page('/edit/:id', ownerStatus, editView);
page('/delete/:id', deleteView);
page('/search', searchView);
page.start();