const PaymentPackage = require('../payment-package');
const { assert, expect } = require('chai');

describe('Payment package class test functionallity', () => {
    describe('Name tests', () => {
        it('Constructor should work correctly when correct input passed', () => {
            let newInstance = new PaymentPackage('Pesho', 1234);

            let expectedName = 'Pesho';
            let actualName = newInstance._name;

            let expectedValue = 1234;
            let actualValue = newInstance._value;

            let expectedVAT = 20;
            let actualVAT = newInstance._VAT;

            let expectedActive = true;
            let actualActive = newInstance._active;

            assert.equal(actualName, expectedName);
            assert.equal(expectedValue, actualValue);
            assert.equal(expectedVAT, actualVAT);
            assert.equal(expectedActive, actualActive);
        });

        it('Should work correctly if correct name input is passed', () => {
            expect(() => new PaymentPackage('asd', 1234)).not.to.throw('Name must a non-empty string');
        });

        it('Should throw error if INCORRECT name input is passed (number)', () => {
            expect(() => new PaymentPackage(123, 1234)).to.throw('Name must be a non-empty string');
        });

        it('Should throw error if INCORRECT name input is passed (array)', () => {
            expect(() => new PaymentPackage(['asd'], 1234)).to.throw('Name must be a non-empty string');
        })

        it('Should throw error if INCORRECT name input is passed (empty)', () => {
            expect(() => new PaymentPackage('', 1234)).to.throw('Name must be a non-empty string');
        })
    })

    describe('Value tests', () => {
        it('Should work correctly if correct value input is passed', () => {
            expect(() => new PaymentPackage('asd', 1234)).not.to.throw('Value must be a non-negative number');
        });

        it('Should throw error if INCORRECT value input is passed (string)', () => {
            expect(() => new PaymentPackage('asd', 'asd')).to.throw('Value must be a non-negative number');
        });

        it('Should throw error if INCORRECT value input is passed (array)', () => {
            expect(() => new PaymentPackage('asd', [123])).to.throw('Value must be a non-negative number');
        });

        it('Should throw error if INCORRECT value input is passed (negative)', () => {
            expect(() => new PaymentPackage('asd', -123)).to.throw('Value must be a non-negative number');
        });

        it('Set value to null', () => {
            let newInstance = new PaymentPackage('asd', 1234);
            assert.doesNotThrow(() => { newInstance.value = 0 });
        })
    })

    describe('VAT tests', () => {
        it('Should work correctly if correct vat input is passed', () => {
            let newInstance = new PaymentPackage('asd', 1234);
            expect(() => newInstance.VAT = 123).not.to.throw('VAT must be a non-negative number');
        });

        it('Should throw error if INCORRECT vat input is passed (string)', () => {
            let newInstance = new PaymentPackage('asd', 1234);
            expect(() => newInstance.VAT = 'asd').to.throw('VAT must be a non-negative number');
        });

        it('Should throw error if INCORRECT vat input is passed (array)', () => {
            let newInstance = new PaymentPackage('asd', 1234);
            expect(() => newInstance.VAT = ['asd']).to.throw('VAT must be a non-negative number');
        });

        it('Should throw error if INCORRECT vat input is passed (negative)', () => {
            let newInstance = new PaymentPackage('asd', 1234);
            expect(() => newInstance.VAT = -123).to.throw('VAT must be a non-negative number');
        });
    })

    describe('Active tests', () => {
        it('Should work correctly if correct active input is passed', () => {
            let newInstance = new PaymentPackage('asd', 1234);
            expect(() => newInstance.active = true).not.to.throw('Active status must be a boolean');
        });

        it('Should throw error if INCORRECT vat input is passed (string)', () => {
            let newInstance = new PaymentPackage('asd', 1234);
            expect(() => newInstance.active = 'asd').to.throw('Active status must be a boolean');
        });

        it('Should throw error if INCORRECT vat input is passed (array)', () => {
            let newInstance = new PaymentPackage('asd', 1234);
            expect(() => newInstance.active = ['asd']).to.throw('Active status must be a boolean');
        });

        it('Should throw error if INCORRECT vat input is passed (negative)', () => {
            let newInstance = new PaymentPackage('asd', 1234);
            expect(() => newInstance.active = -123).to.throw('Active status must be a boolean');
        });
    })

    describe('toString method tests', () => {
        it('Should return a string as all the input is correct - 1', () => {
            let flagClass = new PaymentPackage('abc', 123);
            let output = [
                `Package: abc`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 20%): 147.6`
            ]
            expect(flagClass.toString()).to.equal(output.join('\n'));
        });

        it('Should return a string as all the input is correct - 2', () => {
            let flagClass = new PaymentPackage('abc', 123);
            flagClass.VAT = 30;
            let output = [
                `Package: abc`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 30%): 159.9`
            ]
            expect(flagClass.toString()).to.equal(output.join('\n'));
        });

        it('Should return a string as all the input is correct - 3', () => {
            let flagClass = new PaymentPackage('abc', 123);
            flagClass.active = false;
            let output = [
                `Package: abc (inactive)`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 20%): 147.6`
            ]
            expect(flagClass.toString()).to.equal(output.join('\n'));
        });

        it('Should return a string as all the input is correct - 4', () => {
            let flagClass = new PaymentPackage('abc', 123);
            flagClass.VAT = 30;
            flagClass.active = false;
            let output = [
                `Package: abc (inactive)`,
                `- Value (excl. VAT): 123`,
                `- Value (VAT 30%): 159.9`
            ]
            expect(flagClass.toString()).to.equal(output.join('\n'));
        });
    })
})