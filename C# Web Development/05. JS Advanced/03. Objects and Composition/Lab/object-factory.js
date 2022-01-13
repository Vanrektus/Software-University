function solve(library, orders) {
    return orders.map(composeObject);

    function composeObject(order) {
        let finalOrder = Object.assign({}, order.template);

        for (const part of order.parts) {
            finalOrder[part] = library[part];
        }

        return finalOrder;
    }
}

function solve2(library, orders) {
    const result = [];

    for (const order of orders) {
        // Create empty object and copy properties from template
        const device = Object.assign({}, order.template);

        // Compose methods from library for every item in parts
        for (const part of order.parts) {
            device[part] = library[part];
        }

        // Save result
        result.push(device);
    }

    return result;
}

const library = {
    print: function () {
        console.log(`${this.name} is printing a page`);
    },
    scan: function () {
        console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
        console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
};

const orders = [
    {
        template: { name: "ACME Printer" },
        parts: ["print"],
    },
    {
        template: { name: "Initech Scanner" },
        parts: ["scan"],
    },
    {
        template: { name: "ComTron Copier" },
        parts: ["scan", "print"],
    },
    {
        template: { name: "BoomBox Stereo" },
        parts: ["play"],
    },
];

console.log(solve(library, orders));
