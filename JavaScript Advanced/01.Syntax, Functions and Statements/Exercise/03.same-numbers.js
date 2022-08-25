function solve(num) {
    let sum = 0;
    let isSame = true;
    let numAsString = num.toString();
    let firstDigit = numAsString[0];

    for (let index = 0; index < numAsString.length; index++) {

        let digit = numAsString[index];
        sum += Number(digit);

        if (firstDigit !== numAsString[index]) {
            isSame = false;
        }
    }

    console.log(isSame);
    console.log(sum);
}

solve(2222222)
solve(1234)