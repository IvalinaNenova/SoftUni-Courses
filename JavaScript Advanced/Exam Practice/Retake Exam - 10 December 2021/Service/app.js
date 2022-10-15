window.addEventListener('load', solve);

function solve() {
    let form = document.querySelector("form");

    form.addEventListener("submit", function (e) {
        e.preventDefault();
        let inputElements = Array.from(form.elements).slice(0, -1);
        let inputValues = inputElements.map(input => input.value);

        if (inputValues.includes('')) return;

        let received = document.querySelector('#received-orders');
        let receivedDiv = creator('div', null, 'container');

        receivedDiv.appendChild(creator('h2', 'Product type for repair: ' + inputValues[0]));
        receivedDiv.appendChild(creator('h3', 'Client information: ' + `${inputValues[2]}, ${inputValues[3]}`));
        receivedDiv.appendChild(creator('h4', 'Description of the problem: ' + inputValues[1]));
        let startButton = creator('button', 'Start repair', 'start-btn');
        let finishButton = creator('button', 'Finish repair', 'finish-btn');
        finishButton.disabled = true;
        receivedDiv.appendChild(startButton);
        receivedDiv.appendChild(finishButton);

        received.appendChild(receivedDiv);

        let completed = document.querySelector('#completed-orders');
        let clearButton = document.querySelector('.clear-btn');

        startButton.addEventListener('click', () =>{
            finishButton.disabled = false;
            startButton.disabled = true;
        });

        finishButton.addEventListener('click', (e) =>{
            receivedDiv.removeChild(startButton);
            receivedDiv.removeChild(finishButton);
            completed.appendChild(receivedDiv);
        });

        clearButton.addEventListener('click', () =>{
            let allCompleted = completed.getElementsByClassName('container');
            console.log(allCompleted);
            while(allCompleted[0]){
                completed.removeChild(allCompleted[0]);
            }
        });

        inputElements.forEach(el=> el.value = '');
    });

    function creator(tag, text = null, className = null, id = null, type = null) { 
        let el = document.createElement(tag); 
        if (text) { el.textContent = text; } 
        if (type) { el.type = type; } 
        if (id) { el.id = id; } 
        if (className) { el.className = className; } 
        return el; 
    } 
}