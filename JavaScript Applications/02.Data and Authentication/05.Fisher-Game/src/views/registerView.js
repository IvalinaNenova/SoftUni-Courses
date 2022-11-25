import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';

const registerTemplate = (onSubmit) => html`
<section id="register-view">
    <h2>Register</h2>
    <form id="register" @submit=${onSubmit}>
        <label>Email: <input type="text" name="email"></label>
        <label>Password: <input type="password" name="password"></label>
        <label>Repeat: <input type="password" name="rePass"></label>
        <p class="notification"></p>
        <button>Register</button>
    </form>
</section>
`

export const registerView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();

        let { email, password, rePass } = Object.fromEntries(new FormData(e.target));

        if (email == '' || password == '' || rePass == '') {
            return alert('All fields are required');
        }
        if (password !== rePass) {
            return alert('Passwords must match!');
        }

        await register(email, password);
        ctx.page.redirect('/home');
    }

    ctx.display(registerTemplate(onSubmit));
}