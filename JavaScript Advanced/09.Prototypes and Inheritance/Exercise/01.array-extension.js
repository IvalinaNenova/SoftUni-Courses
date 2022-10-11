(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };
    Array.prototype.skip = function (n) {
        let result = [];
        for (let i = n; i < this.length; i++) {
            result.push(this[i]);
        }
        return result;
    };
    Array.prototype.take = function (n) {
        let result = [];
        for (let i = 0; i < n; i++) {
            result.push(this[i]);
        }
        return result;
    };
    Array.prototype.sum = function () {
        let sum = this.reduce((sum, num) => sum + num, 0);
        return sum;
    };
    Array.prototype.average = function () {
        let sum = this.reduce((sum, num) => sum + num, 0);
        let average = sum / this.length;
        return average;
    };
})()

let array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 9];
console.log(array.last());
console.log(array.skip(3));
console.log(array.take(4));
console.log(array.sum());
console.log(array.average());