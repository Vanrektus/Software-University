function attachEvents() {
    let inputElement = document.querySelector('#location');

    let submitButtonElement = document.querySelector('#submit');
    submitButtonElement.addEventListener('click', submitFunction);

    let baseUrl = `http://localhost:3030/jsonstore/forecaster/locations`;

    const conditions = {
        'Sunny': '☀',
        'Partly Sunny': `⛅`,
        'Overcast': `☁`,
        'Rain': `☂`,
    }

    function submitFunction() {
        let forecastDivElement = document.querySelector('#forecast');
        forecastDivElement.setAttribute('style', 'display:block');

        let todayForecastElement = document.querySelector('#current');
        let upcomingForecastElement = document.querySelector('#upcoming');

        if (todayForecastElement.childElementCount > 1) {
            todayForecastElement.children[1].remove();
            upcomingForecastElement.children[1].remove();
        }

        if (forecastDivElement.children.length === 3) {
            forecastDivElement.firstChild.remove();
        }

        fetch(baseUrl)
            .then(res => res.json())
            .then(locations => {
                console.log(locations);
                let location = locations.find(x => x.name === inputElement.value);

                return fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`)
                    .then(res => res.json())
                    .then(todayWeatherData => ({
                        code: location.code,
                        todayWeatherData
                    }));
            })
            .then(({ code, todayWeatherData }) => {
                let divElement = createTodayReport(todayWeatherData);

                todayForecastElement.appendChild(divElement);

                return fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`)
                    .then(res => res.json())
                    .then(upcomingWeatherData => ({ upcomingWeatherData }));
            })
            .then(({ upcomingWeatherData }) => {
                let divElement = createUpcomingReport(upcomingWeatherData);

                upcomingForecastElement.appendChild(divElement);
            })
            .catch((error) => {
                let errorDivElement = document.createElement('div');
                errorDivElement.setAttribute('class', 'label');
                errorDivElement.textContent = 'Error';

                forecastDivElement.prepend(errorDivElement);
            });

        function createTodayReport(data) {
            let divElement = document.createElement('div');
            divElement.setAttribute('class', 'forecasts');

            let symbolSpanElement = document.createElement('span');
            symbolSpanElement.setAttribute('class', 'condition symbol');
            symbolSpanElement.textContent = conditions[data.forecast.condition];

            let conditionSpanElement = document.createElement('span');
            conditionSpanElement.setAttribute('class', 'condition');

            let nameSpanElement = document.createElement('span');
            nameSpanElement.setAttribute('class', 'forecast-data');
            nameSpanElement.textContent = data.name;

            let degreeSpanElement = document.createElement('span');
            degreeSpanElement.setAttribute('class', 'forecast-data');
            degreeSpanElement.textContent = `${data.forecast.low}°/${data.forecast.high}°`;

            let weatherTypeSpanElement = document.createElement('span');
            weatherTypeSpanElement.setAttribute('class', 'forecast-data');
            weatherTypeSpanElement.textContent = data.forecast.condition;

            conditionSpanElement.appendChild(nameSpanElement);
            conditionSpanElement.appendChild(degreeSpanElement);
            conditionSpanElement.appendChild(weatherTypeSpanElement);

            divElement.appendChild(symbolSpanElement);
            divElement.appendChild(conditionSpanElement);

            return divElement;
        }

        function createUpcomingReport(data) {
            let divElement = document.createElement('div');
            divElement.setAttribute('class', 'forecast-info');

            for (let i = 0; i < 3; i++) {
                let upcomingSpanElement = document.createElement('span');
                upcomingSpanElement.setAttribute('class', 'upcoming');

                let symbolSpanElement = document.createElement('span');
                symbolSpanElement.setAttribute('class', 'symbol');
                symbolSpanElement.textContent = conditions[data.forecast[i].condition];

                let degreeSpanElement = document.createElement('span');
                degreeSpanElement.setAttribute('class', 'forecast-data');
                degreeSpanElement.textContent = `${data.forecast[i].low}°/${data.forecast[i].high}°`;

                let weatherTypeSpanElement = document.createElement('span');
                weatherTypeSpanElement.setAttribute('class', 'forecast-data');
                weatherTypeSpanElement.textContent = data.forecast[i].condition;

                upcomingSpanElement.appendChild(symbolSpanElement);
                upcomingSpanElement.appendChild(degreeSpanElement);
                upcomingSpanElement.appendChild(weatherTypeSpanElement);

                divElement.appendChild(upcomingSpanElement);
            }

            return divElement;
        }
    }
}

attachEvents();