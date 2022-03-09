const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

let browser;
let page;
const baseUrl = 'http://localhost:3000/';

describe('SoftUni page tests', function() {
    this.timeout(10000);

    before(async() => {
        browser = await chromium.launch({ headless: false, slowMo: 300 });
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

    it('Should show books in table', async() => {
        await page.goto(`${baseUrl}/03.SoftTerest/`);

        await page.click('text=LOAD ALL BOOKS');

        let expectedLength = 2;

        let actualLength = await page.evaluate(() => {
            let booksSectionElement = document.querySelector('tbody');
            let count = booksSectionElement.children.length;
            return count;
        });

        assert.equal(actualLength, expectedLength);
    });
})