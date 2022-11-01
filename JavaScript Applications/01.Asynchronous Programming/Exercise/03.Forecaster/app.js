function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/forecaster';
    const forecastDiv = document.querySelector('#forecast');
    let submitButton = document.querySelector('#submit');
    submitButton.addEventListener('click', onClick);
    async function onClick() {
        let location = document.querySelector('#location').value;

        let result = await fetch(`${baseUrl}/locations`);
        let data = await result.json();
        console.log(data);
        let searched = data.find(l => l.name == location);
        console.log(searched);
        console.log(searched.code);

        let todayForecast = await fetch(`${baseUrl}/today/${searched.code}`);
        let todaysData = await todayForecast.json();
        console.log(todaysData);
    }
}

attachEvents();