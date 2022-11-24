import {deleteItem} from '../services/dataService.js';

export const deleteView = async(ctx) => {
    if(!confirm('Are you sure you want to delete this post?')) return;
    
    await deleteItem(ctx.params.id);
    ctx.page.redirect('/catalog');
}
