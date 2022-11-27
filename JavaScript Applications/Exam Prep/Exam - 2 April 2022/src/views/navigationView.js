import { html } from '../../node_modules/lit-html/lit-html.js';

const userLinks = html`
<!--Only Users-->
<li><a href="/create">Create Postcard</a></li>
<li><a href="/logout">Logout</a></li>
`

const guestLinks = html`
<!--Only Guest-->
<li><a href="/login">Login</a></li>
<li><a href="/register">Register</a></li>
`

const navigationTemplate = (user) => html`
<nav>
    <section class="logo">
        <img src="./images/logo.png" alt="logo">
    </section>
    <ul>
        <!--Users and Guest-->
        <li><a href="/home">Home</a></li>
        <li><a href="/catalog">Dashboard</a></li>

        ${user? userLinks : guestLinks}


    </ul>
</nav>
`

export const navigationView = (ctx, next) => {
    ctx.display(navigationTemplate(ctx.user), 'header');
    next();
}