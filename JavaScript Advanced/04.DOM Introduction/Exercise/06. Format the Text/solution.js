function solve() {
  let textElement = document.getElementById('input').value;
  let sentences = Array.from(textElement.split('.').filter(sentence => sentence !== '\n' && sentence !== ''));
  let resultDivElement = document.getElementById('output');

  while (sentences.length > 0) {
    let text = sentences.splice(0, 3).join('.') + '.';
    let paragraph = document.createElement('p');
    paragraph.textContent = text;
    resultDivElement.appendChild(paragraph);
  }
}