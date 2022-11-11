import { getById } from '../api/data.js';
import { deleteById } from '../api/data.js';
let section = document.querySelector('#detailsPage');
section.remove();
let ctx = null;
export function showDetails(context, id) {
    ctx = context;
    context.showSection(section);
    loadIdea(id)
}

async function loadIdea(id) {
    let idea = await getById(id);
    section.innerHTML = `
    <img class="det-img" src="${idea.img}" />
            <div class="desc">
                <h2 class="display-5">${idea.title}</h2>
                <p class="infoType">Description:</p>
                <p class="idea-description">${idea.description}</p>
            </div>
            <div class="text-center">
                <a class="btn detb" href="">Delete</a>
            </div>`

    const deleteButton = section.querySelector('a');
    deleteButton.style.display = 'none';
    let currentUser = JSON.parse(sessionStorage.getItem('userData'));
    if (!currentUser) {
        deleteButton.style.display = 'none';
    } else {
        let currentUserId = currentUser.id;
        if (currentUserId == idea._ownerId) {
            deleteButton.style.display = 'inline-block';
            
            deleteButton.addEventListener('click', async (e) => {
                e.preventDefault();
                await deleteById(id);
                ctx.updateNav();
                ctx.goTo('catalog');
            });
        } else {
            deleteButton.style.display = 'none';
        }
    }
}
