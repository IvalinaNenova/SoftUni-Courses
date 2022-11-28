import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';


const loginTemplate = (submitHandler) => html`
<section id="form-login" class="view-section">
    <form id="login-form" class="text-center border border-light p-5" action="" method="" @submit=${submitHandler}>
        <div class="form-group">
            <label for="email">Email</label>
            <input id="email" type="email" class="form-control" placeholder="Email" name="email" value="" />
        </div>
        <div class="form-group">
            <label for="password">Password</label>
            <input id="password" type="password" class="form-control" placeholder="Password" name="password" value="" />
        </div>

        <button type="submit" class="btn btn-primary">Login</button>
    </form>
</section>
`

export const loginView = (ctx) => {
    const submitHandler = async (e) => {
        e.preventDefault();

        let { email, password } = Object.fromEntries(new FormData(e.target));

        if (email == '' || password == '') {
            return alert('All fields are required');
        }

        await login(email, password);
        ctx.page.redirect('/home');
    }

    ctx.display(loginTemplate(submitHandler))
}