function notify(message) {
    let notificationElement = document.querySelector('#notification');

    notificationElement.textContent = message;
    notificationElement.hidden = false;
    notificationElement.style.display = 'block';

    notificationElement.addEventListener('click', (e) => {
        e.target.hidden = true;
        e.target.style.display = 'none';
    })
}