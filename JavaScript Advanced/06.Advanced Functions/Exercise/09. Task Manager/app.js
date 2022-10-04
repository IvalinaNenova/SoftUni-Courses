function solve(e) {
    document.querySelector('#add').addEventListener('click', createTask);
    let [addSection, openSection, inProgress, complete] = Array.from(document.getElementsByTagName('section'));
    let buttons = {
        open: { green: 'Start', red: 'Delete' },
        inProgress: { red: 'Delete', orange: 'Finish' },
    }

    function createTask(e) {
        e.preventDefault();

        let elements = ['h3', 'p', 'p'];
        let form = e.target.parentNode;
        let title = form.elements['task'].value;
        let description = 'Description: ' + form.elements['description'].value
        let date = 'Due Date: ' + form.elements['date'].value;

        let data = [title, description, date];
        if (data.includes('')) {
            return;
        }

        let article = generateArticle(elements, data, buttons);
        openSection.children[1].appendChild(article);

        article.addEventListener('click', (ev) => {
            let actions = eventDelegator(buttons);
            let button = ev.target.textContent;
            let buttonsDiv = ev.target.parentNode;
            let article = ev.currentTarget;

            if (ev.target.tagName != 'BUTTON') {
                return;
            }
            if (button == 'Start') {
                buttonsDiv.remove();
                actions['start'](article);
            } else if (button == 'Finish') {
                buttonsDiv.remove();
                actions['finish'](article);
            } else if (button == 'Delete') {
                actions['delete'](article)
            }
        });
    }

    function eventDelegator(buttons) {
        let functions = {
            start: (article) => {
                article.appendChild(generateButtons(buttons['inProgress']))
                inProgress.children[1].appendChild(article);
            },
            finish: (article) => {
                complete.children[1].appendChild(article);
            },
            delete: (article) => {
                article.remove();
            }
        }

        return functions;
    }

    function generateArticle(elements, data, buttons) {
        let articleElement = document.createElement('article');

        for (let i = 0; i < elements.length; i++) {
            let cell = document.createElement(elements[i]);
            cell.textContent = data[i];
            articleElement.appendChild(cell);
        }
        articleElement.appendChild(generateButtons(buttons['open']));
        return articleElement;
    }

    function generateButtons(obj) {
        let buttonDiv = document.createElement('div');
        buttonDiv.setAttribute('class', 'flex');

        for (const attr in obj) {
            let button = document.createElement('button');
            button.setAttribute('class', attr);
            button.textContent = obj[attr];
            buttonDiv.appendChild(button);
        }
        return buttonDiv;
    }
}