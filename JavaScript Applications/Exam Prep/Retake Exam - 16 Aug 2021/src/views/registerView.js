import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';

const registerTemplate = (onSubmit) => html`
<section id="register-page" class="content auth">
    <form id="register" @submit=${onSubmit}>
        <div class="container">
            <div class="brand-logo"></div>
            <h1>Register</h1>

            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="maria@email.com">

            <label for="pass">Password:</label>
            <input type="password" name="password" id="register-password">

            <label for="con-pass">Confirm Password:</label>
            <input type="password" name="confirm-password" id="confirm-password">

            <input class="btn submit" type="submit" value="Register">

            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
        </div>
    </form>
</section>
`

export const registerView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();

        let {email, password} = Object.fromEntries(new FormData(e.target));
        let rePass = new FormData(e.target).get('confirm-password');

        if (email == '' || password == '') {
            return alert('All fields are required');
        }
        if (password !== rePass) {
            return alert('Passwords must match!');
        }
        await register({email, password});
        ctx.page.redirect('/home');
    }

    ctx.display(registerTemplate(onSubmit));
}