function validate() {
    let inputElement = document.getElementById('email');
    let pattern = /[a-z]+@[a-z]+.[a-z]+/g;

    let validate = function (e) {
        if (pattern.test(e.currentTarget.value)) {
            e.currentTarget.removeAttribute('class');
        } else {
            e.currentTarget.classList.add('error');
        }
    }

    inputElement.addEventListener('change', validate);
}