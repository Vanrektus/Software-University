class List {
    constructor() {
        this.numbers = [];
        this.size = this.numbers.length
    }

    add(element) {
        this.numbers.push(element);
        this.size++;
        this.numbers.sort((a, b) => a - b);
        return;
    }

    remove(index) {
        if (index < 0 || index > this.numbers.length - 1) {
            return;
        }

        this.size--;
        return this.numbers.splice(index, 1);
    }

    get(index) {
        if (index < 0 || index > this.numbers.length - 1) {
            return;
        }

        return this.numbers[index];
    }
}

let list = new List();
list.add(5);
console.log(list.get(0));
list.add(3);
console.log(list.get(0));
list.remove(0);
console.log(list.get(0));
console.log(list.size);