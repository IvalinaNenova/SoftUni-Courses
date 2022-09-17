function toggle() {
    let buttonElement = document.getElementsByClassName('button')[0];
    let divElement = document.getElementById('extra');

    if (buttonElement.textContent == 'More') {
        buttonElement.textContent = 'Less';
        divElement.style.display = 'block';
    } else {
        buttonElement.textContent = 'More';
        divElement.style.display = 'none';
    }
}