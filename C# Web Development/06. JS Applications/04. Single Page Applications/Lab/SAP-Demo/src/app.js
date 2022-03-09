import registerPage from './registerPage.js';
import loginPage from './loginPage.js';

let headerElement = document.querySelector('.header .nav');

let pages = {
    'register': registerPage,
    'login': loginPage
}

headerElement.addEventListener('click', (e) => {
    e.preventDefault();

    if (e.target.tagName == 'A') {
        let dataLink = e.target.getAttribute('data-link');

        if (!Object.keys(pages).includes(dataLink)) {
            return;
        }

        hidePages();

        let currentView = pages[dataLink];
        currentView.showPage();
    }
});

function hidePages() {
    Object.values(pages).forEach(x => x.hidePage());
}