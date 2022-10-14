function solve() {
    let form = document.querySelector("form");

    form.addEventListener("submit", function (e) {
        e.preventDefault();

        let inputElements = Array.from(form.elements).slice(0, -1);
        let inputValues = inputElements.map(input => input.value);

        let employeeTable = document.querySelector('#tbody');
        let sumElement = document.querySelector('#sum');

        let employeeRow = document.createElement('tr');
        let fireButton = createTag('button', 'Fired', 'fired');
        let editButton = createTag('button', 'Edit', 'edit');

        if (inputValues.includes('')) return;

        for (let i = 0; i < inputValues.length; i++) {
            employeeRow.appendChild(createTag('td', inputValues[i]));
        }
        employeeRow.appendChild(fireButton);
        employeeRow.appendChild(editButton);
        employeeTable.appendChild(employeeRow);

        sumElement.textContent = (Number(sumElement.textContent) + Number(inputValues[5])).toFixed(2);

        editButton.addEventListener('click', (e) => {
            let salary = e.target.parentNode.children[5].textContent;

            for (let i = 0; i < inputElements.length; i++) {
                inputElements[i].value = inputValues[i];
            }
            sumElement.textContent = (Number(sumElement.textContent) - Number(salary)).toFixed(2);
            employeeRow.remove();
        });

        fireButton.addEventListener('click', (e) => {
            let salary = e.target.parentNode.children[5].textContent;
            sumElement.textContent = (Number(sumElement.textContent) - Number(salary)).toFixed(2);

            employeeRow.remove();
        });

        inputElements.forEach(el => el.value = '');
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
solve()