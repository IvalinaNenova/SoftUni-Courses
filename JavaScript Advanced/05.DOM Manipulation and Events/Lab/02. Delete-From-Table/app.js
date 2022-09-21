function deleteByEmail() {
    let inputElement = document.querySelector('input[name="email"]');
    let emailElements = document.querySelectorAll('td:nth-of-type(2)');
    let resultElement = document.getElementById('result');

    let emailsArray = Array.from(emailElements);
    let targetElement = emailsArray.find(e => e.textContent == inputElement.value);

    if (targetElement) {
        targetElement.parentNode.remove();
        resultElement.textContent = 'Deleted.';
    } else {
        resultElement.textContent = 'Not found.';
    }
    inputElement.value = '';
}