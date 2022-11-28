import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';


const loginTemplate = (submitHandler) => html`
<section id="login-page" class="auth">
    <form id="login" @submit=${submitHandler}>

        <div class="container">
            <div class="brand-logo"></div>
            <h1>Login</h1>
            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

            <label for="login-pass">Password:</label>
            <input type="password" id="login-password" name="password">
            <input type="submit" class="btn submit" value="Login">
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </div>
    </form>
</section>
`

export const loginView = (ctx) => {
    const submitHandler = async (e) => {
        e.preventDefault();

        let { email, password } = Object.fromEntries(new FormData(e.target));

        if (email == '' || password == '') {
            return alert('All fields are required');
        }

        await login(email, password);
        ctx.page.redirect('/home');
    }

    ctx.display(loginTemplate(submitHandler))
}