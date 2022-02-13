(function solve() {
    Array.prototype.last = function() {
        return this[this.length - 1];
    };

    Array.prototype.skip = function(n) {
        return this.slice(n, this.length);
    };

    Array.prototype.take = function(n) {
        let result = this.slice();
        result.splice(n, result.length);
        return result;
    };

    Array.prototype.sum = function() {
        return this.reduce(function(a, x) {
            return a + x;
        }, 0);
    };

    Array.prototype.average = function() {
        return this.sum() / this.length;
    };
})();

let arr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
arr.splice(3, arr.length);
console.log(arr);