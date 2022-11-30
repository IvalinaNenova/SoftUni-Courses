import { html } from '../../node_modules/lit-html/lit-html.js';

const userLinks = html`
<li><a href="/myProfile">Profile</a></li>
<li><a href="/create">Create Event</a></li>
<li><a href="/logout">Logout</a></li>
`

const guestLinks = html`
<li><a href="/login">Login</a></li>
<li><a href="/register">Register</a></li>
`

const navigationTemplate = (user) => html`
<nav>
    <a href="/home">Theater</a>
    <ul>
        ${user? userLinks : guestLinks}

    </ul>
</nav>
`

export const navigationView = (ctx, next) => {
    ctx.display(navigationTemplate(ctx.user), 'header');
    next();
}
