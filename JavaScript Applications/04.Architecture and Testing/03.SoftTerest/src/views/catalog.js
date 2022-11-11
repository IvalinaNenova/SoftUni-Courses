import { getAllIdeas } from '../api/data.js';
import {showDetails} from './details.js';
let section = document.querySelector('#dashboard-holder');
section.remove();

let ctx = null;
export function showCatalog(context) {
    ctx = context;
    context.showSection(section);
    loadIdeas();
}
async function loadIdeas() {
    let ideas = await getAllIdeas();
    if (ideas.length == 0) {
        let element = document.createElement('h1');
        element.textContent = 'No ideas yet! Be the first one :)';
        section.replaceChildren(element);
    } else {
        let fragment = document.createDocumentFragment();
        ideas.map(i => {
            fragment.appendChild(createIdeaCard(i));
        });
        section.replaceChildren(fragment);
    }

    Array.from(section.querySelectorAll('a')).forEach(button => {
        button.addEventListener('click', (e) => {
            e.preventDefault();
            console.log(e.target.dataset.id);
            showDetails(ctx, e.target.dataset.id);
        })
    })
}

function createIdeaCard(idea) {
    let element = document.createElement('div');
    element.className = 'card overflow-hidden current-card details';
    element.style.width = '20rem';
    element.style.height = '18rem';

    element.innerHTML = `
    <div class="card-body">
        <p class="card-text">${idea.title}</p>
    </div>
    <img class="card-image" src="${idea.img}" alt="Card image cap">
    <a data-id="${idea._id}"class="btn" href="">Details</a>`;

    return element;
}


