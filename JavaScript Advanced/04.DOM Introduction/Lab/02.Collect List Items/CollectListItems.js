function extractText() {
    let listElements = document.getElementById('items');

    let textArea = document.getElementById('result');
    textArea.value = listElements.textContent;
}