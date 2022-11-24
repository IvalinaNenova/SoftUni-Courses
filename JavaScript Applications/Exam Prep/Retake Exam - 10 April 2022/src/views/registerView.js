import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';

const registerTemplate = (onSubmit) => html`
<section id="register-page" class="auth">
    <form id="register" @submit=${onSubmit}>
        <h1 class="title">Register</h1>

        <article class="input-group">
            <label for="register-email">Email: </label>
            <input type="email" id="register-email" name="email">
        </article>

        <article class="input-group">
            <label for="register-password">Password: </label>
            <input type="password" id="register-password" name="password">
        </article>

        <article class="input-group">
            <label for="repeat-password">Repeat Password: </label>
            <input type="password" id="repeat-password" name="repeatPassword">
        </article>

        <input type="submit" class="btn submit-btn" value="Register">
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
        ctx.page.redirect('/catalog');
    }

    ctx.display(registerTemplate(onSubmit));
}