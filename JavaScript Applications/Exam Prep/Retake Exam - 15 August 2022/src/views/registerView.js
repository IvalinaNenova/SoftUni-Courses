import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';

const registerTemplate = (onSubmit) => html`
<section id="register">
    <div class="form">
        <h2>Register</h2>
        <form class="login-form" @submit=${onSubmit}>
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">login</button>
            <p class="message">Already registered? <a href="/login">Login</a></p>
        </form>
    </div>
</section>
`

export const registerView = (ctx) => {
    const onSubmit = async(e) => {
        e.preventDefault();

        let {email, password} = Object.fromEntries(new FormData(e.target));
        let rePass = new FormData(e.target).get('re-password');

        if (email == '' || password == '' || rePass == '') {
            return alert('All fields are required');
        }
        if (password !== rePass) {
            return alert('Passwords must match!');
        }

        await register(email, password);
        ctx.page.redirect('/catalog');
    }

    ctx.display(registerTemplate(onSubmit));
}