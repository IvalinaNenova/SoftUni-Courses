function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/collections/books';
    const loadButton = document.getElementById('loadBooks');
    const tableBody = document.querySelector('tbody');
    tableBody.addEventListener('click', modify);
    const form = document.querySelector('form');
    form.addEventListener('click', onSubmit);

    let editId = '';

    loadButton.addEventListener('click', onLoad);

    async function onSubmit(e) {
        e.preventDefault();
        if (e.target.tagName !== 'BUTTON') return;
        if (e.target.textContent == 'Save') {
            onSave(e);
            return;
        }

        let { title, author } = Object.fromEntries(new FormData(form).entries());
        if (title == '' || author == '') return;
        await fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, author })
        });
        document.querySelector('[name="title"]').value = '';
        document.querySelector('[name="author"]').value = '';
        onLoad();
    }
    async function onSave(e) {


        let { title, author } = Object.fromEntries(new FormData(form).entries());

        console.log(title, author);
        if (title == '' || author == '') return;
        document.querySelector('form h3').textContent = 'FORM';
        document.querySelector('form button').textContent = 'Submit';
        await fetch(`${baseUrl}/${editId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, author })
        });
        document.querySelector('[name="title"]').value = '';
        document.querySelector('[name="author"]').value = '';
        onLoad();
    }
    async function onLoad() {
        let response = await fetch(baseUrl);
        let data = Object.entries(await response.json());

        tableBody.innerHTML = '';
        console.log(data);

        for (const [key, { author, title }] of data) {
            let row = document.createElement('tr');

            let buttonCell = document.createElement('td');
            let editButton = createTag('button', 'Edit', null, key);
            let deleteButton = createTag('button', 'Delete', null, key);
            buttonCell.appendChild(editButton);
            buttonCell.appendChild(deleteButton);

            row.appendChild(createTag('td', title));
            row.appendChild(createTag('td', author));
            row.appendChild(buttonCell);

            tableBody.appendChild(row)
            console.log(key, title, author);
        }
    }
    function modify(e) {
        if (e.target.tagName !== 'BUTTON') return;
        e.target.textContent == 'Edit' ? onEdit(e) : onDelete(e);
    }

    async function onEdit(e) {
        editId = e.target.id;
        let title = e.target.parentNode.parentNode.children[0].textContent;
        let author = e.target.parentNode.parentNode.children[1].textContent;

        document.querySelector('[name="title"]').value = title;
        document.querySelector('[name="author"]').value = author;

        document.querySelector('form h3').textContent = 'Edit FORM';
        document.querySelector('form button').textContent = 'Save';

        e.target.parentNode.parentNode.remove();
    };

    async function onDelete(e) {
        await fetch(`${baseUrl}/${e.target.id}`, {
            method: 'delete',
        });
        e.target.parentNode.parentNode.remove();
    };


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