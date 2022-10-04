function solve(input, start, end) {
    if (!Array.isArray(input)) {
        return NaN;
    }
    let startIndex = Math.max(start, 0);
    let endIndex = Math.min(end, input.length - 1);

    let sum  = input.slice(startIndex, endIndex + 1)
        .map(x => Number(x))
        .reduce((acc, num) => acc + num, 0);

    return sum;
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(solve([10, 'twenty', 30, 40], 0, 2));