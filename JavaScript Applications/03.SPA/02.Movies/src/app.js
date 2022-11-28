import page from '../node_modules/page/page.mjs';
import { displayContent, saveUserStatus } from './middlewares/contextDecorator.js';
import { detailsView } from './views/detailsView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';
import {createView } from './views/createView.js';
import { editView } from './views/editView.js';
import { deleteView } from './views/deleteView.js';
import { navigationView } from './views/navigationView.js';

page(saveUserStatus);
page(displayContent);
page(navigationView);
page('/', homeView)
page('/home', homeView);
page('/login', loginView);
page('/logout', logoutView);
page('/register', registerView);
page('/details/:id', detailsView);
page('/create', createView);
page('/edit/:id', editView);
page('/delete/:id', deleteView);
page.start();