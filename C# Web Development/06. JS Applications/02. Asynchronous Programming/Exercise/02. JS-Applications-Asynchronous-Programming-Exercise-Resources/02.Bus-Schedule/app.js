function solve() {
    let infoElement = document.querySelector('.info');

    let departButtonElement = document.querySelector('#depart');
    let arriveButtonElement = document.querySelector('#arrive');

    let uri = `http://localhost:3030/jsonstore/bus/schedule/depot`;

    function depart() {
        fetch(uri)
            .then(res => res.json())
            .then(data => {
                infoElement.textContent = `Next stop ${data.name}`;

                departButtonElement.disabled = true;
                arriveButtonElement.disabled = false;
            })
            .catch(() => {
                infoElement.textContent = 'Error';

                departButtonElement.disabled = true;
                arriveButtonElement.disabled = false;
            })
    }

    function arrive() {
        fetch(uri)
            .then(res => res.json())
            .then(data => {
                infoElement.textContent = `Arriving at ${data.name}`;

                uri = `http://localhost:3030/jsonstore/bus/schedule/${data.next}`;

                departButtonElement.disabled = false;
                arriveButtonElement.disabled = true;
            })
            .catch(() => {
                infoElement.textContent = 'Error';

                departButtonElement.disabled = false;
                arriveButtonElement.disabled = true;
            })
    }

    return {
        depart,
        arrive
    };
}

let result = solve();