const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

let browser;
let page;
const baseUrl = 'http://localhost:3000/';

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

    it('Should load all articles', async() => {
        await page.goto(baseUrl);

        let expectedArticlesLenght = 4;

        let actualArticlesLenght = await page.evaluate(() => {
            let articlesSectionElement = document.querySelector('#main');
            let count = articlesSectionElement.children.length;
            return count;
        });

        assert.equal(actualArticlesLenght, expectedArticlesLenght);
    });

    it('Should work when more button is clicked', async() => {
        await page.goto(baseUrl);

        let buttonElement = await page.evaluate(() => {
            let allButtonsElement = document.querySelectorAll('#main button');
            return allButtonsElement[3];
        });

        await page.click('text=More');

        let expected = 'Less';

        let actual = await page.textContent('#main .head button');

        assert.equal(actual, expected);
    });
})