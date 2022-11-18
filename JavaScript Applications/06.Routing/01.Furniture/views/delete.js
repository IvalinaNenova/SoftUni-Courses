import page from '../node_modules/page/page.mjs';
import { onDelete } from '../api.js';

export async function deleteView(ctx) {
    let confirmation = confirm('Are you sure you want to delete?');
    if (!confirmation) return;
    await onDelete(ctx.params.detailsId);
    page.redirect('/catalog')
}