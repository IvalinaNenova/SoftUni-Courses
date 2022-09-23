function attachEventsListeners() {
    let buttonsElements = document.querySelectorAll('div input[type="button"]');
    let inputElements = document.querySelectorAll('div input[type="text"]');

    const rations = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    }

    let convert = function (value, unit) {
        let days = Number(value) / rations[unit];

        let converted = {
            days: days,
            hours: days * rations.hours,
            minutes: days * rations.minutes,
            seconds: days * rations.seconds
        }

        return converted;
    }

    let onConvertHandler = function (e) {
        let inputElement = e.target.parentNode.querySelector('input[type="text"]');
        let valueToConvert = inputElement.value;
        let convertFrom = inputElement.id;

        let convertedObject = convert(valueToConvert, convertFrom);

        for (const inputElement of inputElements) {
            let id = inputElement.id;
            inputElement.value = convertedObject[id];
        }
    }

    for (const button of buttonsElements) {
        button.addEventListener('click', onConvertHandler);
    }
}