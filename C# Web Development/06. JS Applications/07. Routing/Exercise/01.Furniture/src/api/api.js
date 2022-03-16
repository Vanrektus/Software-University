let userData;

export function isLoggedin() {
    userData = localStorage.getItem('userData');

    return userData == null ? false : true;
}

export function updateNavBar() {
    userData = localStorage.getItem('userData');

    let userNav = document.querySelector('#user');
    let guestNav = document.querySelector('#guest');

    userData ? guestNav.setAttribute('class', 'hidden') : guestNav.removeAttribute('class', 'hidden');
    userData ? userNav.removeAttribute('class', 'hidden') : userNav.setAttribute('class', 'hidden');
}

export function isOwner() {
    userData = localStorage.getItem('userData');

    return userData.id;
}

export function updateDetailsButtons(currFurniture) {
    userData = localStorage.getItem('userData');
    const userDataId = JSON.parse(localStorage.getItem('userData')).id;

    let editBtn = document.querySelector('.btn-info');
    let deleteBtn = document.querySelector('.btn-red');

    userDataId === currFurniture._ownerId ? editBtn.setAttribute('class', 'btn btn-info') : editBtn.setAttribute('class', 'btn btn-info hidden');
    userDataId === currFurniture._ownerId ? deleteBtn.setAttribute('class', 'btn btn-red') : deleteBtn.setAttribute('class', 'btn btn-info hidden');
}