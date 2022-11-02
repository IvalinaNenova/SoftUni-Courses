function attachEvents() {
    document.getElementById('submit')
    .addEventListener('click', onSubmit)

    document.getElementById('refresh')
    .addEventListener('click', onRefresh);

    const displayArea = document.getElementById('messages');

    async function onSubmit(){
        let author = document.querySelector('[name="author"]').value;
        let content = document.querySelector('[name="content"]').value;

        await fetch(`http://localhost:3030/jsonstore/messenger`, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({author, content})
        })
        console.log(author, content);
    }

    async function onRefresh() {
        let response = await fetch(`http://localhost:3030/jsonstore/messenger`);
        let data = await response.json();
        let output = [];
        
        for (const message of Object.values(data)) {
            output.push(`${message.author}: ${message.content}`);
        }
        displayArea.value = output.join('\n');

        console.log(data);
    }
}

attachEvents();