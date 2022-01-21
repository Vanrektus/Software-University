// WITH EVENT DELEGATION
function solve() {
    let element = document.querySelector('.shopping-cart');
    let productsSet = new Set();
    let totalPrice = 0;

    element.addEventListener('click', (e) => {
        if (e.target && e.target.className === 'add-product') {
            let productName = e.target.parentNode.parentNode.querySelector('.product-title').textContent;
            let productPrice = Number(e.target.parentNode.parentNode.querySelector('.product-line-price').textContent);

            productsSet.add(productName);
            totalPrice += productPrice;

            document.querySelector('textarea').textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
        }

        if (e.target && e.target.className === 'checkout') {
            let addProductButtons = document.querySelectorAll('button');

            for (const currButton of addProductButtons) {
                currButton.setAttribute('disabled', true);
            }

            let productsArray = Array.from(productsSet);

            document.querySelector('textarea').textContent += `You bought ${productsArray.join(', ')} for ${totalPrice.toFixed(2)}.`;
        }
    });
}