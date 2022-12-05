import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';
import { formHandler } from '../utils/util.js';


const loginTemplate = (submitHandler) => html`
<section id="login">
    <div class="form" @submit=${submitHandler}>
        <h2>Login</h2>
        <form class="login-form">
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

        try {
            let data = formHandler(e);

            await login(data.email, data.password);
            ctx.page.redirect('/catalog');
        } catch (error) {
            alert(error.message);
        }

    }

    ctx.display(loginTemplate(submitHandler))
}