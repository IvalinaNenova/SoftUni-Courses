class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
        this.string = innerString;
    }

    increase(value) { this.innerLength += value }
    decrease(value) {
        if (this.innerLength - value < 0) {
            this.innerLength = 0;
        } else {
            this.innerLength -= value;
        }
    }
    toString() {
        if (this.innerLength == 0) return '...';
        else if (this.innerLength < this.innerString.length) {
            this.string = this.innerString.substring(0, this.innerLength) + '...';
            return this.string;
        } else {
            return this.innerString;
        }
    }
}
let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
