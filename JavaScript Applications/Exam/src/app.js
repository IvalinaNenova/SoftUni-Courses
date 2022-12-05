import page from '../node_modules/page/page.mjs';
import { displayContent, getData, getSpecifics, saveUserStatus } from './middlewares/contextDecorator.js';
import { catalogView } from './views/catalogView.js';
import { detailsView } from './views/detailsView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import {createView } from './views/createView.js';
import { editView } from './views/editView.js';
import { navigationView } from './views/navigationView.js';

import { logoutHandler, deleteHandler } from './utils/util.js';

page(saveUserStatus);
page(displayContent);
page(navigationView);
page('/', homeView)
page('/home', homeView);
page('/login', loginView);
page('/logout', logoutHandler);
page('/register', registerView);
page('/catalog', catalogView);
page('/details/:id', getData, getSpecifics, detailsView);
page('/create', createView);
page('/edit/:id', getData, editView);
page('/delete/:id', deleteHandler);
page.start();