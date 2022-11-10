import {register} from '../api/api.js';
let section = document.querySelector('#registerPage');
section.remove();

let ctx = null;
export function showRegister(context){
    ctx = context;
    context.showSection(section);
}

let form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

async function onSubmit(e){
    e.preventDefault();

    let formData = new FormData(form);
    let email = formData.get('email').trim();
    let password = formData.get('password').trim();
    let repeatPassword = formData.get('repeatPassword').trim();

    if (!email || !password) {
        return alert('All fields are required');
    }

    if (password !== repeatPassword) {
        return alert ('Passwords must match');
    }

    await register(email, password);
    form.reset();
    ctx.goTo('home');
    ctx.updateNav();
}