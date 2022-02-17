const cinema = require('../cinema');
const { assert } = require('chai');

describe('cinema tests', () => {
    describe('showMovies tests', () => {
        it('Should work correctly with valid input (1 movie)', () => {
            let movies = ['Thor', 'Joker', 'Avengers'];

            let expectedResult = 'Thor, Joker, Avengers';
            let actualResult = cinema.showMovies(movies);

            assert.equal(actualResult, expectedResult);
        });

        it('Should work correctly with valid input (more movies)', () => {
            let movies = ['Thor', 'Joker', 'Avengers'];

            let expectedResult = 'Thor, Joker, Avengers';
            let actualResult = cinema.showMovies(movies);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input length is 0', () => {
            let movies = [];

            let expectedResult = 'There are currently no movies to show.';
            let actualResult = cinema.showMovies(movies);

            assert.equal(actualResult, expectedResult);
        });
    })

    describe('ticketPrice tests', () => {
        it('Should work correctly with valid input', () => {
            let projectionType = 'Premiere';

            let expectedResult = '12.00';
            let actualResult = cinema.ticketPrice(projectionType);

            assert.equal(actualResult, expectedResult);
        });

        it('Should work correctly with valid input', () => {
            let projectionType = 'Normal';

            let expectedResult = '7.50';
            let actualResult = cinema.ticketPrice(projectionType);

            assert.equal(actualResult, expectedResult);
        });

        it('Should work correctly with valid input', () => {
            let projectionType = 'Discount';

            let expectedResult = '5.50';
            let actualResult = cinema.ticketPrice(projectionType);

            assert.equal(actualResult, expectedResult);
        });

        it('Should throw if invalid projectionType is passed', () => {
            let projectionType = 'asd';

            assert.throw(() => { cinema.ticketPrice(projectionType) }, Error);
        });
    })

    describe('swapSeatsInHall tests', () => {
        it('Should work correctly with valid input (NORMAL)', () => {
            let firstPlace = 6;
            let secondPlace = 7;

            let expectedResult = "Successful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should work correctly with valid input (20)', () => {
            let firstPlace = 20;
            let secondPlace = 7;

            let expectedResult = "Successful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should work correctly with valid input (1)', () => {
            let firstPlace = 6;
            let secondPlace = 1;

            let expectedResult = "Successful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should work correctly with valid input (1 and 20)', () => {
            let firstPlace = 1;
            let secondPlace = 20;

            let expectedResult = "Successful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input1 is INVALID (NEGATIVE)', () => {
            let firstPlace = -6;
            let secondPlace = 7;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input2 is INVALID (NEGATIVE)', () => {
            let firstPlace = 6;
            let secondPlace = -7;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input1 is INVALID (FLOATING NUMBER)', () => {
            let firstPlace = 6.25;
            let secondPlace = 7;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input2 is INVALID (FLOATING NUMBER)', () => {
            let firstPlace = 6;
            let secondPlace = 7.23;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input1 is INVALID (STRING)', () => {
            let firstPlace = '6';
            let secondPlace = 7;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input2 is INVALID (STRING)', () => {
            let firstPlace = 6;
            let secondPlace = '7';

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input1 is INVALID (OVER 20)', () => {
            let firstPlace = 21;
            let secondPlace = 7;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input2 is INVALID (OVER 20)', () => {
            let firstPlace = 6;
            let secondPlace = 27;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input1 is INVALID (0)', () => {
            let firstPlace = 0;
            let secondPlace = 7;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input2 is INVALID (0)', () => {
            let firstPlace = 6;
            let secondPlace = 0;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if input1 is INVALID (DOESNT EXIST)', () => {
            let firstPlace = 21;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if both inputs are NOT passed', () => {
            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall();

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if inputs are the same', () => {
            let firstPlace = 7;
            let secondPlace = 7;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });

        it('Should return error message if inputs are the same', () => {
            let firstPlace = 27;
            let secondPlace = 27;

            let expectedResult = "Unsuccessful change of seats in the hall.";
            let actualResult = cinema.swapSeatsInHall(firstPlace, secondPlace);

            assert.equal(actualResult, expectedResult);
        });
    })
})