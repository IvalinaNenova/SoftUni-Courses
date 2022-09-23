function addItem() {
    let newItemTextElement = document.getElementById('newItemText');
    let newItemValueElement = document.getElementById('newItemValue');

    let text = newItemTextElement.value;
    let value = newItemValueElement.value;

    let newOptionElement = document.createElement('option');
    newOptionElement.textContent = text;
    newOptionElement.value = value;

    let selectElement = document.getElementById('menu');
    selectElement.appendChild(newOptionElement);

    newItemTextElement.value = '';
    newItemValueElement.value = '';
}