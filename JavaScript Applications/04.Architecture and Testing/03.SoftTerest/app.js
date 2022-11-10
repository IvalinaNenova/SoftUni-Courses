import './src/api/api.js';
import { showHome } from './src/views/home.js';
import { showLogin } from './src/views/login.js';
import { showRegister } from './src/views/register.js';
import { showCatalog } from './src/views/catalog.js';
import { showCreate } from './src/views/create.js';
import { showDetails } from './src/views/details.js';

let main = document.querySelector('main');

let links = {
    'homeLink': 'home',
    'getStartedLink': 'home',
    'loginLink': 'login',
    'registerLink': 'register',
    'createLink': 'create',
    'catalogLink': 'catalog',
    'detailsLink': 'details'
}

let views = {
    'home': showHome,
    'login': showLogin,
    'register': showRegister,
    'catalog': showCatalog,
    'create': showCreate,
    'details': showDetails,
}

let nav = document.querySelector('nav');
nav.addEventListener('click', onNavigation);

function onNavigation(e) {
    e.preventDefault();
    let name = links[e.target.id];
    console.log(e.target.id);
    goto(name);
    console.log(name);
}

function goto(name, ...params) {
    let view = views[name];
    view(context, ...params);
}
let context = {
    showSection
}

function showSection(name) {
    main.replaceChildren(name);
}
updateNav()
function updateNav() {
    let userData = JSON.parse(sessionStorage.getItem('userData'));

    if (userData != null) {
        [...nav.querySelectorAll('.user')].forEach(l => l.style.display = 'block');
        [...nav.querySelectorAll('.guest')].forEach(l => l.style.display = 'none');
    } else {
        [...nav.querySelectorAll('.user')].forEach(l => l.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(l => l.style.display = 'block');
    }
}

