import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../services/userService.js';

const registerTemplate = (onSubmit) => html`


`

export const registerView = (ctx) => {
    const onSubmit = async(e) => {
        e.preventDefault();

        let {email, password} = Object.fromEntries(new FormData(e.target));
        let rePass = new FormData(e.target).get('re-password');

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