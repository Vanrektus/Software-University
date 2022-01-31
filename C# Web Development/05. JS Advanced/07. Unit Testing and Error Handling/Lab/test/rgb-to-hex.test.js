const rgbToHexColor = require('../rgb-to-hex');
const { assert } = require('chai');

describe('RGB to Hex test functionallity', () => {
    it('Should work with correct input passed', () => {
        let red = 100;
        let green = 150;
        let blue = 200;
        let expectedResult = '#6496C8';

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should work with correct input passed (second test)', () => {
        let red = 0;
        let green = 0;
        let blue = 0;
        let expectedResult = '#000000';

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should work with correct input passed (third test)', () => {
        let red = 255;
        let green = 255;
        let blue = 255;
        let expectedResult = '#FFFFFF';

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if red is negative', () => {
        let red = -100;
        let green = 150;
        let blue = 200;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if green is negative', () => {
        let red = 100;
        let green = -150;
        let blue = 200;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if blue is negative', () => {
        let red = 100;
        let green = 150;
        let blue = -200;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if red is over 255', () => {
        let red = 300;
        let green = 150;
        let blue = 200;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if green is over 255', () => {
        let red = 100;
        let green = 350;
        let blue = 200;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if blue is over 255', () => {
        let red = 100;
        let green = 150;
        let blue = 300;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if a string input is passed', () => {
        let red = 'Pesho';
        let green = 150;
        let blue = 300;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if all inputs are strings', () => {
        let red = 'Pesho';
        let green = 'Gosho';
        let blue = 'Tosho';
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if input is floating number', () => {
        let red = 100.5;
        let green = 150;
        let blue = 200;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if all inputs are negative', () => {
        let red = -100;
        let green = -150;
        let blue = -200;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if all inputs are over 255', () => {
        let red = 300;
        let green = 350;
        let blue = 405;
        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.equal(actualResult, expectedResult);
    });

    it('Should NOT work if no input is passed', () => {
        let expectedResult = undefined;

        let actualResult = rgbToHexColor();

        assert.equal(actualResult, expectedResult);
    });
});