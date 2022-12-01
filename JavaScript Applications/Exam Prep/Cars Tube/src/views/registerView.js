import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';
import { formHandler } from '../utils/util.js';

const registerTemplate = (onSubmit) => html`
<section id="register">
    <div class="container">
        <form id="register-form" @submit=${onSubmit}>
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>
</section>
`

export const registerView = (ctx) => {

    const onSubmit = async (e) => {

        try {
            let data = formHandler(e);
            if (data.password !== data.repeatPass) {
                return alert('Passwords must match!');
            }

            await register(data.username, data.password);
            ctx.page.redirect('/home');

        } catch (err) {}

    }

    ctx.display(registerTemplate(onSubmit));
}