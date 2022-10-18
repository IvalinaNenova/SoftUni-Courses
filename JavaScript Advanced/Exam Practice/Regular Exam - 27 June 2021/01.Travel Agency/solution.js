window.addEventListener('load', solution);

function solution() {
  let blockDiv = document.querySelector('#block');
  let submitButton = document.querySelector('#submitBTN');
  let editButton = document.querySelector('#editBTN');
  let continueButton = document.querySelector('#continueBTN');
  let preview = document.querySelector('#infoPreview');
  let lables = Array.from(document.querySelectorAll('div[id="form"] label')).map(l => l.textContent);

  submitButton.addEventListener('click', () => {
    submitButton.disabled = true;
    editButton.disabled = false;
    continueButton.disabled = false;

    let inputElements = Array.from(document.querySelectorAll('input')).filter(i => i.type !== 'button');
    let values = inputElements.map(i => i.value);
    if (values[0] == '' || values[1] == '') return;

    for (let i = 0; i < values.length; i++) {
      if (values[i] == '') continue;
      preview.appendChild(createTag('li', `${lables[i]} ${values[i]}`));
    }
    inputElements.forEach(e => e.value = '');

    editButton.addEventListener('click', () => {
      submitButton.disabled = false;
      editButton.disabled = true;
      continueButton.disabled = true;
      for (let i = 0; i < values.length; i++) {
        inputElements[i].value = values[i];
      }

      let allListItems = preview.getElementsByTagName('li');
      while (allListItems[0]) {
        preview.removeChild(allListItems[0]);
      }
    });

    continueButton.addEventListener('click', () => {
      blockDiv.innerHTML = '';
      blockDiv.appendChild(createTag('h3', 'Thank you for your reservation!'));
    });
  });

  function createTag(tag, text = null) {
    let el = document.createElement(tag);
    if (text) { el.textContent = text; }
    return el;
  }
}
