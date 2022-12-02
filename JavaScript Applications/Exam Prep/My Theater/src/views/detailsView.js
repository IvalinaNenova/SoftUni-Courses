import { html } from '../../node_modules/lit-html/lit-html.js';
import { addLike } from '../services/dataService.js';
//import { likeHandler } from '../utils/util.js';

const detailsTemplate = (ctx, onLike) => html`
<section id="detailsPage">
            <div id="detailsBox">
                <div class="detailsInfo">
                    <h1>Title: ${ctx.data.title}</h1>
                    <div>
                        <img src="${ctx.data.imageUrl}" />
                    </div>
                </div>

                <div class="details">
                    <h3>Theater Description</h3>
                    <p>${ctx.data.description}</p>
                    <h4>Date: ${ctx.data.date}</h4>
                    <h4>Author: ${ctx.data.author}</h4>
                    <div class="buttons">
                        ${ctx.isOwner 
                        ? html`
                        <a class="btn-delete" href="/delete/${ctx.data._id}">Delete</a>
                        <a class="btn-edit" href="/edit/${ctx.data._id}">Edit</a>`
                        : null}

                        ${ctx.isLogged && !ctx.isOwner && ctx.user.likes == 0
                        ? html`<a class="btn-like" href="javascript:void(0)" @click=${onLike}>Like</a>`
                        : null}
                        
                    </div>
                    <p class="likes">Likes: ${ctx.data.likes}</p>
                </div>
            </div>
        </section>
`

export const detailsView = (ctx) => {

    const onLike = async (e) => {
        e.preventDefault();
        await addLike({theaterId: ctx.data._id});
        document.querySelector('.likes').textContent = `Likes: ${ctx.data.likes + 1}`
        document.querySelector('.btn-like').style.display = 'none';
        
    }
    ctx.display(detailsTemplate(ctx, onLike))
}