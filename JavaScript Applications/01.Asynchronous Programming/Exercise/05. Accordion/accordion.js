async function solution() {
    const mainSection = document.querySelector('#main');
    try {
        let url = 'http://localhost:3030/jsonstore/advanced/articles/list';
        let result = await fetch(url);
        let data = await result.json();

        for (const key in data) {
            let articleElement = document.createElement('div');
            articleElement.className = 'accordion';

            articleElement.innerHTML = `
            <div class="head">
                <span>${data[key].title}</span>
                <button class="button" id="${data[key]._id}">More</button>
            </div>
            <div class="extra"></div>
            `
            let moreButton = articleElement.querySelector('button');
            moreButton.addEventListener('click', onMoreClick);

            mainSection.appendChild(articleElement);
        }
    } catch (error) {
        console.log(error.message);
    }
}
async function onMoreClick(e) {
    let currentArticle = e.currentTarget.parentNode.parentNode;
    let id = e.target.id;
    let extraInfo = currentArticle.querySelector('div.extra');
    try {
        let response = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`);
        let data = await response.json();
        extraInfo.innerHTML = `<p>${data.content}</p>`;

        if (e.target.textContent == 'More') {
            e.target.textContent = 'Less';
            extraInfo.style.display = 'block';
        } else {
            e.target.textContent = 'More';
            extraInfo.style.display = 'none';
        }
    } catch (error) {
        console.log(error.message);
    }
}

solution();