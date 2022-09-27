function solve() {
  let tableElement = document.querySelector('tbody');
  let [inputElement, outputElement] = document.getElementsByTagName('textarea');
  let [generateButton, buyButton] = document.getElementsByTagName('button');

  let generate = function (e) {
    let input = JSON.parse(inputElement.value);

    for (const data of input) {
      let row = document.createElement('tr');

      row.appendChild(createCell('img', { src: data.img }));
      row.appendChild(createCell('p', {}, data.name));
      row.appendChild(createCell('p', {}, data.price));
      row.appendChild(createCell('p', {}, data.decFactor));
      row.appendChild(createCell('input', { type: 'checkbox' }));

      tableElement.appendChild(row);
      console.log(tableElement);

    }
  };

  let createCell = function (nestedTag, nestedData, text) {
    let cellElement = document.createElement('td');
    let nestedElement = document.createElement(nestedTag);

    for (const attribute in nestedData) {
      nestedElement.setAttribute(attribute, nestedData[attribute]);
      console.log(nestedElement);
    }

    if (text) {
      nestedElement.textContent = text;
    }

    cellElement.appendChild(nestedElement);
    return cellElement;
  }

  let buy = function () {
    let bought = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'))
      .map(b => b.parentNode.parentNode);

    let names = [];
    let totalPrice = 0;
    let totalDecFactor = 0;

    for (const item of bought) {
      let name = item.childNodes[1].textContent;
      let price = Number(item.childNodes[2].textContent);
      let decorationFactor = Number(item.childNodes[3].textContent);

      names.push(name);
      totalPrice += price;
      totalDecFactor += decorationFactor;
    }

    let averageDecFactor = totalDecFactor / names.length;
    let output = `Bought furniture: ${names.join(", ")}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${averageDecFactor}`;

    outputElement.value = output;
  };

  generateButton.addEventListener('click', generate);
  buyButton.addEventListener('click', buy);
}