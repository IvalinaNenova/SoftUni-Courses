import { html } from '../../node_modules/lit-html/lit-html.js';
import { getItem, getUserDonations, getTotalCount, donate } from '../services/dataService.js';


//user && user._id == item._ownerId - check if user or guest and owner


const detailsTemplate = (item, user, onDonate, userDonations, count) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src="${item.image}">
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${item.name}</h1>
                <h3>Breed: ${item.breed}</h3>
                <h4>Age: ${item.age}</h4>
                <h4>Weight: ${item.weight}</h4>
                <h4 class="donation">Donation: ${count}$</h4>
            </div>
            <!-- if there is no registered user, do not display div-->
            <div class="actionBtn">
                <!-- Only for registered user and creator of the pets-->
                ${user?._id == item._ownerId
                ? html`
                <a href="/edit/${item._id}" class="edit">Edit</a>
                <a href="/delete/${item._id}" class="remove">Delete</a>`
                : null}
                
                <!--(Bonus Part) Only for no creator and user-->
                ${user && user?._id !== item._ownerId && userDonations == 0
                ? html`<a href="#" @click=${onDonate} class="donate">Donate</a>`
                : null	}
                
            </div>
        </div>
    </div>
</section>
`

export const detailsView = async (ctx) => {
    let item = await getItem(ctx.params.id);
    let userDonations = await getUserDonations(item._id, ctx.user?._id)
    let countDonations = await getTotalCount(item._id)*100;

    const onDonate = async (e) => {
        e.preventDefault();

        await donate({petId: item._id})
        //countDonations = await getTotalCount(item._id) * 100;

        ctx.display(detailsTemplate(item, ctx.user, onDonate, userDonations, countDonations))
        ctx.page.redirect(`/details/${item._id}`)

    }



    ctx.display(detailsTemplate(item, ctx.user, onDonate, userDonations, countDonations))
}