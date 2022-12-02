import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';
import { formHandler } from '../utils/util.js';


const loginTemplate = (submitHandler) => html`
<section id="loginaPage">
    <form class="loginForm" @submit=${submitHandler}>
        <h2>Login</h2>
        <div>
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
        </div>
        <div>
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" placeholder="********" value="">
        </div>

        <button class="btn" type="submit">Login</button>

        <p class="field">
            <span>If you don't have profile click <a href="/register">here</a></span>
        </p>
    </form>
</section>
`

export const loginView = (ctx) => {

    const submitHandler = async (e) => {
        console.log('log');
        try {
            let data = formHandler(e);
            await login(data.email, data.password);
            ctx.page.redirect('/');
        } catch (err) {
            alert(err.message);
         }
    }

    ctx.display(loginTemplate(submitHandler))
}