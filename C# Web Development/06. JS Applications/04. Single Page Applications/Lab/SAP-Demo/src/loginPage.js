let loginSection = document.querySelector('section.login');

function showPage() {
    loginSection.removeAttribute('class', 'hidden');
}

function hidePage() {
    loginSection.setAttribute('class', 'hidden');
}

export default {
    showPage,
    hidePage,
}