const flowerShop = require('../flowerShop');
const { assert } = require('chai');

describe('flowerShop test', () => {
    describe('calcPriceOfFlowers tests', () => {
        it('Should work correctly with valid input', () => {
            let flower = 'Roses';
            let price = 5;
            let quantity = 10;

            let expectedResult = `You need $50.00 to buy Roses!`;
            let actualResult = flowerShop.calcPriceOfFlowers(flower, price, quantity);

            assert.equal(actualResult, expectedResult);
        });

        it('Should throw if FLOATING number is passed ( PRICE )', () => {
            let flower = 'Roses';
            let price = 5.5;
            let quantity = 10;

            assert.throw(() => { flowerShop.calcPriceOfFlowers(flower, price, quantity) }, Error);
        });

        it('Should throw if FLOATING number is passed ( QUANTITY )', () => {
            let flower = 'Roses';
            let price = 5;
            let quantity = 10.5;

            assert.throw(() => { flowerShop.calcPriceOfFlowers(flower, price, quantity) }, Error);
        });

        it('Should throw if NOT a string is passed ( FLOWER )', () => {
            let flower = 7;
            let price = 5;
            let quantity = 10;

            assert.throw(() => { flowerShop.calcPriceOfFlowers(flower, price, quantity) }, Error);
        });

        it('Should throw if NOT a number is passed ( PRICE )', () => {
            let flower = 'Roses';
            let price = '5';
            let quantity = 10;

            assert.throw(() => { flowerShop.calcPriceOfFlowers(flower, price, quantity) }, Error);
        });

        it('Should throw if NOT a number is passed ( QUANTITY )', () => {
            let flower = 'Roses';
            let price = 5;
            let quantity = '10';

            assert.throw(() => { flowerShop.calcPriceOfFlowers(flower, price, quantity) }, Error);
        });
    })

    describe('checkFlowersAvailable tests', () => {
        it('Should work correctly with valid input', () => {
            let desiredFlower = 'Roses';
            let flowers = ['Roses', 'Orchids', 'Tulips'];

            let expectedResult = `The Roses are available!`;
            let actualResult = flowerShop.checkFlowersAvailable(desiredFlower, flowers);

            assert.equal(actualResult, expectedResult);
        });

        it('Should work correctly with valid input', () => {
            let desiredFlower = 'asd';
            let flowers = ['Roses', 'Orchids', 'Tulips'];

            let expectedResult = `The asd are sold! You need to purchase more!`;
            let actualResult = flowerShop.checkFlowersAvailable(desiredFlower, flowers);

            assert.equal(actualResult, expectedResult);
        });
    })

    describe('sellFlowers tests', () => {
        it('Should work correctly with valid input', () => {
            let flowers = ['Roses', 'Orchids', 'Tulips'];
            let space = 1;

            let expectedResult = `Roses / Tulips`;
            let actualResult = flowerShop.sellFlowers(flowers, space);

            assert.equal(actualResult, expectedResult);
        });

        it('Should throw if NOT an array is passed', () => {
            let flowers = 'asd';
            let space = 1;

            assert.throw(() => { flowerShop.sellFlowers(flowers, space) }, Error);
        });

        it('Should throw if NOT a number is passed', () => {
            let flowers = ['Roses', 'Orchids', 'Tulips'];
            let space = '1';

            assert.throw(() => { flowerShop.sellFlowers(flowers, space) }, Error);
        });

        it('Should throw if space is negative', () => {
            let flowers = ['Roses', 'Orchids', 'Tulips'];
            let space = -1;

            assert.throw(() => { flowerShop.sellFlowers(flowers, space) }, Error);
        });

        it('Should throw if space is more than garden length', () => {
            let flowers = ['Roses', 'Orchids', 'Tulips'];
            let space = 5;

            assert.throw(() => { flowerShop.sellFlowers(flowers, space) }, Error);
        });
    })
})