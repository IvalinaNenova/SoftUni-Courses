window.addEventListener("load", solve);

function solve() {
  let form = document.querySelector(".newPostContent");
  let reviewEl = document.querySelector('#review-list');
  let publishedEl = document.querySelector('#published-list');
  let clearButton = document.querySelector('#clear-btn');

  form.addEventListener("click", function (e) {
    e.preventDefault();
    let liElement = createTag('li', null, 'rpost');


    let inputElements = Array.from(form.elements).slice(0, -1);
    let inputValues = inputElements.map(input => input.value);

    if (e.target.type != 'button') return;
    if (inputValues.includes('')) return;

    let editButton = createTag('button', 'EDIT', 'action-btn edit');
    let approveButton = createTag('button', 'APPROVE', 'action-btn approve');
    
    let articleElement = document.createElement('article');
    articleElement.appendChild(createTag('h4', inputValues[0],));
    articleElement.appendChild(createTag('p', 'Category: ' + inputValues[1]));
    articleElement.appendChild(createTag('p', 'Content: ' + inputValues[2]));

    liElement.appendChild(articleElement);
    liElement.appendChild(editButton);
    liElement.appendChild(approveButton)
    reviewEl.appendChild(liElement);

    editButton.addEventListener('click', () => {
      for (i = 0; i < inputValues.length; i++) {
        inputElements[i].value = inputValues[i];
        liElement.remove();
      }
    });

    approveButton.addEventListener('click', () => {
      liElement.removeChild(approveButton);
      liElement.removeChild(editButton);
      publishedEl.appendChild(liElement);
    });

    clearButton.addEventListener('click', () => {
      while (publishedEl.children.length > 0) {
        publishedEl.removeChild(publishedEl.children[0]);
      }
    });
    for (const el of inputElements) {
      el.value = '';
    }
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
