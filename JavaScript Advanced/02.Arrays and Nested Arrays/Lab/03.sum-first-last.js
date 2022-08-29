function solve(array) {
    
    let numArray = array.map(x => Number(x));
    let sum = numArray[0] + numArray[numArray.length - 1];

    return sum;
}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));