const lookupChar = require('../char-lookup');
const { assert } = require('chai');

describe('Char lookup test functionallity', () => {
    it('Should work correctly if correct types and values are passed', () => {
        let string = 'Pesho';
        let index = 2;
        let expectedResult = 's';

        let actualResult = lookupChar(string, index);

        assert.equal(actualResult, expectedResult);
    });

    it('Should return undefined if NOT a string is passed', () => {
        let string = 3;
        let index = 2;
        let expectedResult = undefined;

        let actualResult = lookupChar(string, index);

        assert.equal(actualResult, expectedResult);
    });

    it('Should return undefined if NOT a number is passed', () => {
        let string = 'Pesho';
        let index = '2';
        let expectedResult = undefined;

        let actualResult = lookupChar(string, index);

        assert.equal(actualResult, expectedResult);
    });

    it('Should return undefined if NOT an INTEGER is passed', () => {
        let string = 'Pesho';
        let index = 5.5;
        let expectedResult = undefined;

        let actualResult = lookupChar(string, index);

        assert.equal(actualResult, expectedResult);
    });

    it('Should return error message if index is out of range', () => {
        let string = 'Pesho';
        let index = 5;
        let expectedResult = 'Incorrect index';

        let actualResult = lookupChar(string, index);

        assert.equal(actualResult, expectedResult);
    });

    it('Should return error message if index is out of range', () => {
        let string = 'Pesho';
        let index = -5;
        let expectedResult = 'Incorrect index';

        let actualResult = lookupChar(string, index);

        assert.equal(actualResult, expectedResult);
    });
});