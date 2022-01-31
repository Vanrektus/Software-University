const createCalculator = require('../add-subtract');
const { assert, expect } = require('chai');

describe('Add/Subtract test functionallity', () => {
    let test;

    beforeEach(() => {
        test = createCalculator();
    });

    it('Should return 0 if nothing is added', () => {
        let expectedResult = 0;

        let actualResult = test.get();

        assert.equal(actualResult, expectedResult);
    });

    it('Should add positive numbers correctly', () => {
        let number = 10;
        let expectedResult = 10;

        test.add(number);
        let actualResult = test.get();

        assert.equal(actualResult, expectedResult);
    });

    it('Should add negative numbers correctly', () => {
        let number = -10;
        let expectedResult = -10;

        test.add(number);
        let actualResult = test.get();

        assert.equal(actualResult, expectedResult);
    });

    it('Should subtract positive numbers correctly', () => {
        let number = 10;
        let expectedResult = -10;

        test.subtract(number);
        let actualResult = test.get();

        assert.equal(actualResult, expectedResult);
    });

    it('Should subtract negative numbers correctly', () => {
        let number = -10;
        let expectedResult = 10;

        test.subtract(number);
        let actualResult = test.get();

        assert.equal(actualResult, expectedResult);
    });

    it('Should add positive floating numbers correctly', () => {
        let number = 10.5;
        let expectedResult = 10.5;

        test.add(number);
        let actualResult = test.get();

        assert.equal(actualResult, expectedResult);
    });

    it('Should subtract positive floating numbers correctly', () => {
        let number = 10.5;
        let expectedResult = -10.5;

        test.subtract(number);
        let actualResult = test.get();

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if string is added', () => {
        let number = 'Pesho';
        let expectedResult = NaN;

        test.add(number);
        let actualResult = test.get();

        expect(actualResult).to.be.NaN;
    });

    it('Should NOT work if string is subtracted', () => {
        let number = 'Pesho';
        let expectedResult = NaN;

        test.subtract(number);
        let actualResult = test.get();

        expect(actualResult).to.be.NaN;
    });
});