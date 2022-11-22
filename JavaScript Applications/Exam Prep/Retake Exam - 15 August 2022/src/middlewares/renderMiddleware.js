import {render} from '../../node_modules/lit-html/lit-html.js';
import { navigationView } from '../views/navigationView.js';
const headerElement = document.querySelector('.header-navigation');
export const displayNavigation = (ctx, next) => {
    //TODO: Render navigation

    render(navigationView(), headerElement);
    next();
}