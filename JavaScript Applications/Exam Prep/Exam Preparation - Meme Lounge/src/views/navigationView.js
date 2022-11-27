import { html } from '../../node_modules/lit-html/lit-html.js';

const userLinks = html`
<div class="user">
        <a href="/create">Create Meme</a>
        <div class="profile">
            <span>Welcome, {email}</span>
            <a href="/myProfile">My Profile</a>
            <a href="/logout">Logout</a>
        </div>
    </div>
`

const guestLinks = html`
<div class="guest">
    <div class="profile">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>
    <a class="active" href="/home">Home Page</a>
</div>
`

const navigationTemplate = (user) => html`

    <a href="/catalog">All Memes</a>
   
    ${user 
    ? userLinks
    : guestLinks}


`

export const navigationView = (ctx, next) => {
    ctx.display(navigationTemplate(ctx.user), 'header');
    next();
}