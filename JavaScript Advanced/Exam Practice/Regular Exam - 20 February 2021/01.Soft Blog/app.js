function solve() {
   let form = document.querySelector('form');
   let postsSection = document.querySelector('main>section');
   let archiveSection = document.querySelector('.archive-section>ol');
   let titles = [];

   form.addEventListener('click', (e) => {
      e.preventDefault();

      let formElelements = Array.from(form.elements).slice(0, -1);
      let inputValues = formElelements.map(e => e.value);
      let [author, title, category, content] = inputValues;

      if (e.target.textContent !== 'Create' || inputValues.includes('')) return;

      let article = document.createElement('article');

      article.innerHTML = `<h1>${title}</h1>
                           <p>Category: <strong>${category}</strong></p>
                           <p>Creator: <strong>${author}</strong></p>
                           <p>${content}</p>
                           `

      let buttonsDiv = createTag('div', null, 'buttons');
      let deleteButton = createTag('button', 'Delete', 'btn delete');
      let archiveButton = createTag('button', 'Archive', 'btn archive');
      deleteButton.addEventListener('click', onDeleteHandler);
      archiveButton.addEventListener('click', onArchiveHandler);
      buttonsDiv.appendChild(deleteButton);
      buttonsDiv.appendChild(archiveButton);

      article.appendChild(buttonsDiv);
      postsSection.appendChild(article);

      function onArchiveHandler(e) {
         let html = '';
         titles.push(title);
         titles.sort((a, b) => a.localeCompare(b)).forEach(t => html += `<li>${t}</li>`);

         archiveSection.innerHTML = html;
         article.remove();
      }
      function onDeleteHandler(e) {
         article.remove();
      }
   });

   function createTag(tag, text = null, className = null) {
      let el = document.createElement(tag);
      if (text) { el.textContent = text; }
      if (className) { el.className = className; }

      return el;
   }
}
