function addItem() {
    let itemElements = document.getElementById('items');
    let inputElement = document.getElementById('newItemText');

    let newItemElement = document.createElement('li');
    newItemElement.textContent = inputElement.value;

    itemElements.appendChild(newItemElement);
    inputElement.value = '';
}