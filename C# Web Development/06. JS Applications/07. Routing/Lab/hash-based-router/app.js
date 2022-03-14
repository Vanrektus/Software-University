const routes = {
    '#home': `<div><h2>Home</h2><p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Placeat, repellendus!</p></div>`,
    '#products': `<div><h2>Products</h2><ul><li>Product1</li><li>Product2</li><li>Product3</li></ul></div>`,
    '#pricing': `<div><h2>Pricing</h2><p>Our prices!</p></div>`,
    '#about-us': `<div><h2>About us</h2><p>Some info about us!</p></div>`,
};

window.addEventListener('hashchange', (e) => {
    router(location.hash);
});

function router(hash) {
    let rootElement = document.querySelector('.root');

    rootElement.innerHTML = routes[hash];
}

router(location.hash || '#home');