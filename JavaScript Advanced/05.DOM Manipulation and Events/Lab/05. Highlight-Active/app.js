function focused() {
    let inputElements = document.querySelectorAll('input');

    let focus = function (e) {
        e.target.parentNode.classList.add('focused');
    }

    let unFocus = function (e) {
        e.target.parentNode.classList.remove('focused');
    };

    for (const el of inputElements) {
        el.addEventListener('focus', focus);
        el.addEventListener('blur', unFocus);
    }
}
