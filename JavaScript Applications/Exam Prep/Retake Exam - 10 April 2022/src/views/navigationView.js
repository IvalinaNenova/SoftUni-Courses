import { html } from '../../node_modules/lit-html/lit-html.js';

const userLinks = html`
<div id="user">
    <a href="/myPosts">My Posts</a>
    <a href="/create">Create Post</a>
    <a href="/logout">Logout</a>
</div>
`

const guestLinks = html`
<div id="guest">
    <a href="login">Login</a>
    <a href="register">Register</a>
</div>
`

export const navigationTemplate = (user) => html`
<!-- Navigation -->
<h1><a href="/">Orphelp</a></h1>

<nav>
    <a href="/catalog">Dashboard</a>

    ${user
    ? userLinks
    : guestLinks
    }
</nav>
`