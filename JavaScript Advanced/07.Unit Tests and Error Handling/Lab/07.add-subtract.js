function createCalculator() {
    let value = 0;
    return {
        add: function (num) { value += Number(num); },
        subtract: function (num) { value -= Number(num); },
        get: function () { return value; }
    }
}
let func = createCalculator();
func.add(50);
func.add(40);
func.add(30);
console.log(func.get());
module.exports = { createCalculator };