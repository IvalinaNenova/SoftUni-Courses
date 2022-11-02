function attachEvents() {
    const phoneBook = document.getElementById('phonebook');
    document.getElementById('btnLoad').addEventListener('click', onLoad);
    document.getElementById('btnCreate').addEventListener('click', onCreate);

    const baseUrl = 'http://localhost:3030/jsonstore/phonebook';

    async function onLoad() {
        phoneBook.innerHTML = '';

        let response = await fetch(baseUrl);
        let result = await response.json();

        for (const entry of Object.values(result)) {
            let deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', onDelete);

            let item = document.createElement('li');
            item.id = entry._id;
            item.textContent = `${entry.person}: ${entry.phone}`;
            item.appendChild(deleteButton);

            phoneBook.appendChild(item)
        }
    };

    async function onCreate() {
        let person = document.getElementById('person').value;
        let phone = document.getElementById('phone').value;

        await fetch(baseUrl, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ person, phone })
        });
        person.value = '';
        phone.value = '';

        onLoad();
    };

    async function onDelete(e) {
        let id = e.target.parentNode.id;

        await fetch(`${baseUrl}/${id}`, {
            method: 'delete'
        });

        document.getElementById(id).remove();
    }
}

attachEvents();