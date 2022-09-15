function calc() {
    let firstNumberElement = document.getElementById('num1');
    let secondNumberElement = document.getElementById('num2');

    let num1 = Number(firstNumberElement.value);
    let num2 = Number(secondNumberElement.value);

    let resultElement = document.getElementById('sum');
    resultElement.value = num1 + num2;
}
