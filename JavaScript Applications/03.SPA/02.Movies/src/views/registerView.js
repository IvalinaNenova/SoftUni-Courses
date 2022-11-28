import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';

const registerTemplate = (onSubmit) => html`
<section id="form-sign-up" class="view-section">
    <form id="register-form" class="text-center border border-light p-5" action="" method="" @submit=${onSubmit}>
        <div class="form-group">
            <label for="email">Email</label>
            <input id="email" type="email" class="form-control" placeholder="Email" name="email" value="" />
        </div>
        <div class="form-group">
            <label for="password">Password</label>
            <input id="password" type="password" class="form-control" placeholder="Password" name="password" value="" />
        </div>

        <div class="form-group">
            <label for="repeatPassword">Repeat Password</label>
            <input id="repeatPassword" type="password" class="form-control" placeholder="Repeat-Password"
                name="repeatPassword" value="" />
        </div>

        <button type="submit" class="btn btn-primary">Register</button>
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
        if (password.length < 6 ) {
            return alert('Password must be at least 6 characters');
        }
        if (password !== repeatPassword) {
            return alert('Passwords must match!');
        }

        await register(email, password);
        ctx.page.redirect('/home');
    }

    ctx.display(registerTemplate(onSubmit));
}