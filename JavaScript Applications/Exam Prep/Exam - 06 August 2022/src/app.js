import page from '../node_modules/page/page.mjs';
import { saveUserStatus } from './middlewares/authMiddleware.js';
import { displayContent, displayNavigation } from './middlewares/renderMiddleware.js';
import { catalogView } from './views/catalogView.js';
import { detailsView } from './views/detailsView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';
import {createView } from './views/createView.js';
import { editView } from './views/editView.js';
import { deleteView } from './views/deleteView.js';

page(saveUserStatus);
page(displayNavigation);
page(displayContent);
page('/', homeView)
page('/home', homeView);
page('/login', loginView);
page('/logout', logoutView);
page('/register', registerView);
page('/catalog', catalogView);
page('/details/:id', detailsView);
page('/create', createView);
page('/edit/:id', editView);
page('/delete/:id', deleteView);
page.start();