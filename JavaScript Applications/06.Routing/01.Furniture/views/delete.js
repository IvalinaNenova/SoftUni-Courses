import { html, render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

export async function deleteView(ctx){
    let confirmation = confirm('Are you sure you want to delete?');
    //if (!confirmation) return;

    let response = await fetch (`http://localhost:3030/data/catalog/${ctx.params.detailsId}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': sessionStorage.token
        }
    })

    if (response.ok) {
        page.redirect('/catalog')
    }
}