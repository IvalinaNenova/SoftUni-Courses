async function solve(e) {
    const form = document.getElementById('form');
    const table = document.querySelector('tbody');
    const baseUrl = 'http://localhost:3030/jsonstore/collections/students';

    form.addEventListener('submit', onSubmit);

    table.innerHTML = '';
    let response = await fetch(baseUrl);
    let result = await response.json();

    let allStudents = Object.values(result);

    allStudents.forEach(s => {
        let row = document.createElement('tr');

        for (const data in s) {
            if (data == '_id') continue;

            let cell = document.createElement('td');
            cell.textContent = s[data];
            row.appendChild(cell);
        }
        table.appendChild(row);
    });

    async function onSubmit(e) {
        e.preventDefault();

        let data = new FormData(form)
        const studentObject = Object.fromEntries(data.entries());

        if (Object.values(studentObject).includes('')) {
            return;
        }

        await fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(studentObject)
        });
    }
}

solve()