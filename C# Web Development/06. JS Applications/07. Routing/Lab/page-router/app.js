import page from './node_modules/page/page.mjs';
import homeView from './src/views/homeView.js';
import productsView from './src/views/productsView.js';
import productView from './src/views/productView.js'
import aboutView from './src/views/aboutView.js';

page('/home', homeView);
page('/products', productsView);
page('/products/:id', productView);
page('/about-us', aboutView);

page('/', '/home');

page.start();