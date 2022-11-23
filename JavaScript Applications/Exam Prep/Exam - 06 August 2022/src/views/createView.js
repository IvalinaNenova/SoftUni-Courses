import { html } from '../../node_modules/lit-html/lit-html.js';
import { createItem } from '../services/dataService.js';

const createTemplate = (onSubmit) => html`

` 

export const createView = (ctx) => {
    const onSubmit = async (e) => {
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        let values = Object.values(data);
        
        if (values.includes('')) return alert('All fields are required')

        await createItem(data);
        ctx.page.redirect('/catalog')
    }

    ctx.display(createTemplate(onSubmit))
}