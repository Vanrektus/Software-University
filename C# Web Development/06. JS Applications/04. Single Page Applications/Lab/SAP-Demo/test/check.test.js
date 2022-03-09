const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

let browser;
let page;
const baseUrl = 'http://127.0.0.1:3000/';

describe('SoftUni page tests', function() {
    this.timeout(10000);

    before(async() => {
        browser = await chromium.launch();
    });

    after(async() => {
        await browser.close();
    });

    beforeEach(async() => {
        page = await browser.newPage();
    });

    afterEach(async() => {
        await page.close();
    });

    it('Should load register page', async() => {
        await page.goto(baseUrl);

        await page.click('text=Register');

        let expectedHeading = 'Username';
        let actualHeading = await page.textContent('label[for=username]');

        assert.equal(actualHeading, expectedHeading);
    });
})