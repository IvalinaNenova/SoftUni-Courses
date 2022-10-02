function solve(e) {
    document.getElementsByTagName('form')[0].addEventListener('submit', createTask);
    let sections = document.getElementsByTagName('section');
    let sectionsNodes = document.querySelectorAll('section'); 
    let openSection = sections[1];
    let inProgress = sections[2];
    let complete = sections[3];

    console.log(sections[2].children);
    console.log(sectionsNodes[2].children);

    function createTask(e) {
        e.preventDefault();
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