class LibraryCollection {
    constructor(capacity) {
        this.capacity = Number(capacity);
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.books.length === this.capacity) {
            throw new Error("Not enough space in the collection.");
        }

        this.books.push({
            bookName,
            bookAuthor,
            payed: false,
        });

        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName) {
        let desiredBook = this.books.find(x => x.bookName === bookName);

        if (!desiredBook) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        if (desiredBook.payed) {
            throw new Error(`${bookName} has already been paid.`);
        }

        desiredBook.payed = true;

        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName) {
        let desiredBook = this.books.find(x => x.bookName === bookName);

        if (!desiredBook) {
            throw new Error("The book, you're looking for, is not found.");
        }

        if (!desiredBook.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        this.books = this.books.filter(x => x !== desiredBook);

        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        let output = ``;

        if (bookAuthor) {
            let desiredAuthorBook = this.books.find(x => x.bookAuthor === bookAuthor);

            if (!desiredAuthorBook) {
                throw new Error(`${bookAuthor} is not in the collection.`);
            }

            output = `${desiredAuthorBook.bookName} == ${bookAuthor} - ${desiredAuthorBook.payed ? 'Has Paid' : 'Not Paid'}.`;

            return output;
        }

        this.books = this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));

        output = `The book collection has ${this.capacity - this.books.length} empty spots left.`;

        for (const currBook of this.books) {
            output += `\n${currBook.bookName} == ${currBook.bookAuthor} - ${currBook.payed ? 'Has Paid' : 'Not Paid'}.`;
        }

        return output;
    }
}