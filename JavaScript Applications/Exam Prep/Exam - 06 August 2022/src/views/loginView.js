import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../services/userService.js';


const loginTemplate = (submitHandler) => html`


`

export const loginView = (ctx) => {
    const submitHandler = async (e) => {
        e.preventDefault();

        let {email, password} = Object.fromEntries(new FormData(e.target));

        if (email == '' || password == '') {
            return alert('All fields are required');
        }

        await login(email, password);
        ctx.page.redirect('/home');
    }

    ctx.display(loginTemplate(submitHandler))
}