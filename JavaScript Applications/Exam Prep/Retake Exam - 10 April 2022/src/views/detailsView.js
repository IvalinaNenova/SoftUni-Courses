import { html } from '../../node_modules/lit-html/lit-html.js';
import { donate, getCount, getItem, getUserDonations } from '../services/dataService.js';

const detailsTemplate = (post, user, onDonate, count, userDonations ) => html`
<section id="details-page">
    <h1 class="title">Post Details</h1>

    <div id="container">
        <div id="details">
            <div class="image-wrapper">
                <img src="${post.imageUrl}" alt="Material Image" class="post-image">
            </div>
            <div class="info">
                <h2 class="title post-title">${post.title}</h2>
                <p class="post-description">Description: ${post.description}</p>
                <p class="post-address">Address: ${post.address}</p>
                <p class="post-number">Phone number: ${post.phone}</p>
                <p class="donate-Item">Donate Materials: ${count}</p>

                <!--Edit and Delete are only for creator-->
                ${user && user._id == post._ownerId
                    ? html`<div class="btns">
                    <a href="/edit/${post._id}" class="edit-btn btn">Edit</a>
                    <a href="/delete/${post._id}" class="delete-btn btn">Delete</a>
                    </div>`
                    : null}

                ${userDonations == 0 && user._id != post._ownerId 
                ? html`<div class="btns">
                    <a @click=${onDonate} href="#" class="donate-btn btn">Donate</a>
                </div>`
                : null}

            </div>
        </div>
    </div>
</section>
`

export const detailsView = async (ctx) => {
    let post = await getItem(ctx.params.id);
    let countDonations = await getCount(post._id);
    let userDonations;

    if (ctx.user) {
        userDonations = await getUserDonations(post._id, ctx.user._id);
    }

    const onDonate = async (e) => {
        e.preventDefault();

        await donate({postId : post._id});
        countDonations = await getCount(post._id);

        ctx.display(detailsTemplate(post, ctx.user, onDonate, countDonations));
    }
    ctx.display(detailsTemplate(post, ctx.user, onDonate, countDonations, userDonations));
}