import { html } from '../../node_modules/lit-html/lit-html.js';

const userLinks = (user) => html`
<li class="nav-item user">
    <a class="nav-link" id="welcome-msg">Welcome, ${user.email}</a>
</li>
<li class="nav-item user">
    <a class="nav-link" href="/logout">Logout</a>
</li>
`

const guestLinks = html`
<li class="nav-item guest">
    <a class="nav-link" href="/login">Login</a>
</li>
<li class="nav-item guest">
    <a class="nav-link" href="/register">Register</a>
</li>
`

const navigationTemplate = (user) => html`
<a class="navbar-brand text-light" href="/">Movies</a>
<ul class="navbar-nav ml-auto">

    ${user
    ? userLinks(user)
    : guestLinks}

</ul>
`

export const navigationView = (ctx, next) => {
    ctx.display(navigationTemplate(ctx.user), 'header');
    next();
}
