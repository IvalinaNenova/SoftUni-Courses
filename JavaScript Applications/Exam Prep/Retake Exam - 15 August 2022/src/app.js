import page from '../node_modules/page/page.mjs';
import { displayNavigation } from './middlewares/renderMiddleware.js';


page(displayNavigation)
page.start();