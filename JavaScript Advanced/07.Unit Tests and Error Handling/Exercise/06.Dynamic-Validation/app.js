function validate() {
    let emailElement = document.getElementById('email');
    const validPattern = /^([a-z]+@{1}[a-z]+\.{1}[a-z]+)$/gm;
    emailElement.addEventListener('change', (e) => {
        console.log(e.target);
        if (validPattern.test(e.target.value)) {
            e.currentTarget.removeAttribute('class');
        } else {
            e.currentTarget.classList.add('error');
        }
    })
}