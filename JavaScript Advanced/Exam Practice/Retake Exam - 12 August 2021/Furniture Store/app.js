window.addEventListener('load', solve);

function solve() {
    const form = document.querySelector("form");
    const furnitureList = document.querySelector('#furniture-list');
    const totalPrice = document.querySelector('.total-price');

    form.addEventListener("click", function (e) {
        e.preventDefault();

        let inputElements = Array.from(form.elements).slice(0, -1);
        let inputValues = inputElements.map(input => input.value);
        let [model, year, description, price] = inputValues;

        let moreButton = createTag('button', 'More Info', 'moreBtn');
        let buyButton = createTag('button', 'Buy it', 'buyBtn');

        if (e.target.id != 'add' ||
            inputValues.includes('') ||
            Number(year) < 0 ||
            price < 0) {
            return;
        }

        let row1 = createTag('tr', null, 'info');
        row1.appendChild(createTag('td', model));
        row1.appendChild(createTag('td', Number(price).toFixed(2)));
        row1.appendChild(createTag('td', null, null, null, null, [moreButton, buyButton]));

        let row2 = createTag('tr', null, 'hide');
        row2.appendChild(createTag('td', `Year: ${year}`));
        row2.appendChild(createTag('td', `Description: ${description}`)).colSpan = 3;

        furnitureList.appendChild(row1);
        furnitureList.appendChild(row2);

        moreButton.addEventListener('click', onMore);
        buyButton.addEventListener('click', onBuy);

        function onMore() {
            if (moreButton.textContent == 'More Info') {
                moreButton.textContent = 'Less Info';
                row2.style.display = 'contents';
            }else{
                moreButton.textContent = 'More Info';
                row2.style.display = 'none';
            }
        }
        function onBuy(){
            let currentTotal = Number(totalPrice.textContent);
            totalPrice.textContent = (currentTotal + Number(price)).toFixed(2);
            row1.remove();
            row2.remove();
        }

        inputElements.forEach(e => e.value = '');
    });

    function createTag(tag, text = null, className = null, id = null, type = null, arr = null) {
        let el = document.createElement(tag);
        if (text) { el.textContent = text; }
        if (type) { el.type = type; }
        if (id) { el.id = id; }
        if (className) { el.className = className; }
        if (arr) {
            for (const child of arr) {
                el.appendChild(child);
            }
        }
        return el;
    }
}
