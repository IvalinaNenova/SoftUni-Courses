import { homeView } from './views/home.js';
import page from './node_modules/page/page.mjs'
import { detailsView } from './views/details.js';

document.querySelector('#homeBtn').addEventListener('click', homeView);
homeView();