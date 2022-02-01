const mathEnforcer = require('../math-enforcer');
const { assert, expect } = require('chai');

describe('Math enforcer test functionallity', () => {
    describe('addFive function test', () => {
        it('Should should add 5 if a positive number is passed', () => {
            let num = 10;
            let expectedResult = 15;

            let actualResult = mathEnforcer.addFive(num);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should add 5 if a negative number is passed', () => {
            let num = -5;
            let expectedResult = 0;

            let actualResult = mathEnforcer.addFive(num);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should add 5 if a floating number is passed', () => {
            let num = 5.5;
            let expectedResult = 10.5;

            let actualResult = mathEnforcer.addFive(num);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should add 5 if a floating number is passed', () => {
            let num = 7.14;
            let expectedResultUp = 14.7;
            let expectedResultDown = 4.17;

            let actualResult = mathEnforcer.addFive(num);

            expect(actualResult).to.be.closeTo(expectedResultUp, expectedResultDown);
        });

        it('Should return undefined if NOT a number is passed', () => {
            let num = 'Pesho';
            let expectedResult = undefined;

            let actualResult = mathEnforcer.addFive(num);

            assert.equal(actualResult, expectedResult);
        });
    });

    describe('subtractTen function test', () => {
        it('Should should subtract 10 if a positive number is passed', () => {
            let num = 15;
            let expectedResult = 5;

            let actualResult = mathEnforcer.subtractTen(num);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should subtract 10 if a negative number is passed', () => {
            let num = -10;
            let expectedResult = -20;

            let actualResult = mathEnforcer.subtractTen(num);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should subtract 10 if a floating number is passed', () => {
            let num = 10.5;
            let expectedResult = 0.5;

            let actualResult = mathEnforcer.subtractTen(num);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should subtract 10 if a floating number is passed', () => {
            let num = 15;
            let expectedResultUp = 0.714;
            let expectedResultDown = 7.14;

            let actualResult = mathEnforcer.subtractTen(num);

            expect(actualResult).to.be.closeTo(expectedResultUp, expectedResultDown);
        });

        it('Should return undefined if NOT a number is passed', () => {
            let num = 'Pesho';
            let expectedResult = undefined;

            let actualResult = mathEnforcer.subtractTen(num);

            assert.equal(actualResult, expectedResult);
        });
    });

    describe('sum function test', () => {
        it('Should should sum numbers if positive numbers are passed', () => {
            let num1 = 10;
            let num2 = 20;
            let expectedResult = 30;

            let actualResult = mathEnforcer.sum(num1, num2);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should sum numbers if negative numbers are passed', () => {
            let num1 = -10;
            let num2 = -20;
            let expectedResult = -30;

            let actualResult = mathEnforcer.sum(num1, num2);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should sum numbers if positive and negative numbers are passed', () => {
            let num1 = 10;
            let num2 = -20;
            let expectedResult = -10;

            let actualResult = mathEnforcer.sum(num1, num2);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should sum numbers if negative and positive numbers are passed', () => {
            let num1 = -10;
            let num2 = 20;
            let expectedResult = 10;

            let actualResult = mathEnforcer.sum(num1, num2);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should sum numbers if floating numbers are passed', () => {
            let num1 = 11.5;
            let num2 = 21.5;
            let expectedResult = 33;

            let actualResult = mathEnforcer.sum(num1, num2);

            assert.equal(actualResult, expectedResult);
        });

        it('Should should sum numbers if floating numbers are passed', () => {
            let num1 = 11.5;
            let num2 = 21.5;
            let expectedResultUp = 33.5;
            let expectedResultDown = 32.5;

            let actualResult = mathEnforcer.sum(num1, num2);

            expect(actualResult).to.be.closeTo(expectedResultUp, expectedResultDown);
        });

        it('Should return undefined if NOT a number is passed', () => {
            let num1 = 10;
            let num2 = '20';
            let expectedResult = undefined;

            let actualResult = mathEnforcer.sum(num1, num2);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return undefined if NOT a number is passed', () => {
            let num1 = '10';
            let num2 = 20;
            let expectedResult = undefined;

            let actualResult = mathEnforcer.sum(num1, num2);

            assert.equal(actualResult, expectedResult);
        });
    });
});