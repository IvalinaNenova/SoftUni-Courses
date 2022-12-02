import page from '../node_modules/page/page.mjs';
import { displayContent, getData, getSpecifics, saveUserProperties, saveUserStatus } from './middlewares/contextDecorator.js';
import { catalogView } from './views/catalogView.js';
import { detailsView } from './views/detailsView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutHandler } from './utils/util.js';
import { registerView } from './views/registerView.js';
import {createView } from './views/createView.js';
import { editView } from './views/editView.js';
import { deleteHandler } from './utils/util.js';
import { navigationView } from './views/navigationView.js';
//import {searchView} from './views/searchView.js';
import { myProfileView } from './views/myProfile.js';

page(saveUserStatus);
page(displayContent);
page(navigationView);
page('/', homeView)
page('/home', homeView);
page('/login/', loginView);
page('/logout/', logoutHandler);
page('/register', registerView);
page('/catalog', catalogView);
page('/details/:id', getData, getSpecifics, detailsView);
page('/create', createView);
page('/edit/:id', getData, editView);
page('/delete/:id', deleteHandler);
//page('/details/:id/like', likeHandler);
page('/myProfile', saveUserProperties, myProfileView )
//page('/search', searchView);
page.start();