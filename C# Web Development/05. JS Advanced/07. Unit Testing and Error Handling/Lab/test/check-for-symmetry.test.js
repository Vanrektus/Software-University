const isSymmetric = require('../check-for-symmetry');
const { assert } = require('chai');

describe('Check for symmetry test functionallity', () => {
    it('Should work with an array of numbers passed', () => {
        let input = [1, 2, 3, 2, 1];
        let expectedResult = true;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should work with an array of strings passed', () => {
        let input = ['Pesho', 'Gosho', 'Pesho'];
        let expectedResult = true;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work with a string passed', () => {
        let input = 'Pesho';
        let expectedResult = false;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if array is not symmetric', () => {
        let input = [1, 2, 3, 2, 3];
        let expectedResult = false;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    })

    it('Should NOT work with different types in the array passed', () => {
        let input = [1, '1'];
        let expectedResult = false;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    });
});