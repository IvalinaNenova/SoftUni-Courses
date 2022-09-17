function subtract() {
    let firstNumElement = document.getElementById('firstNumber').value;
    let secondNumElement = document.getElementById('secondNumber').value;

    let num1 = Number(firstNumElement);
    let num2 = Number(secondNumElement);

    let result = num1 - num2;

    let resultElement = document.getElementById('result');
    resultElement.textContent = result;
}