function addItem() {
    let listElement = document.getElementById('items');
    let inputElement = document.getElementById('newItemText');

    let listItem = document.createElement('li');
    listItem.textContent = inputElement.value;

    let linkElement = document.createElement('a');
    linkElement.href = '#';
    linkElement.textContent = '[Delete]';

    listItem.appendChild(linkElement);
    listElement.appendChild(listItem);

    linkElement.addEventListener('click', () => {
        linkElement.parentNode.remove();
    });

    inputElement.value = '';
    inputElement.focus();
}