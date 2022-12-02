import { html } from '../../node_modules/lit-html/lit-html.js';

const eventTemplate = (event) => html`
<div class="eventBoard">
    <div class="event-info">
        <img src="${event.imageUrl}">
        <h2>${event.title}</h2>
        <h6>${event.date}</h6>
        <a href="/details/${event._id}" class="details-button">Details</a>
    </div>
</div>
`

const myProfileTemplate = (ctx) => html`
<section id="profilePage">
    <div class="userInfo">
        <div class="avatar">
            <img src="./images/profilePic.png">
        </div>
        <h2>${ctx.user.email}</h2>
    </div>
    <div class="board">
        
        ${ctx.data.length > 0 
        ? ctx.data.map(eventTemplate)
        : html`
        <div class="no-events">
            <p>This user has no events yet!</p>
        </div>`}
        
    </div>
</section>
`

export const myProfileView = (ctx) => {
    ctx.display(myProfileTemplate(ctx))
}