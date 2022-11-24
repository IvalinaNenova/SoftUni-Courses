import { html } from '../../node_modules/lit-html/lit-html.js';
import { myPosts } from '../services/dataService.js';
import {cardTemplate} from './catalogView.js';

const myPostsTemplate = (myPosts) => html`
<section id="my-posts-page">
    <h1 class="title">My Posts</h1>

    <!-- Display a div with information about every post (if any)-->
    <div class="my-posts">
        ${myPosts.length > 0 
        ? myPosts.map(post => cardTemplate(post))
        : html`<h1 class="title no-posts-title">You have no posts yet!</h1>`}
    </div>
    
</section>
`

export const myPostsView = async (ctx) => {
    let posts = await myPosts(ctx.user._id)

    ctx.display(myPostsTemplate(posts));
}