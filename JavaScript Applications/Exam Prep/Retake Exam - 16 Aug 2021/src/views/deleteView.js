import {deleteItem} from '../services/dataService.js';

export const deleteView = async(ctx) => {
    await deleteItem(ctx.params.id);
    ctx.page.redirect('/catalog');
}
