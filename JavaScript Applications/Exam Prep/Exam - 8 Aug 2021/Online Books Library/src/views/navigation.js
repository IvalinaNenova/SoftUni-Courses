import { html } from '../../node_modules/lit-html/lit-html.js';
import { logout } from '../services/userService.js';

function users(user, onLogout) {
    return html`
<div id="user">
    <span>Welcome, ${user.email}</span>
    <a class="button" href="/myBooks">My Books</a>
    <a class="button" href="/create">Add Book</a>
    <a class="button" href="#" @click=${onLogout}>Logout</a>
</div>
`}

const guests = html`
<div id="guest">
    <a class="button" href="/login">Login</a>
    <a class="button" href="/register">Register</a>
</div>
`

function navigationTemplate(user, onLogout) {
    return html`
<!-- Navigation -->
<nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/dashboard">Dashboard</a>

        ${user ? users(user, onLogout) : guests}

    </section>
</nav>
`}

export function navigationView(ctx) {

    async function onLogout (e) {
        e.preventDefault();

        await logout();
        ctx.page.redirect('/dashboard');
    }

    return navigationTemplate(ctx.user, onLogout);
}
