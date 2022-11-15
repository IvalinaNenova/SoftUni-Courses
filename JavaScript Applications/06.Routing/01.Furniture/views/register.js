import page from '../node_modules/page/page.mjs';
import { html, render } from '../node_modules/lit-html/lit-html.js';
import { updateNav } from '../app.js';

function registerTemplate() {
    return html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Register New User</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    <form @submit=${onSubmit}>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="email">Email</label>
                    <input class="form-control" id="email" type="text" name="email">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="password">Password</label>
                    <input class="form-control" id="password" type="password" name="password">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="rePass">Repeat</label>
                    <input class="form-control" id="rePass" type="password" name="rePass">
                </div>
                <input type="submit" class="btn btn-primary" value="Register" />
            </div>
        </div>
    </form>
    `
}

async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);
    let email = formData.get('email');
    let password = formData.get('password');
    let repeatPassword = formData.get('rePass');


    try {
        if (password != repeatPassword) {
            throw new Error('Passwords must match');
        }

        let response = await fetch('http://localhost:3030/users/register', {
            method: 'POST',
            body: JSON.stringify({ email, password })
        })

        let result = await response.json();
        sessionStorage.setItem('token', result.accessToken);
        sessionStorage.setItem('ownerId', result._id);
        updateNav();
        page.redirect('/catalog')

    } catch (error) {
        alert(error.message)
    }
}

export function registerView(ctx) {
    render(registerTemplate(), document.querySelector('.container'));
}