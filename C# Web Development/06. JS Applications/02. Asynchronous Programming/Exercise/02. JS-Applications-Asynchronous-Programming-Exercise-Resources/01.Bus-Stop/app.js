function getInfo() {
    let busStopNameElement = document.querySelector('#stopName');
    let busesElement = document.querySelector('#buses');
    let busInputElement = document.querySelector('#stopId');

    const baseUrl = `http://localhost:3030/jsonstore/bus/businfo`;

    fetch(`${baseUrl}/${busInputElement.value}`)
        .then(response => response.json())
        .then(data => {
            Array.from(busesElement.children).forEach(x => x.remove());

            busStopNameElement.textContent = data.name;

            Object.entries(data.buses).forEach(x => {
                let liElement = document.createElement('li');
                liElement.textContent = `Bus ${x[0]} arrives in ${x[1]} minutes`;

                busesElement.appendChild(liElement);
            })
        })
        .catch(() => {
            Array.from(busesElement.children).forEach(x => x.remove());

            busStopNameElement.textContent = `Error`;
        })
}