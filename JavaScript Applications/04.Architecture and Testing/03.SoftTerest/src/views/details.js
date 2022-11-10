import {getById} from '../api/data.js';
let section = document.querySelector('#detailsPage');
section.remove();

export function showDetails(context, id){
    context.showSection(section);
    loadIdea(id)
}

async function loadIdea(id){
    let idea
}
