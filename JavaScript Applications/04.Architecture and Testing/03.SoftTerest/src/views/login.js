import {login} from '../api/api.js';
let section = document.querySelector('#loginPage');
section.remove();

let ctx = null;
export function showLogin(context){
    ctx = context;
    context.showSection(section);
}

const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

async function onSubmit(e){
    e.preventDefault();

    let formData = new FormData(form);
    let email = formData.get('email').trim();
    let password = formData.get('password').trim();

    await login(email, password);
    form.reset();
    ctx.updateNav();
    ctx.goTo('home');
}