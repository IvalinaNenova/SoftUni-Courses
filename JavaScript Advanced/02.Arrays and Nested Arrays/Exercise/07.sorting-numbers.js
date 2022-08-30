function solve(array) {

    let sorted = array.sort((a, b) => a - b);

    let result = [];

    while (sorted.length != 0) {
        result.push(sorted.shift(), sorted.pop());
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));