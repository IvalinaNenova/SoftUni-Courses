function findCommonDivisor(num1, num2) {
    let greatestDivisor;
    for(let i=num1; i>0; i--){
        if (num1 % i == 0 && num2 % i == 0) {
            greatestDivisor = i;
            break;
        }
    }

    return greatestDivisor;
}

console.log(findCommonDivisor(15, 5));
console.log(findCommonDivisor(2154, 458));