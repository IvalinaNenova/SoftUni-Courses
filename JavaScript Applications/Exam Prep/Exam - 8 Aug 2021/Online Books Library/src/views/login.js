import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';


function loginTemplate(submitHandler) {
    return html`
<section id="login-page" class="login">
    <form id="login-form" action="" method="" @submit=${submitHandler}>
        <fieldset>
            <legend>Login Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Login">
        </fieldset>
    </form>
</section>
`}

export function loginView(ctx) {

    async function submitHandler(e) {
        e.preventDefault();

        let form = e.target;
        let data = Object.fromEntries(new FormData(form));
        console.log(data);

        if (data.email == '' || data.password == '') {
            return alert('All fields must be entered');
        }

        await login(data);
        ctx.page.redirect('/dashboard');
    }

    ctx.render(loginTemplate(submitHandler));
}