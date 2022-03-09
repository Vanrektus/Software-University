const { chromium } = require('playwright-chromium');
const { assert, expect } = require('chai');

let browser;
let page;

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

    it('Should load trainers page', async() => {
        await page.goto('https://softuni.bg/');

        await page.click('text=ПРЕПОДАВАТЕЛИ');

        let heading = await page.textContent('.trainers-page-content-header-info-title');

        expect(heading.trim()).to.be.equal('Преподаватели');
    })
})