function validate(e) {
    let formElement = document.getElementById('registerForm');
    let company = document.querySelector("#company");
    let companyInfo = document.querySelector("#companyInfo");
    let validMessage = document.querySelector('#valid')

    company.addEventListener("change", (e) => {
        if (company.checked) {
            companyInfo.style.display = "block";
        } else {
            companyInfo.style.display = "none";
        }
    });

    formElement.addEventListener('submit', (e) => {
        e.preventDefault();

        let usernamePattern = /^[A-Za-z0-9]{3,20}$/;
        let passwordPattern = /^[\w]{5,15}$/;
        let emailPattern = /^[^@.]+@[^@]*\.[^@]*$/;

        let [username, email, password, confirmPassword] = Array.from(formElement.elements).slice(1);

        if (usernamePattern.test(username.value) == true) {
            username.style.borderColor = 'none';
        } else {
            username.style.borderColor = 'red';
        }

        if (emailPattern.test(email.value) == true) {
            email.style.borderColor = 'none'
        } else {
            email.style.borderColor = 'red';
        }

        if (passwordPattern.test(password.value) == true
            && passwordPattern.test(confirmPassword.value) == true
            && password.value == confirmPassword.value) {
            password.style.borderColor = 'none';
            confirmPassword.style.borderColor = 'none';

        } else {
            password.style.borderColor = 'red';
            confirmPassword.style.borderColor = 'red';
        }

        if (company.checked) {
            let companyField = document.querySelector('#companyNumber')
            if (companyField.value < 1000 || companyField.value > 9999) {
                companyField.style.borderColor = "red";
            } else {
                companyField.style.borderColor = "";
            }
        }
        let finalForm = Array.from(formElement.elements).slice(1).map(x => x.style.borderColor);

        if (!finalForm.some(x => x == 'red')) {
            validMessage.style.display = 'block';
        } else {
            validMessage.style.display = 'none';
        }
        console.log(finalForm);
    });
}
