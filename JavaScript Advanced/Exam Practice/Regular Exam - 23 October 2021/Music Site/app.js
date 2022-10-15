window.addEventListener('load', solve);

function solve() {
    let form = document.querySelector("form");
    let allHits = document.querySelector('.all-hits-container');
    let savedSongs = document.querySelector('.saved-container');
    let totalLikes = document.querySelector('#total-likes p');

    form.addEventListener("submit", function (e) {
        e.preventDefault();
        let inputElements = Array.from(form.elements).slice(0, -1);
        let inputValues = inputElements.map(input => input.value);

        if (inputValues.includes('')) return;

        let saveButton = createTag('button', 'Save song', 'save-btn');
        let likeButton = createTag('button', 'Like song', 'like-btn');
        let deleteButton = createTag('button', 'Delete', 'delete-btn');

        let hitsDiv = createTag('div', null, 'hits-info');

        let image = document.createElement('img');
        image.src = './static/img/img.png';
        hitsDiv.appendChild(image);

        hitsDiv.appendChild(createTag('h2', 'Genre: ' + inputValues[0]));
        hitsDiv.appendChild(createTag('h2', 'Name: ' + inputValues[1]));
        hitsDiv.appendChild(createTag('h2', 'Author: ' + inputValues[2]));
        hitsDiv.appendChild(createTag('h3', 'Date: ' + inputValues[3]));
        hitsDiv.appendChild(saveButton);
        hitsDiv.appendChild(likeButton);
        hitsDiv.appendChild(deleteButton);

        allHits.appendChild(hitsDiv);

        saveButton.addEventListener('click', () => {
            saveButton.remove();
            likeButton.remove();
            savedSongs.appendChild(hitsDiv);
        });

        likeButton.addEventListener('click', () => {
            let currentTotal = Number(totalLikes.textContent.split(' ')[2]);
            totalLikes.textContent = `Total Likes: ${currentTotal + 1}`;
            likeButton.disabled = true;
        });
        
        deleteButton.addEventListener('click', () => {
            hitsDiv.remove();
        });

        inputElements.forEach(e => e.value = '');
    });
    function createTag(tag, text = null, className = null, id = null, type = null) {
        let el = document.createElement(tag);
        if (text) { el.textContent = text; }
        if (type) { el.type = type; }
        if (id) { el.id = id; }
        if (className) { el.className = className; }
        return el;
    }
}