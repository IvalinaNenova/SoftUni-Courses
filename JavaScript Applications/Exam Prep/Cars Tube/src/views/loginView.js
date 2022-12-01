import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';
import { formHandler } from '../utils/util.js';


const loginTemplate = (submitHandler) => html`
<section id="login">
    <div class="container">
        <form id="login-form" action="#" method="post" @submit=${submitHandler}>
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>
`

export const loginHandler = (ctx) => {

    const submitHandler = async (e) => {

        try {
            let data = formHandler(e);
            await login(data.username, data.password);
            ctx.page.redirect('/home');
        } catch (err) {}
    }

    ctx.display(loginTemplate(submitHandler))
}