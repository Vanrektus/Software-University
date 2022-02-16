const testNumbers = require('../testNumbers');
const { assert } = require('chai');

describe('testNumbers test', () => {
    describe('sumNumbers tests', () => {
        it('Should work correctly with valid input', () => {
            let num1 = 21;
            let num2 = 27;

            let expectedResult = 48.00;
            let actualResult = testNumbers.sumNumbers(num1, num2);

            assert.equal(actualResult, expectedResult);
        });

        it('Should work correctly with valid input (floating numbers)', () => {
            let num1 = 21.3;
            let num2 = 27.12;

            let expectedResult = 48.42;
            let actualResult = testNumbers.sumNumbers(num1, num2);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return undefined if num1 is NOT a number', () => {
            let num1 = '21';
            let num2 = 27;

            let expectedResult = undefined;
            let actualResult = testNumbers.sumNumbers(num1, num2);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return undefined if num1 is NOT a number', () => {
            let num1 = 21;
            let num2 = '27';

            let expectedResult = undefined;
            let actualResult = testNumbers.sumNumbers(num1, num2);

            assert.equal(actualResult, expectedResult);
        });
    })

    describe('numberChecker tests', () => {
        it('Should work correctly with valid odd input number', () => {
            let num = 27;

            let expectedResult = 'The number is odd!';
            let actualResult = testNumbers.numberChecker(num);

            assert.equal(expectedResult, actualResult);
        });

        it('Should work correctly with valid even input number', () => {
            let num = 30;

            let expectedResult = 'The number is even!';
            let actualResult = testNumbers.numberChecker(num);

            assert.equal(expectedResult, actualResult);
        });

        it('Should throw if NOT a number is passed', () => {
            let num = 'asd';

            assert.throw(() => { testNumbers.numberChecker(num) }, Error);
        });
    })

    describe('averageSumArray tests', () => {
        it('Should work correctly with valid input', () => {
            let numbers = [1, 2, 3, 4, 5];

            let expectedResult = 3;
            let actualResult = testNumbers.averageSumArray(numbers);

            assert.equal(actualResult, expectedResult);
        });

        it('Should work correctly with valid input', () => {
            let numbers = [1.23, 2.34, 3.45, 4.56, 5.67];

            let expectedResult = 3.45;
            let actualResult = testNumbers.averageSumArray(numbers);

            assert.equal(actualResult, expectedResult);
        });
    })
})