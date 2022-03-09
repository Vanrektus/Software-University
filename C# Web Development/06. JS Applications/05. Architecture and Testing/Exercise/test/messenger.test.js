// const { chromium } = require('playwright-chromium');
// const { assert } = require('chai');

// let browser;
// let page;
// const baseUrl = 'http://localhost:3000/';

// describe('SoftUni page tests', function() {
//     this.timeout(10000);

//     before(async() => {
//         browser = await chromium.launch({ headless: false, slowMo: 1000 });
//     });

//     after(async() => {
//         await browser.close();
//     });

//     beforeEach(async() => {
//         page = await browser.newPage();
//     });

//     afterEach(async() => {
//         await page.close();
//     });

//     it('Should show messages in text box', async() => {
//         await page.goto(`${baseUrl}/01.Messenger/`);

//         await page.click('text=Refresh');

//         let expectedTexareaValue = 'Spami: Hello, are you there?\nGarry: Yep, whats up :?\nSpami: How are you? Long time no see? :)\nGeorge: Hello, guys! :))\nSpami: Hello, George nice to see you! :)))';

//         let actualTextareaValue = await page.evaluate(() => {
//             return document.querySelector('#messages').value;
//         });

//         assert.equal(actualTextareaValue, expectedTexareaValue);
//     });

//     it('Should add new message and show it in text box', async() => {
//         await page.goto(`${baseUrl}/01.Messenger/`);

//         await page.locator('#author').fill('Ivan');

//         await page.locator('#content').fill('Hi, everyone!');

//         await page.locator('text=Send').click();

//         await page.click('text=Refresh');

//         let expectedTexareaValue = 'Spami: Hello, are you there?\nGarry: Yep, whats up :?\nSpami: How are you? Long time no see? :)\nGeorge: Hello, guys! :))\nSpami: Hello, George nice to see you! :)))\nIvan: Hi, everyone!';

//         let actualTextareaValue = await page.evaluate(() => {
//             return document.querySelector('#messages').value;
//         });

//         assert.equal(actualTextareaValue, expectedTexareaValue);
//     });
// })