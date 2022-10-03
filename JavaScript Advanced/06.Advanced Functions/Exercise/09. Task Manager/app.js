function solve(e) {
    document.querySelector('#add').addEventListener('click', createTask);
    let sections = document.getElementsByTagName('section');
    let openSection = sections[1];
    let inProgress = sections[2];
    let complete = sections[3];
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
            if (ev.target.tagName != 'BUTTON') {
                return;
            }
            if (ev.target.textContent == 'Start') {
                console.log(ev.target.parentNode);
                ev.target.parentNode.remove();
                actions['start'](ev);
            } else if (ev.target.textContent == 'Finish') {
                ev.target.parentNode.remove();
                actions['finish'](ev);
            } else if (ev.target.textContent == 'Delete') {
                actions['delete'](ev)
            }
        });
    }

    function eventDelegator(buttons) {
        let functions = {
            start: (e) => {
                e.currentTarget.appendChild(generateButtons(buttons['inProgress']))
                inProgress.children[1].appendChild(e.currentTarget);
            },
            finish: (e) => {
                complete.children[1].appendChild(e.currentTarget);
            },
            delete: (e) => {
                e.currentTarget.remove();
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