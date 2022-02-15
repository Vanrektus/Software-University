const library = require('../03. Library/library');
const { assert, expect } = require('chai');

describe('Library test', () => {
    describe('calcPriceOfBook tests', () => {
        it('Should work correctly with newer year', () => {
            let bookName = 'Warcraft';
            let bookYear = 2005;

            expect(library.calcPriceOfBook(bookName, bookYear)).to.equal(`Price of ${bookName} is 20.00`);
        });

        it('Should work correctly with older year', () => {
            let bookName = 'Warcraft';
            let bookYear = 1980;

            expect(library.calcPriceOfBook(bookName, bookYear)).to.equal(`Price of ${bookName} is 10.00`);
        });

        it('Should throw if invalid string', () => {
            let bookName = 7;
            let bookYear = 1980;

            expect(() => library.calcPriceOfBook(bookName, bookYear)).to.throw("Invalid input");
        });

        it('Should throw if invalid year', () => {
            let bookName = 'Warcraft';
            let bookYear = '1980';

            expect(() => library.calcPriceOfBook(bookName, bookYear)).to.throw("Invalid input");
        });
    })

    describe('findBook tests', () => {
        it('Should work correctly when book is found', () => {
            let books = ["Bez Poshtada", "Warcraft", "Game of Thrones"];
            let desiredBook = 'Warcraft';

            expect(library.findBook(books, desiredBook)).to.equal("We found the book you want.");
        });

        it('Should work correctly when book is NOT found', () => {
            let books = ["Bez Poshtada", "Warcraft", "Game of Thrones"];
            let desiredBook = 'asd';

            expect(library.findBook(books, desiredBook)).to.equal("The book you are looking for is not here!");
        });

        it('Should throw if there are no books', () => {
            let books = [];
            let desiredBook = 'Warcraft';

            expect(() => library.findBook(books, desiredBook)).to.throw("No books currently available");
        });
    })

    describe('arrangeTheBooks test', () => {
        it('Should work correctly when there is enough space', () => {
            let booksCount = 27;

            expect(library.arrangeTheBooks(booksCount)).to.equal("Great job, the books are arranged.");
        });

        it('Should work correctly when there is JUST enough space', () => {
            let booksCount = 40;

            expect(library.arrangeTheBooks(booksCount)).to.equal("Great job, the books are arranged.");
        });

        it('Should work correctly when there is NOT enough space', () => {
            let booksCount = 69;

            expect(library.arrangeTheBooks(booksCount)).to.equal("Insufficient space, more shelves need to be purchased.");
        });

        it('Should throw if input is invalid (NOT a number)', () => {
            let booksCount = '27';

            expect(() => library.arrangeTheBooks(booksCount)).to.throw("Invalid input");
        });

        it('Should throw if input is invalid (negative number)', () => {
            let booksCount = -27;

            expect(() => library.arrangeTheBooks(booksCount)).to.throw("Invalid input");
        });
    })
})