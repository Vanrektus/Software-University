const isOddOrEven = require('../even-or-odd');
const { assert } = require('chai');

describe('Even or odd test functionallity', () => {
    it('Should work correctly if string is passed (odd test)', () => {
        let input = 'Pesho';
        let expectedResult = 'odd';

        let actualResult = isOddOrEven(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should work correctly if string is passed (even test)', () => {
        let input = 'PeshoGosho';
        let expectedResult = 'even';

        let actualResult = isOddOrEven(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should work NOT if a number is passed', () => {
        let input = 7;
        let expectedResult = undefined;

        let actualResult = isOddOrEven(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should work NOT if an array is passed', () => {
        let input = ['Pesho'];
        let expectedResult = undefined;

        let actualResult = isOddOrEven(input);

        assert.equal(actualResult, expectedResult);
    });


    it('Should work NOT if an object is passed', () => {
        let input = {
            name: 'Pesho',
        };
        let expectedResult = undefined;

        let actualResult = isOddOrEven(input);

        assert.equal(actualResult, expectedResult);
    });
});