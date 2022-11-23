import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';


const loginTemplate = (submitHandler) => html`
<section id="login">
    <div class="form">
        <h2>Login</h2>
        <form class="login-form" @submit=${submitHandler}>
            <input type="text" name="email" id="email" placeholder="email" />
            <input type="password" name="password" id="password" placeholder="password" />
            <button type="submit">login</button>
            <p class="message">
                Not registered? <a href="/register">Create an account</a>
            </p>
        </form>
    </div>
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