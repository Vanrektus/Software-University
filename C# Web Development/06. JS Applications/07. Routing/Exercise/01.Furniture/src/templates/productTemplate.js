import { html } from '../lib.js';

export default (product) => html `
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="${product.img}" />
                <p>${product.description}</p>
                <footer>
                    <p>Price: <span>${product.price} $</span></p>
                </footer>
                <div>
                    <a href="/details/${product._id}" class="btn btn-info">Details</a>
                </div>
            </div>
        </div>
    </div>
`;