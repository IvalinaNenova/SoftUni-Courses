import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';
import { formHandler } from '../utils/util.js';

const registerTemplate = (onSubmit) => html`
<section id="registerPage">
    <form class="registerForm" @submit=${onSubmit}>
        <h2>Register</h2>
        <div class="on-dark">
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
        </div>

        <div class="on-dark">
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" placeholder="********" value="">
        </div>

        <div class="on-dark">
            <label for="repeatPassword">Repeat Password:</label>
            <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
        </div>

        <button class="btn" type="submit">Register</button>

        <p class="field">
            <span>If you have profile click <a href="#">here</a></span>
        </p>
    </form>
</section>
`

export const registerView = (ctx) => {

    const onSubmit = async (e) => {

        try {
            let data = formHandler(e);
            if (data.password !== data.repeatPassword) {
                return alert('Passwords must match!');
            }

            await register(data.email, data.password);
            ctx.page.redirect('/');

        } catch (err) { }

    }

    ctx.display(registerTemplate(onSubmit));
}