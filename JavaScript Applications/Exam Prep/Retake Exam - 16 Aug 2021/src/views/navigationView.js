import { html } from '../../node_modules/lit-html/lit-html.js';

const userLinks = html`
<div id="user">
    <a href="/create">Create Game</a>
    <a href="/logout">Logout</a>
</div>
`

const guestLinks = html`
<div id="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>
`

const navigationTemplate = (user) => html`
<!-- Navigation -->
<h1><a class="home" href="/">GamesPlay</a></h1>
<nav>
    <a href="/catalog">All games</a>
    
    ${user
    ? userLinks
    : guestLinks}

</nav>
`

export const navigationView = (ctx, next) => {
    ctx.display(navigationTemplate(ctx.user), 'header');
    next();
}
