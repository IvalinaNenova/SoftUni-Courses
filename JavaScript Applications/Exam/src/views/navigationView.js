import { html } from '../../node_modules/lit-html/lit-html.js';

const userLinks = html`
<div class="user">
    <a href="/create">Add Album</a>
    <a href="/logout">Logout</a>
</div>
`

const guestLinks = html`
<div class="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>
`

const navigationTemplate = (ctx) => html`
<!-- Navigation -->
<a id="logo" href="/"><img id="logo-img" src="./images/logo.png" alt="" /></a>

<nav>
    <div>
        <a href="/catalog">Dashboard</a>
    </div>

    ${ctx.user? userLinks : guestLinks}

</nav>
`

export const navigationView = (ctx, next) => {
    ctx.display(navigationTemplate(ctx), 'header');
    next();
}
