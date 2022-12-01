import { html } from '../../node_modules/lit-html/lit-html.js';
const userLinks = (ctx) => html`
<div id="profile">
    <a>Welcome ${ctx.user.username}</a>
    <a href="/myProfile">My Listings</a>
    <a href="/create">Create Listing</a>
    <a href="/logout">Logout</a>
</div>
`

const guestLinks = html`
<div id="guest">
    <a href="/login">Login</a>
    <a href="/register">Register</a>
</div>
`

const navigationTemplate = (ctx) => html`
<nav>
    <a class="active" href="/">Home</a>
    <a href="/catalog">All Listings</a>
    <a href="/search">By Year</a>

    ${ctx.user? userLinks(ctx) : guestLinks}
</nav>
`

export const navigationView = (ctx, next) => {
    ctx.display(navigationTemplate(ctx), 'header');
    console.log(ctx.user);
    next();
}
