window.addEventListener("load", solve);

function solve() {
  let form = document.querySelector("form");
  let preview = document.querySelector('#preview-list');
  let publishBtn = document.querySelector('#form-btn');
  let main = document.querySelector('#main');

  form.addEventListener("click", (e) => {
    e.preventDefault();

    let inputElements = Array.from(form.elements).slice(0, -1);
    let values = inputElements.map(e => e.value);
    let [firstName, lastName, age, title, genre, text] = values;

    if (e.target.type != 'button' || values.includes('')) return;

    let liElement = createTag('li', null, 'story-info');

    let article = document.createElement('article');
    article.appendChild(createTag('h4', `Name: ${firstName} ${lastName}`));
    article.appendChild(createTag('p', `Age: ${age}`));
    article.appendChild(createTag('p', `Title: ${title}`));
    article.appendChild(createTag('p', `Genre: ${genre}`));
    article.appendChild(createTag('p', `${text}`));

    let saveBtn = createTag('button', 'Save Story', 'save-btn');
    saveBtn.addEventListener('click', onSave);
    let editBtn = createTag('button', 'Edit Story', 'edit-btn');
    editBtn.addEventListener('click', onEdit);
    let deleteBtn = createTag('button', 'Delete Story', 'delete-btn');
    deleteBtn.addEventListener('click', onDelete);

    liElement.appendChild(article);
    liElement.appendChild(saveBtn);
    liElement.appendChild(editBtn);
    liElement.appendChild(deleteBtn);

    preview.appendChild(liElement);

    inputElements.forEach(e => e.value = '');
    publishBtn.disabled = true;

    function onSave() {
      main.innerHTML = `<h1>Your scary story is saved!</h1>`;
    }

    function onEdit() {
      liElement.remove();

      for (let i = 0; i < values.length; i++) {
        inputElements[i].value = values[i];
      }
      publishBtn.disabled = false;
    };

    function onDelete() {
      liElement.remove();
      publishBtn.disabled = false;
    }
  });

  function createTag(tag, text = null, className = null) {
    let el = document.createElement(tag);
    if (text) { el.textContent = text; }
    if (className) { el.className = className; }
    return el;
  }
}
