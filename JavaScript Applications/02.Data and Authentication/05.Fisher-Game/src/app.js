console.log('TODO:// Implement Home functionality');
import page from '.././node_modules/page/page.mjs'
import {saveUserStatus} from '.././src/middlewares/authMiddleware.js';
import {displayContent, displayNavigation} from '.././src/middlewares/renderMiddleware.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';

page(saveUserStatus);
page(displayNavigation);
page(displayContent);
page('/', homeView)
page('/home', homeView)
page('/login', loginView)
page('/register', registerView)
page('/logout', logoutView)

page.start();

