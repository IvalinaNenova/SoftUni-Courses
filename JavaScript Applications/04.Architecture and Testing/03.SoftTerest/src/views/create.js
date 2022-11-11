import {createIdea} from '../api/data.js';
let section = document.querySelector('#createPage');
section.remove();

let form = section.querySelector('form');
form.addEventListener('submit', onSubmit)

let ctx = null;
export function showCreate(context){
    ctx = context;
    context.showSection(section);
}

async function onSubmit(e){
    e.preventDefault();

    let formData = new FormData(form);
    let title = formData.get('title').trim();
    let description = formData.get('description').trim();
    let img = formData.get('imageURL').trim();

    //TODO add validation

    createIdea({title, description, img});
    form.reset();
    ctx.updateNav();
    ctx.goTo('catalog');
}