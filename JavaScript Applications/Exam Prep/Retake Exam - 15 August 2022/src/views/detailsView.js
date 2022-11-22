import { html } from '../../node_modules/lit-html/lit-html.js';
import {getItem} from '../services/dataService.js';
//user && user._id == item._ownerId - check if user or guest and owner
const detailsTemplate = (item, user) => html `
<section id="details">
          <div id="details-wrapper">
            <p id="details-title">Shoe Details</p>
            <div id="img-wrapper">
              <img src="${item.imageUrl}" alt="example1" />
            </div>
            <div id="info-wrapper">
              <p>Brand: <span id="details-brand">${item.brand}</span></p>
              <p>
                Model: <span id="details-model">${item.model}</span>
              </p>
              <p>Release date: <span id="details-release">${item.release}</span></p>
              <p>Designer: <span id="details-designer">${item.designer}</span></p>
              <p>Value: <span id="details-value">${item.value}</span></p>
            </div>
            ${user && user._id == item._ownerId 
            ? html`<div id="action-buttons">
              <a href="/edit/${item._id}" id="edit-btn">Edit</a>
              <a href="/delete/${item._id}" id="delete-btn">Delete</a>
            </div>`
            : null}
          </div>
        </section>
`

export const detailsView = async (ctx) => {
    let item = await getItem(ctx.params.id);
    ctx.display(detailsTemplate(item, ctx.user))
}