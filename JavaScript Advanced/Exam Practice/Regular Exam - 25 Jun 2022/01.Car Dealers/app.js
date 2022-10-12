window.addEventListener("load", solve);

function solve() {
  let form = document.querySelector("form");
  let tableBodyElement = document.querySelector('#table-body');
  let ulElement = document.querySelector('#cars-list');
  let profitElement = document.querySelector('#profit');
  let profitValue = 0;
  form.addEventListener("submit", function (e) {
    e.preventDefault();
    let inputElements = Array.from(form.elements).slice(1, -1);
    let inputValues = Array.from(form.elements).slice(1, -1).map(input => input.value);

    if (inputValues.includes('') || inputValues[4] > inputValues[5]) {
      return;
    }

    let tableRow = document.createElement('tr');
    tableRow.classList.add('row');
    for (const value of inputValues) {
      let dataCell = document.createElement('td');
      dataCell.textContent = value;
      tableRow.appendChild(dataCell);
    }
    let editButton = document.createElement('button');
    editButton.setAttribute('class', 'action-btn edit');
    editButton.textContent = 'Edit';

    editButton.addEventListener('click', (e) => {
      for (let i = 0; i < inputValues.length; i++) {
        inputElements[i].value = inputValues[i];
      }
      tableRow.remove();
    });

    let sellButton = document.createElement('button');
    sellButton.setAttribute('class', 'action-btn sell')
    sellButton.textContent = 'Sell';

    sellButton.addEventListener('click', (e) => {
      let [make, model, year, fuel, originalCost, sellingPrice] = inputValues;
      let liElement = document.createElement('li');
      liElement.setAttribute('class', 'each-list');
      let span1 = document.createElement('span');
      span1.textContent = `${make} ${model}`;
      let span2 = document.createElement('span');
      span2.textContent = year;
      let span3 = document.createElement('span');
      span3.textContent = sellingPrice - originalCost;

      liElement.appendChild(span1)
      liElement.appendChild(span2);
      liElement.appendChild(span3);

      ulElement.appendChild(liElement);
      profitValue += Number(sellingPrice) - Number(originalCost);
      profitElement.textContent = profitValue.toFixed(2);
      tableRow.remove();

    });


    let buttonsCell = document.createElement('td');
    buttonsCell.appendChild(editButton);
    buttonsCell.appendChild(sellButton);
    tableRow.appendChild(buttonsCell);
    tableBodyElement.appendChild(tableRow);

    for (const el of inputElements) {
      el.value = '';
    }

    console.log(inputValues);
  });
}
