const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

let browser;
let page;
const baseUrl = 'http://localhost:3000/';

describe('SoftUni page tests', function() {
    this.timeout(10000);

    before(async() => {
        browser = await chromium.launch({ headless: false, slowMo: 2000 });
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
        await page.goto(`${baseUrl}/02.Book-Library/`);

        await page.click('text=LOAD ALL BOOKS');

        let expectedLength = 2;

        let actualLength = await page.evaluate(() => {
            let booksSectionElement = document.querySelector('tbody');
            let count = booksSectionElement.children.length;
            return count;
        });

        assert.equal(actualLength, expectedLength);
    });

    it('Should add new book and show it in table', async() => {
        await page.goto(`${baseUrl}/02.Book-Library/`);

        await page.locator('text=FORM TITLE AUTHOR Submit >> [placeholder="Title\\.\\.\\."]').fill("Ivan's book");

        await page.locator('text=FORM TITLE AUTHOR Submit >> [placeholder="Author\\.\\.\\."]').fill('Ivn');

        await page.locator('text=Submit').click();

        await page.click('text=LOAD ALL BOOKS');

        let expectedLength = 3;

        let actualLength = await page.evaluate(() => {
            let booksSectionElement = document.querySelector('tbody');
            let count = booksSectionElement.children.length;
            return count;
        });

        assert.equal(actualLength, expectedLength);
    });

    it('Should edit the new book and show it in table', async() => {
        await page.goto(`${baseUrl}/02.Book-Library/`);

        await page.click('text=LOAD ALL BOOKS');

        await page.locator('button:has-text("Edit")').nth(2).click();

        await page.locator('text=Edit FORM TITLE AUTHOR Save >> [placeholder="Title\\.\\.\\."]').fill("The Book of Ivan");

        await page.locator('text=Edit FORM TITLE AUTHOR Save >> [placeholder="Author\\.\\.\\."]').fill('Ivan');

        await page.locator('text=Save').click();

        await page.click('text=LOAD ALL BOOKS');

        let expectedTitle = "The Book of Ivan";
        let expectedAuthor = 'Ivan';

        let actualText = await page.evaluate(() => {
            let booksSectionElement = document.querySelector('tbody');
            let desiredBookElement = booksSectionElement.children[2];
            let actualData = {
                title: desiredBookElement.children[0].textContent,
                author: desiredBookElement.children[1].textContent,
            }
            return actualData;
        });

        assert.equal(actualText.title, expectedTitle);
        assert.equal(actualText.author, expectedAuthor);
    });

    it('Should delete the new book and show it in table', async() => {
        await page.goto(`${baseUrl}/02.Book-Library/`);

        await page.locator('text=LOAD ALL BOOKS').click();
        page.once('dialog', dialog => {
            console.log(`Dialog message: ${dialog.message()}`);
            dialog.accept().catch(() => {});
        });
        await page.locator('text=Delete').nth(2).click();

        await page.locator('text=LOAD ALL BOOKS').click();

        let expectedLength = 2;

        let actualLength = await page.evaluate(() => {
            let booksSectionElement = document.querySelector('tbody');
            let count = booksSectionElement.children.length;
            return count;
        });

        assert.equal(actualLength, expectedLength);
    });
})