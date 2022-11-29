import page from '../node_modules/page/page.mjs';
import { saveUserStatus } from './middlewares/authMiddleware.js';
import { displayContent, displayNav } from './middlewares/renderMiddleware.js';
import { dashboardView } from './views/dashboard.js';
import { detailsView } from './views/details.js';
import { loginView } from './views/login.js';
import { registerView } from './views/register.js';
import {createView } from './views/create.js';
import { editView } from './views/edit.js';
import { myBooksView } from './views/myItems.js';

page(saveUserStatus);
page(displayNav);
page(displayContent);
page('/', dashboardView)
page('/login', loginView);
page('/register', registerView);
page('/dashboard', dashboardView);
page('/myBooks', myBooksView)
page('/details/:id', detailsView);
page('/create', createView);
page('/edit/:id', editView);
page.start();