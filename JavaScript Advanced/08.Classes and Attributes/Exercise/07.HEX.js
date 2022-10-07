class Hex {
    constructor(value) {
        this.value = value;
    }
    valueOf() { return this.value; }
    toString() { return `0x${this.value.toString(16).toUpperCase()}`; }
    plus(value) { return new Hex(this.value + value); }
    minus(value) { return new Hex(this.value - value); }
    parse(value) { return parseInt(value, 16); }
}
let FF = new Hex(255);
console.log(FF.toString()); //0xFF;
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString()); //0XF
console.log(a.plus(b).toString() === '0xF'); //true
console.log(FF.parse('AAA')); //2730
