import { html } from '../../node_modules/lit-html/lit-html.js';
import { addApplication, getCount, getItem, getUserApplications } from '../services/dataService.js';


//user && user._id == item._ownerId - check if user or guest and owner


const detailsTemplate = (item, user, onApply, count, userApplications) => html`
<section id="details">
  <div id="details-wrapper">
    <img id="details-img" src="${item.imageUrl}" alt="example1" />
    <p id="details-title">${item.title}</p>
    <p id="details-category">
      Category: <span id="categories">${item.category}</span>
    </p>
    <p id="details-salary">
      Salary: <span id="salary-number">${item.salary}</span>
    </p>
    <div id="info-wrapper">
      <div id="details-description">
        <h4>Description</h4>
        <span>${item.description}</span>
      </div>
      <div id="details-requirements">
        <h4>Requirements</h4>
        <span>${item.requirements}</span>
      </div>
    </div>
    <p>Applications: <strong id="applications">${count}</strong></p>

    <!--Edit and Delete are only for creator-->
    ${user && user._id == item._ownerId
    ? html`
    <div id="action-buttons">
      <a href="/edit/${item._id}" id="edit-btn">Edit</a>
      <a href="/delete/${item._id}" id="delete-btn">Delete</a>
    </div>`
    : null}

    ${userApplications == 0 && user._id !== item._ownerId
    ? html`
    <div id="action-buttons">
      <a @click=${onApply} href="#" id="apply-btn">Apply</a>
    </div>`
    : null}

  </div>
</section>
`

export const detailsView = async (ctx) => {
  let offer = await getItem(ctx.params.id);
  let countApplications = await getCount(offer._id);
  let userApplications;
  if (ctx.user) {
    userApplications = await getUserApplications(offer._id, ctx.user._id);
  }

  const onApply = async (e) => {
    e.preventDefault();

    await addApplication({ offerId: offer._id });
    let countApplications = await getCount(offer._id);
    
    ctx.display(detailsTemplate(offer, ctx.user, onApply, countApplications))
  }

  ctx.display(detailsTemplate(offer, ctx.user, onApply, countApplications, userApplications))
}