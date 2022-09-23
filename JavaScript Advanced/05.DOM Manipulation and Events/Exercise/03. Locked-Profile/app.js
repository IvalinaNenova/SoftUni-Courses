function lockedProfile() {
    let buttonElements = document.querySelectorAll('div button');


    for (let i = 0; i < buttonElements.length; i++) {
        let button = buttonElements[i];
        let profileElement = button.parentElement;
        let lockedElement = profileElement.querySelector('input[value="lock"]');
        let hiddenInfoElement = document.getElementById(`user${i + 1}HiddenFields`);

        button.addEventListener('click', (e) => {

            if (!lockedElement.checked && button.textContent == 'Show more') {
                hiddenInfoElement.style.display = 'block';
                button.textContent = 'Hide it';
            } else if (!lockedElement.checked && button.textContent == 'Hide it') {
                hiddenInfoElement.style.display = 'none';
                button.textContent = 'Show more';
            }
        });
    }
}