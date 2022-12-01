import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';


const loginTemplate = (submitHandler) => html`
<section id="loginPage">
    <form @submit=${submitHandler}>
        <fieldset>
            <legend>Login</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <button type="submit" class="login">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </fieldset>
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