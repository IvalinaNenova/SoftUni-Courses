function solve() {
    let form = document.querySelector("form");

    form.addEventListener("click", function (e) {
        e.preventDefault();

        let approvalContainer = document.querySelector("#list");
        let sentContainer = document.querySelector(".sent-list");
        let deleteContainer = document.querySelector(".delete-list");

        let inputElements = Array.from(form.elements).slice(0, -2);
        let inputValues = inputElements.map(input => input.value);

        let approvalLiElement = document.createElement('li');
        let sentLiElement = document.createElement('li');

        let sendDeleteButtons = createTag('div', null, null, 'list-action');
        let sendButton = createTag('button', 'Send', null, 'send', 'submit');
        let deleteButton1 = createTag('button', 'Delete', null, 'delete', 'submit');
        sendDeleteButtons.appendChild(sendButton);
        sendDeleteButtons.appendChild(deleteButton1);

        let deleteDiv = createTag('div', null, 'btn');
        let deleteButton2 = createTag('button', 'Delete', 'delete', null, 'submit');
        deleteDiv.appendChild(deleteButton2);

        if (e.target.type != 'submit' || inputValues.includes('')) {
            return;
        }
        if (e.target.textContent == 'Reset') {
            inputElements.forEach(element => {
                element.value = '';
            });
        } else if (e.target.textContent == 'Add to the List') {

            approvalLiElement.appendChild(createTag('h4', 'Title: ' + inputValues[1]));
            approvalLiElement.appendChild(createTag('h4', 'Recipient Name: ' + inputValues[0]));
            approvalLiElement.appendChild(createTag('span', inputValues[2]));
            approvalLiElement.appendChild(sendDeleteButtons);

            approvalContainer.appendChild(approvalLiElement);

            deleteButton1.addEventListener('click', onDeleteHandler);
            sendButton.addEventListener('click', onSendHAndler);

            inputElements.forEach(element => {
                element.value = '';
            });

            function onSendHAndler(e) {
                approvalLiElement.remove();
                sentLiElement.appendChild(createTag('span', 'To: ' + inputValues[0]));
                sentLiElement.appendChild(createTag('span', 'Title: ' + inputValues[1]));
                sentLiElement.appendChild(deleteDiv);

                deleteButton2.addEventListener('click', onDeleteHandler);
                sentContainer.appendChild(sentLiElement);
            }

            function onDeleteHandler(e) {
                console.log(e.target.parentNode);
                if (e.target.className == 'delete') {
                    deleteDiv.remove();
                    deleteContainer.appendChild(sentLiElement);
                } else if (e.target.id == 'delete') {
                    approvalLiElement.remove();
                    let deleted = document.createElement('li');
                    deleted.appendChild(createTag('span', 'To: ' + inputValues[0]));
                    deleted.appendChild(createTag('span', 'Title: ' + inputValues[1]));
                    deleteContainer.appendChild(deleted);
                }
            }

        }

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
solve()