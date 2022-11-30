import page from '../node_modules/page/page.mjs';
import { displayContent, saveUserStatus } from './middlewares/contextDecorator.js';
import { detailsView } from './views/details.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { logoutView } from './views/logout.js';
import { registerView } from './views/register.js';
import {createView } from './views/create.js';
import { editView } from './views/edit.js';
import { deleteView } from './views/delete.js';
import { navigationView } from './views/navigation.js';
import {myProfileView} from './views/myProfile.js';

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
page('/myProfile', myProfileView );
page.start();