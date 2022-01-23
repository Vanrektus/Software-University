function attachEventsListeners() {
    let mainElement = document.querySelector('main');

    mainElement.addEventListener('click', (e) => {
        let daysElement = document.querySelector('#days');
        let hoursElement = document.querySelector('#hours');
        let minutesElement = document.querySelector('#minutes');
        let secondsElement = document.querySelector('#seconds');

        switch (e.target.id) {
            case 'daysBtn':
                let daysInputElementValue = Number(document.querySelector('#days').value);

                hoursElement.value = daysInputElementValue * 24;
                minutesElement.value = daysInputElementValue * 1440;
                secondsElement.value = daysInputElementValue * 86400;
                break;

            case 'hoursBtn':
                let hoursInputElementValue = Number(document.querySelector('#hours').value);

                daysElement.value = hoursInputElementValue / 24;
                minutesElement.value = hoursInputElementValue * 60;
                secondsElement.value = hoursInputElementValue * 3600;
                break;

            case 'minutesBtn':
                let minutesInputElementValue = Number(document.querySelector('#minutes').value);

                daysElement.value = minutesInputElementValue / 1440;
                hoursElement.value = minutesInputElementValue / 60;
                secondsElement.value = minutesInputElementValue * 60;
                break;

            case 'secondsBtn':
                let secondsInputElementValue = Number(document.querySelector('#seconds').value);

                daysElement.value = secondsInputElementValue / 86400;
                hoursElement.value = secondsInputElementValue / 3600;
                minutesElement.value = secondsInputElementValue / 60;
                break;
        }
    });
}