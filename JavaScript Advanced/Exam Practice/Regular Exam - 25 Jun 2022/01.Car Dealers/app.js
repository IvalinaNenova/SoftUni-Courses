window.addEventListener("load", solve);
function solve() {

    let tableBody = document.getElementById('table-body');
    let publishButton = document.getElementById('publish');

    publishButton.addEventListener('click', (e) => {
        e.preventDefault();
        let make = document.getElementById('make');
        let model = document.getElementById('model');
        let year = document.getElementById('year');
        let fuel = document.getElementById('fuel');
        let originalCost = document.getElementById('original-cost');
        let sellingPrice = document.getElementById('selling-price');
        console.log(make.value, model.value, year.value, fuel.value, originalCost.value, sellingPrice.value);
        if (make.value == ''
            || model.value == ''
            || year.value == ''
            || fuel.value == ''
            || originalCost.value == ''
            || sellingPrice.value == ''
            || Number(originalCost.value) > Number(sellingPrice.value)) {
            return;
        }


        let tr = document.createElement('tr');
        tr.classList.add('row');

        let td1 = document.createElement('td');
        td1.textContent = make.value;
        let td2 = document.createElement('td');
        td2.textContent = model.value;
        let td3 = document.createElement('td');
        td3.textContent = year.value;
        let td4 = document.createElement('td');
        td4.textContent = fuel.value;
        let td5 = document.createElement('td');
        td5.textContent = originalCost.value;
        let td6 = document.createElement('td');
        td6.textContent = sellingPrice.value;
        let tdBtn = document.createElement('td');
        let btnEdit = document.createElement('button');
        let btnSell = document.createElement('button');
        tdBtn.appendChild(btnEdit);
        tdBtn.appendChild(btnSell);

        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        tr.appendChild(td5);
        tr.appendChild(td6);
        tr.appendChild(tdBtn);
        tableBody.appendChild(tr);

        btnEdit.setAttribute('class', 'action-btn edit');
        btnSell.setAttribute('class', 'action-btn sell');
        btnEdit.textContent = 'Edit';
        btnSell.textContent = 'Sell';

        td1.textContent = '';
        td2.textContent = '';
        td3.textContent = '';
        td4.textContent = '';
        td5.textContent = '';
        td6.textContent = '';

    });
}

// window.addEventListener("load", solve)

// function solve() {
//     let form = document.querySelector('form');
//     const tableBody = document.querySelector('#table-body');
//     const soldCars = document.querySelector('#cars-list');
//     const profit = document.querySelector('#profit');

//     form.addEventListener('submit', (e) => {
//         e.preventDefault();

//         let inputElements = Array.from(form.elements).slice(1, -1);
//         let values = inputElements.map(e => e.value);
//         let [make, model, year, fuel, originalPrice, sellingPrice] = values;

//         if (values.includes('') || sellingPrice < originalPrice) return;

//         let row = createTag('tr', null, 'row');
//         let buttonCell = document.createElement('td');
//         let editButton = createTag('button', 'Edit', 'action-btn edit');
//         editButton.addEventListener('click', onEdit);
//         let sellButton = createTag('button', 'Sell', 'action-btn sell');
//         sellButton.addEventListener('click', onSell);
//         buttonCell.appendChild(editButton);
//         buttonCell.appendChild(sellButton);
//         values.forEach(e => row.appendChild(createTag('td', e)));
//         row.appendChild(buttonCell);
//         tableBody.appendChild(row);

//         function onEdit() {
//             for (let i = 0; i < values.length; i++) {
//                 inputElements[i].value = values[i];
//             }
//             row.remove();
//         };
//         function onSell() {
//             let carProfit = sellingPrice - originalPrice;
//             let currpentProfit = Number(profit.textContent);

//             let carRow = createTag('li', null, 'each-list');

//             carRow.innerHTML = `<span>${make} ${model}</span>
//             <span>${year}</span>
//             <span>${sellingPrice - originalPrice}</span>`

//             soldCars.appendChild(carRow);
//             row.remove();
//             profit.textContent = (currpentProfit + carProfit).toFixed(2);
//         };

//         inputElements.forEach(e => e.value = '');
//     });
//     function createTag(tag, text = null, className = null, id = null, type = null) {
//         let el = document.createElement(tag);
//         if (text) { el.textContent = text; }
//         if (type) { el.type = type; }
//         if (id) { el.id = id; }
//         if (className) { el.className = className; }
//         return el;
//     }
// }
