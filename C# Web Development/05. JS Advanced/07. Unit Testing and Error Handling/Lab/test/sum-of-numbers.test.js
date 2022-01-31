const sum = require('../sum-of-numbers');
const { assert } = require('chai');

describe('Sum of numbers test functionallity', () => {
    it('Should add positive numbers correctly', () => {
        let input = [1, 2, 3, 4, 5];
        let expectedResult = 15;

        let actualResult = sum(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should add negative numbers correctly', () => {
        let input = [-1, -2, -3, -4, -5];
        let expectedResult = -15;

        let actualResult = sum(input);

        assert.equal(actualResult, expectedResult);
    });
});