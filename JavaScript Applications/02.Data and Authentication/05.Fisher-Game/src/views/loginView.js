import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';


const loginTemplate = (submitHandler) => html`
<section id="login-view">
    <h2>Login</h2>
    <form id="login" @submit=${submitHandler}>
        <label>Email: <input type="text" name="email"></label>
        <label>Password: <input type="password" name="password"></label>
        <p class="notification"></p>
        <button>Login</button>
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
        ctx.page.redirect('/');
    }

    ctx.display(loginTemplate(submitHandler))
}