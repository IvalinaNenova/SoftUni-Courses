function solve(array) {

    let biggestNum = array[0];

    // let result = array.filter(el => {
    //     if (el >= biggestNum) {
    //         biggestNum = el;
    //         return true;
    //     }
    //     return false;
    // });
    let result = [];
    array.reduce((acc, el) => {
        if (el >= biggestNum) {
            biggestNum = el;
            acc.push(el);
        }

        return acc;
    }, result);

    return result;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3, 4]));
console.log(solve([20, 3, 2, 15, 6, 1]));