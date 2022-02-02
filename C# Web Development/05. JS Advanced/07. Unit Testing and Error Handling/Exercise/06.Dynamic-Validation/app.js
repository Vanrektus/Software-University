function validate() {
    let regex = /[a-z]+\@[a-z]+\.[a-z]+/;
    let emailElement = document.querySelector('#email');

    emailElement.addEventListener('change', (e) => {
        if (!e.target.value.match(regex)) {
            e.target.classList.add('error');
        } else {
            e.target.classList.remove('error');
        }
    });
}