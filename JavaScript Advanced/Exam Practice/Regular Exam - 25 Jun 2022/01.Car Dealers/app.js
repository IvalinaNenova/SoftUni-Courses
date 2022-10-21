window.addEventListener("load", solve)

function solve() {
    let form = document.querySelector('form');
    const tableBody = document.querySelector('#table-body');
    const soldCars = document.querySelector('#cars-list');
    const profit = document.querySelector('#profit');

    form.addEventListener('submit', (e) => {
        e.preventDefault();

        let inputElements = Array.from(form.elements).slice(1, -1);
        let values = inputElements.map(e => e.value);
        let [make, model, year, fuel, originalPrice, sellingPrice] = values;

        if (values.includes('') || sellingPrice < originalPrice) return;

        let row = createTag('tr', null, 'row');
        let buttonCell = document.createElement('td');
        let editButton = createTag('button', 'Edit', 'action-btn edit');
        editButton.addEventListener('click', onEdit);
        let sellButton = createTag('button', 'Sell', 'action-btn sell');
        sellButton.addEventListener('click', onSell);
        buttonCell.appendChild(editButton);
        buttonCell.appendChild(sellButton);
        values.forEach(e => row.appendChild(createTag('td', e)));
        row.appendChild(buttonCell);
        tableBody.appendChild(row);

        function onEdit() {
            for (let i = 0; i < values.length; i++) {
                inputElements[i].value = values[i];
            }
            row.remove();
        };
        function onSell() {
            let carProfit = sellingPrice - originalPrice;
            let currpentProfit = Number(profit.textContent);

            let carRow = createTag('li', null, 'each-list');

            carRow.innerHTML = `<span>${make} ${model}</span>
            <span>${year}</span>
            <span>${sellingPrice - originalPrice}</span>`

            soldCars.appendChild(carRow);
            row.remove();
            profit.textContent = (currpentProfit + carProfit).toFixed(2);
        };

        inputElements.forEach(e => e.value = '');
    });
    function createTag(tag, text = null, className = null, id = null, type = null) {
        let el = document.createElement(tag);
        if (text) { el.textContent = text; }
        if (type) { el.type = type; }
        if (id) { el.id = id; }
        if (className) { el.className = className; }
        return el;
    }
}
