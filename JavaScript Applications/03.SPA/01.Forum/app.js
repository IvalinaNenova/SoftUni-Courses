import { homeView } from './views/home.js';
import page from './node_modules/page/page.mjs'

page('/', homeView);
page.start();