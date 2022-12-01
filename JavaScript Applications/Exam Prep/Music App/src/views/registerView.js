import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';

const registerTemplate = (onSubmit) => html`
<section id="registerPage">
    <form @submit=${onSubmit}>
        <fieldset>
            <legend>Register</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <label for="conf-pass" class="vhide">Confirm Password:</label>
            <input id="conf-pass" class="conf-pass" name="conf-pass" type="password" placeholder="Confirm Password">

            <button type="submit" class="register">Register</button>

            <p class="field">
                <span>If you already have profile click <a href="#">here</a></span>
            </p>
        </fieldset>
    </form>
</section>

`

export const registerView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();

        let { email, password } = Object.fromEntries(new FormData(e.target));
        let rePass = new FormData(e.target).get('conf-pass');

        if (email == '' || password == '' || rePass == '') {
            return alert('All fields are required');
        }
        if (password !== rePass) {
            return alert('Passwords must match!');
        }

        await register(email, password);
        ctx.page.redirect('/home');
    }

    ctx.display(registerTemplate(onSubmit));
}