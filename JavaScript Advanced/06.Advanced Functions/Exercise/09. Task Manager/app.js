function solve(e) {
    document.querySelector('#add').addEventListener('click', createTask);
    let sections = document.getElementsByTagName('section');
    let addSection = sections[0];
    let openSection = sections[1];
    let inProgress = sections[2];
    let complete = sections[3];

    function createTask(e) {
        e.preventDefault();

        let form = e.target.parentNode;
        let data  = Array.from(form.elements).map(x => x.value).slice(0, 3);
        let elements = ['h3', 'p', 'p'];
        let buttons = {
            open: {green: 'Start', red: 'Delete'},
            inProgress: {red: 'Delete', orange: 'Finish'},
        }
        let article = generateArticle(elements, data, buttons);
        console.log(article);
        openSection.children[1].appendChild(article);
        console.log(article.parentNode.parentNode);

        let actions = eventDelegator();
        article.addEventListener('click', eventDelegator);
       
    }

    function eventDelegator(e){
        if (e.target.tagName != 'BUTTON') {
            return;
        }
        let functions = {
            start: (e) => {
                
                console.log(e.currentTarget)
                e.currentTarget.removeElement('div');
                e.currentTarget.appendChild(generateButtons(buttons['inProgress']))
            }
        }

        return functions;
    }
    function generateArticle(elements, data, buttons) {
        let articleElement = document.createElement('article');

        for(let i = 0; i < elements.length; i++) {
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

    // let divsElement = document.querySelectorAll('section div:nth-of-type(2)');
    // let formElement = document.querySelector('form');
    // let task = formElement.querySelector('#task');
    // let description = formElement.querySelector('#description');
    // let date = formElement.querySelector('#date');

    // let addButton = document.querySelector('#add');
    // addButton.addEventListener('click', onClick);

    // function onClick(e) {
    //     e.preventDefault();
    //     let open = {
    //         title: { 'h3': task.value },
    //         paragraph1: { 'p': `Description: ${description.value}` },
    //         paragraph2: { 'p': `Due Date: ${date.value}` },
    //         buttonsDiv: { 'div': { 'green': 'Start', 'red': 'Delete' } },
    //         display: 1
    //     }
    //     let inProgress = {
    //         title: { 'h3': task.value },
    //         paragraph1: { 'p': `Description: ${description.value}` },
    //         paragraph2: { 'p': `Due Date: ${date.value}` },
    //         buttonsDiv: { 'div': { 'red': 'Delete', 'orange': 'Finish' } },
    //         display: 2
    //     }
    //     let complete = {
    //         title: { 'h3': task.value },
    //         paragraph1: { 'p': `Description: ${description.value}` },
    //         paragraph2: { 'p': `Due Date: ${date.value}` },
    //         display: 3
    //     }

    //     if (e.target.id === 'add') {
    //         if (!task.value || !description.value || !date.value) {
    //             return;
    //         }
    //         createArticle(open);
    //     }
    //     else if (e.target.textContent === 'Start') {
    //         e.target.parentNode.parentNode.remove('article');
    //         createArticle(inProgress)
    //     } else if (e.target.textContent === 'Finish') {
    //         e.target.parentNode.parentNode.remove('article');
    //         createArticle(complete);
    //     } else if (e.target.textContent === 'Delete') {
    //         e.target.parentNode.parentNode.remove('article');
    //     }
    // }
    // function createArticle(obj) {
    //     let articleElement = document.createElement('article');
    //     let info = Object.values(obj);
    //     for (const data of info) {
    //         for (const el in data) {
    //             articleElement.appendChild(createCell(el, data[el]));
    //         }
    //     }
    //     divsElement[Number(obj.display)].appendChild(articleElement);
    // }

    // let createCell = function createChildrean(element, data) {
    //     let cell;
    //     if (element != 'div') {
    //         cell = document.createElement(element);
    //         cell.textContent = data;
    //     } else {
    //         cell = document.createElement(element);
    //         cell.classList.add('flex');
    //         for (const el in data) {
    //             let buttonElement = document.createElement('button');
    //             buttonElement.addEventListener('click', onClick);
    //             buttonElement.classList.add(el)
    //             buttonElement.textContent = data[el];
    //             cell.appendChild(buttonElement)
    //         }
    //     }
    //     return cell;
   // }
}