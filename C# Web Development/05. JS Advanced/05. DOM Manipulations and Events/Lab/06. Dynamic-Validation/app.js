function validate() {
    let inputElement = document.querySelector('#email');

    let regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    inputElement.addEventListener('change', (e) => {
        if (regex.test(e.target.value)) {
            e.target.removeAttribute('class');

            return;
        }

        e.target.className = 'error';
    });
}