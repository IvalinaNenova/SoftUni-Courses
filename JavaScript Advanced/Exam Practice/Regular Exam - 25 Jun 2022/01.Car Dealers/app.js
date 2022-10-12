window.addEventListener("load", solve)

function solve() {
    let form = document.querySelector("form");
    let tableBodyElement = document.querySelector('#table-body');
    let ulElement = document.querySelector('#cars-list');
    let profitElement = document.querySelector('#profit');
    let profitValue = 0;

    form.addEventListener("submit", function (e) {
        e.preventDefault();
        let inputElements = Array.from(form.elements).slice(1, -1);
        let inputValues = inputElements.map(input => input.value);

        let tableRow = createTag('tr', null, 'row');
        let editButton = createTag('button', 'Edit', 'action-btn edit');
        let sellButton = createTag('button', 'Sell', 'action-btn sell');

        if (inputValues.includes('') || inputValues[4] > inputValues[5]) {
            return;
        }

        for (const value of inputValues) {
            let dataCell = createTag('td', value);
            tableRow.appendChild(dataCell);
        }

        editButton.addEventListener('click', (e) => {
            for (let i = 0; i < inputValues.length; i++) {
                inputElements[i].value = inputValues[i];
            }
            tableRow.remove();
        });

        sellButton.addEventListener('click', (e) => {
            let [make, model, year, fuel, originalCost, sellingPrice] = inputValues;

            let liElement = createTag('li', null, 'each-list');
            liElement.appendChild(createTag('span', make + ' ' + model));
            liElement.appendChild(createTag('span', year))
            liElement.appendChild(createTag('span', sellingPrice - originalCost))

            ulElement.appendChild(liElement);
            profitValue += sellingPrice - originalCost;
            profitElement.textContent = profitValue.toFixed(2);

            tableRow.remove();
        });

        let buttonsCell = document.createElement('td');
        buttonsCell.appendChild(editButton);
        buttonsCell.appendChild(sellButton);
        tableRow.appendChild(buttonsCell);
        tableBodyElement.appendChild(tableRow);

        inputElements.forEach(el => el.value = '');

        function createTag(tag, text = null, className = null, id = null, type = null) {
            let el = document.createElement(tag);
            if (text) { el.textContent = text; }
            if (type) { el.type = type; }
            if (id) { el.id = id; }
            if (className) { el.className = className; }
            return el;
        }
    });
}
