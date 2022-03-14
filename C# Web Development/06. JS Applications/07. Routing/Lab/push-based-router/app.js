const routes = {
    '/home': `<div><h2>Home</h2><p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Placeat, repellendus!</p></div>`,
    '/products': `<div><h2>Products</h2><ul><li>Product1</li><li>Product2</li><li>Product3</li></ul></div>`,
    '/pricing': `<div><h2>Pricing</h2><p>Our prices!</p></div>`,
    '/about-us': `<div><h2>About us</h2><p>Some info about us!</p></div>`,
};

updateContent(location.pathname == '/' ? '/home' : location.pathname);

document.querySelector('#navigation').addEventListener('click', (e) => {
    if (e.target.tagName == 'A') {
        e.preventDefault();

        navigate(e.target.href);
    }
});

window.addEventListener('popstate', (e) => {
    updateContent(location.pathname);
});

function navigate(url) {
    history.pushState({}, '', url);

    let popStateEvent = new PopStateEvent('popstate');
    dispatchEvent(popStateEvent);
}

function updateContent(pathname) {
    let rootElement = document.querySelector('.root');

    rootElement.innerHTML = routes[pathname];
}