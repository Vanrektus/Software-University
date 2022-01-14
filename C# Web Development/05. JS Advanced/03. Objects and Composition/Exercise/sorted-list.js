function solve() {
    const list = [];

    const commands = {
        add(number) {
            list.push(number);

            sortElements(list);
        },
        remove(index) {
            if (index >= 0 && index < list.length) {
                list.splice(index, 1);

                sortElements(list);
            }
        },
        get(index) {
            if (index >= 0 && index < list.length) {
                return list[index];
            }
        },
        get size() {
            return list.length;
        },
    };

    return commands;

    function sortElements(list) {
        return list.sort((a, b) => a - b);
    }
}

let list = solve();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);

console.log("=========");

let list2 = solve();
list2.add(7);
list2.add(6);
list2.add(5);
//console.log(list2.size());
console.log(list2.size);
list2.remove(-1);
//console.log(list2.get(-1));
console.log(list2.get(0));
list2.remove(1);
console.log(list2.get(1));
