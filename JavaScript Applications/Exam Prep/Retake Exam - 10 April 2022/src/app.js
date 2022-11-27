import page from '../node_modules/page/page.mjs';
//import { saveUserStatus } from './middlewares/authMiddleware.js';
//import { displayContent, displayNavigation } from './middlewares/renderMiddleware.js';
import { catalogView } from './views/catalogView.js';
import { detailsView } from './views/detailsView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';
import {createView } from './views/createView.js';
import { editView } from './views/editView.js';
import { deleteView } from './views/deleteView.js';
import { myPostsView } from './views/myPostsView.js';
import { decorateContext } from './middlewares/contextDecorator.js';
import { addNavigation } from './middlewares/renderNavMiddleware.js';
import { navigationTemplate } from './views/navigationView.js';
import { getUser } from '../src/services/sessionService.js'

const headerElement = document.querySelector('.header-navigation'); 
const rootElement = document.querySelector('#main-content');

page( decorateContext(rootElement, headerElement, getUser)); // save user status and decorate render function
page(addNavigation(navigationTemplate));
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
page('/myPosts', myPostsView);
page.start();