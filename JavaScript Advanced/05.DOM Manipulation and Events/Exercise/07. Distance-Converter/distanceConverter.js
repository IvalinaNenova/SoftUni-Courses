function attachEventsListeners() {
    let [inputElement, outputElement] = document.querySelectorAll('input[type="text"]');
    let buttonElement = document.getElementById('convert');

    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');

    let rations = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    }

    let convert = function (){
        let valueToConvert = Number(inputElement.value);
        let unitFrom = inputUnits.value;
        let unitTo = outputUnits.value;

        let valueToMeters = valueToConvert * rations[unitFrom];

        let result = valueToMeters / rations[unitTo];
        outputElement.value = result;
    }

    buttonElement.addEventListener('click', convert);
}