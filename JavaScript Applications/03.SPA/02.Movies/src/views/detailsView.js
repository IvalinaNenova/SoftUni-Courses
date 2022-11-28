import { html } from '../../node_modules/lit-html/lit-html.js';
import { getItem, getMovieLikes, getUserLikes, likeMovie } from '../services/dataService.js';


//user && user._id == item._ownerId - check if user or guest and owner


const detailsTemplate = (movie, user, onLike, userLikes, totalLikes) => html`
<section id="movie-example" class="view-section">
    <div class="container">
        <div class="row bg-light text-dark">
            <h1>Movie title: ${movie.title}</h1>

            <div class="col-md-8">
                <img class="img-thumbnail" src="${movie.img}" alt="Movie" />
            </div>
            <div class="col-md-4 text-center">
                <h3 class="my-3">Movie Description</h3>
                <p>${movie.description}</p>

                ${user?._id == movie._ownerId
                ? html`
                <a class="btn btn-danger" href="/delete/${movie._id}">Delete</a>
                <a class="btn btn-warning" href="/edit/${movie._id}">Edit</a>
                `
                : null}

                ${user && user?._id !== movie._ownerId && userLikes == 0
                ? html`<a class="btn btn-primary" href="#" @click=${onLike}>Like</a>`
                : html`<span class="enrolled-span">Liked ${totalLikes}</span>`}
                
            </div>
        </div>
    </div>
</section>
`

export const detailsView = async (ctx) => {
    let item = await getItem(ctx.params.id);
    let totalLikes = await getMovieLikes(item._id);
    let userLikes = await getUserLikes(item._id, ctx.user?._id);
    console.log(userLikes);

    const onLike = async (e) => {
        e.preventDefault();
        await likeMovie({ movieId: item._id })

        ctx.page.redirect(`/details/${item._id}`);
    }
    ctx.display(detailsTemplate(item, ctx.user, onLike, userLikes, totalLikes));
}