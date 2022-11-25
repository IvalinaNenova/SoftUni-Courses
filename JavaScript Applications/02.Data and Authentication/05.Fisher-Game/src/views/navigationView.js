import { html } from '../../node_modules/lit-html/lit-html.js';

const userLinks = html`
<div id="user">
    <a id="logout" href="/logout">Logout</a>
</div>
`

const guestLinks = html`
<div id="guest">
    <a id="login" href="/login">Login</a>
    <a id="register" href="/register">Register</a>
</div>
`

const navigationTemplate = (user) => html`
<!-- Navigation -->
<h1>Biggest Catch</h1>
<nav>
    <a id="home" class="active" href="/home">Home</a>

    ${user
    ? userLinks
    : guestLinks}

    <p class="email">Welcome, <span>${user? user.username : 'guest'}</span></p>
</nav>
`

export const navigationView = (ctx) => {
    return navigationTemplate(ctx.user);
}