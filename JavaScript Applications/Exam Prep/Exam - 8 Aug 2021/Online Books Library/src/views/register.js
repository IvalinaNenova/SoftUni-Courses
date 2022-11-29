import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';

function registerTemplate (submitHandler) {
    return html`
<section id="register-page" class="register">
    <form id="register-form" action="" method="" @submit=${submitHandler}>
        <fieldset>
            <legend>Register Form</legend>
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
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
    </form>
</section>
`}

export function registerView(ctx) {
    async function submitHandler (e) {
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        console.log(data);

        if (Object.values(data).includes('')) {
            return alert('All fields must be provided');
        }
        if (data.password !== data['confirm-pass']) {
            return alert('Passwords don\'t match!');
        }
        let user = {
            email: data.email,
            password: data.password
        }
        await register(user);
        ctx.page.redirect('/dashboard');
    }

    ctx.render(registerTemplate(submitHandler));
}