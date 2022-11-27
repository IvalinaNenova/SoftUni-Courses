import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';

const registerTemplate = (onSubmit) => html`
<section id="registerPage">
    <form class="registerForm" @submit=${onSubmit}>
        <img src="./images/logo.png" alt="logo" />
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
            <span>If you have profile click <a href="/login">here</a></span>
        </p>
    </form>
</section>
`

export const registerView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();

        let { email, password, repeatPassword } = Object.fromEntries(new FormData(e.target));

        if (email == '' || password == '' || repeatPassword == '') {
            return alert('All fields are required');
        }
        if (password !== repeatPassword) {
            return alert('Passwords must match!');
        }

        await register(email, password);
        ctx.page.redirect('/home');
    }

    ctx.display(registerTemplate(onSubmit));
}