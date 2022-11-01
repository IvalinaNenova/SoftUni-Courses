function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/forecaster';
    const forecastDiv = document.querySelector('#forecast');
    const currentDiv = document.querySelector('#current');
    const upcomingDiv = document.querySelector('#upcoming');
    let todaysDiv = createTag('div', null, 'forecasts');
    let threeDayForecast = createTag('div', null, 'forecast-info');

    const symbols = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂',
        'Degrees': '°'

    }
    const submitButton = document.querySelector('#submit');
    submitButton.addEventListener('click', onClick);

    async function onClick() {
        todaysDiv.innerHTML = '';
        threeDayForecast.innerHTML = '';
        let location = document.querySelector('#location').value;

        try {

            let result = await fetch(`${baseUrl}/locations`);
            let data = await result.json();

            let searched = data.find(l => l.name == location);

            let todayForecast = await fetch(`${baseUrl}/today/${searched.code}`);
            let todaysData = await todayForecast.json();

            let upcoming = await fetch(`${baseUrl}/upcoming/${searched.code}`);
            let upcomingData = await upcoming.json();

            displayTodaysData(todaysData);
            displayUpcomingData(upcomingData);


        } catch (error) {
            todaysDiv.innerHTML = '';
            threeDayForecast.innerHTML = '';
            forecastDiv.style.display = 'block';
            let errorSpan = document.createElement('span');
            errorSpan.textContent = 'Error';
            forecastDiv.appendChild(errorSpan);
        }

    }
    function displayTodaysData(object) {
        forecastDiv.style.display = 'block';

        todaysDiv.appendChild(createTag('span', symbols[object.forecast.condition], 'condition symbol'));

        let dataSpan = createTag('span', null, 'condition');
        dataSpan.appendChild(createTag('span', object.name, 'forecast-data'));
        dataSpan.appendChild(createTag('span', `${object.forecast.low}°/${object.forecast.high}°`, 'forecast-data'));
        dataSpan.appendChild(createTag('span', `${object.forecast.condition}`, 'forecast-data'));

        todaysDiv.appendChild(dataSpan);
        currentDiv.appendChild(todaysDiv);

    }

    function displayUpcomingData(object) {

        for (const day of object.forecast) {
            let spanElement = createTag('span', null, 'upcoming');
            spanElement.appendChild(createTag('span', symbols[day.condition], 'symbol'));
            spanElement.appendChild(createTag('span', `${day.low}°/${day.high}°`, 'forecast-data'));
            spanElement.appendChild(createTag('span', `${day.condition}`, 'forecast-data'));

            threeDayForecast.appendChild(spanElement);
        }

        upcomingDiv.appendChild(threeDayForecast);
    }
    function createTag(tag, text = null, className = null) {
        let el = document.createElement(tag);
        if (text) { el.textContent = text; }
        if (className) { el.className = className; }
        return el;
    }
}

attachEvents();