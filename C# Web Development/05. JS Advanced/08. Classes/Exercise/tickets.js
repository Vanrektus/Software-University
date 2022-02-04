function solve(inputArr, sortCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let sortedArray = [];

    inputArr.forEach(x => {
        let [destination, price, status] = x.split('|');
        let currTicket = new Ticket(destination, price, status);
        sortedArray.push(currTicket);
    });

    switch (sortCriteria) {
        case 'destination':
        case 'status':
            sortedArray.sort((a, b) => a[sortCriteria].localeCompare(b[sortCriteria]));
            break;

        case 'price':
            sortedArray.sort((a, b) => a[sortCriteria] - b[sortCriteria]);
            break;
    }

    return sortedArray;
}

console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'
    ],
    'destination'
));