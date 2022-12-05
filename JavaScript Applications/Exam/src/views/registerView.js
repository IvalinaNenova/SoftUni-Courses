import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';
import { formHandler } from '../utils/util.js';

const registerTemplate = (onSubmit) => html`
<section id="register">
        <div class="form">
          <h2>Register</h2>
          <form class="login-form" @submit=${onSubmit}>
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">register</button>
            <p class="message">Already registered? <a href="#">Login</a></p>
          </form>
        </div>
      </section>

`

export const registerView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();

        try {
            let data = formHandler(e);

            if (data.password !== data['re-password']) {
                throw new Error('Passwords must match!');
            }

            await register(data.email, data.password);
            ctx.page.redirect('/catalog'); 

        } catch (error) {
            alert(error.message);
        }
    }

    ctx.display(registerTemplate(onSubmit));
}