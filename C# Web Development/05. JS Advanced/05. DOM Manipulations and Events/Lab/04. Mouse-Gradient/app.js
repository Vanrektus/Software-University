function attachGradientEvents() {
    let gradientElement = document.querySelector('#gradient');
    let resultElement = document.querySelector('#result');

    gradientElement.addEventListener('mousemove', (e) => {
        let percentage = Math.floor((e.offsetX / gradientElement.clientWidth) * 100);

        resultElement.textContent = `${percentage}%`;
    })
    gradientElement.addEventListener('mouseout', () => {
        resultElement.textContent = '';
    })
}