import { html } from '../../node_modules/lit-html/lit-html.js';

const userLinks = html`
<div class="user">
    <a href="/create">Create Offer</a>
    <a href="/logout">Logout</a>
</div>
`

const guestLinks = html`
<div class="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>
`

const navigationTemplate = (user) => html`
<a id="logo" href="/"><img id="logo-img" src="./images/logo.jpg" alt="" /></a>
<nav>
    <div>
        <a href="/catalog">Dashboard</a>
    </div>
    ${user
    ? userLinks
    : guestLinks
    }
</nav>
`

export const navigationView = (ctx) => {
    return navigationTemplate(ctx.user);
}