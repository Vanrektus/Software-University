function lockedProfile() {
    let mainElement = document.querySelector('#main');

    mainElement.addEventListener('click', (e) => {
        if (e.target && e.target.tagName === 'BUTTON') {
            let radioElement = e.target.parentNode.querySelector('input[type="radio"]:checked');

            if (radioElement.value === 'unlock') {
                switch (e.target.textContent) {
                    case 'Show more':
                        e.target.previousElementSibling.style.display = 'block';

                        e.target.textContent = 'Hide it';
                        break;

                    case 'Hide it':
                        e.target.previousElementSibling.style.display = 'none';

                        e.target.textContent = 'Show more';
                        break;
                }
            }
        }
    })
}