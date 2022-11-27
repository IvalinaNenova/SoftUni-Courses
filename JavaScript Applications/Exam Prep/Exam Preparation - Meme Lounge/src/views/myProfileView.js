import { html } from '../../node_modules/lit-html/lit-html.js';
import { getUserMemes } from '../services/dataService.js';

const memeCard = (x) => html`
    <div class="user-meme">
        <p class="user-meme-title">${x.title}</p>
        <img class="userProfileImage" alt="meme-img" src="${x.imageUrl}">
        <a class="button" href="/details/${x._id}">Details</a>
    </div>`


const myProfileTemplate = (result, user) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/${user.gender}.png">
        <div class="user-content">
            <p>Username: ${user.username}</p>
            <p>Email: ${user.email}</p>
            <p>My memes count: ${result.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">

       ${result.length > 0 
        ? result.map(memeCard)
        : html`<p class="no-memes">No memes in database.</p>`}

    </div>
</section>
`

export const myProfileView = async (ctx) => {
    let results = await getUserMemes(ctx.user._id);
    console.log(ctx.user);
    ctx.display(myProfileTemplate(results, ctx.user))
}