import { html } from '../../node_modules/lit-html/lit-html.js';
import { editItem , getItem } from '../services/dataService.js';

const editTemplate = (item, onSubmit) => html`

`

export const editView = async (ctx) => {
    const item = await getItem(ctx.params.id);

    const onSubmit = async (e) => {
        e.preventDefault();

        let data = Object.fromEntries(new FormData(e.target));
        let values = Object.values(data);
        
        if (values.includes('')) return alert('All fields are required')

        await editItem(ctx.params.id, data);
        ctx.page.redirect('/catalog')
    }

    ctx.display(editTemplate(item, onSubmit));
}