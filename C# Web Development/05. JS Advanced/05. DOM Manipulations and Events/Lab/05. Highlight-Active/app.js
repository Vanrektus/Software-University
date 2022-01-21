// WITH EVENT DELEGATION
function focused() {
    let divElement = document.querySelector('div');

    divElement.addEventListener('focus', (e) => {
        if (e.target && e.target.nodeName === 'INPUT') {
            e.target.parentElement.setAttribute('class', 'focused');
        }
    }, true);

    divElement.addEventListener('blur', (e) => {
        if (e.target && e.target.nodeName === 'INPUT') {
            e.target.parentElement.removeAttribute('class', 'focused');
        }
    }, true);
}