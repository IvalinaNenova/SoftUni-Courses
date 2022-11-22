import { html } from '../../node_modules/lit-html/lit-html.js';
let isAuthenticated = null;

const userLinks = html`
<div class="user">
        <a href="#">Add Pair</a>
        <a href="#">Logout</a>
    </div>
`

const guestLinks = html`
<div class="guest">
        <a href="#">Login</a>
        <a href="#">Register</a>
    </div>
`

const navigationTemplate = () => html`
<!-- Navigation -->
<a id="logo" href="/"><img id="logo-img" src="./images/logo.png" alt="" /></a>
<nav>
    <div>
        <a href="#">Dashboard</a>
        <a href="#">Search</a>
    </div>
    
    ${isAuthenticated
        ?userLinks
        : guestLinks
    }

</nav>
`

export const navigationView = (ctx) => {
    return navigationTemplate();
}