function solve(nestedArray) {

    let biggestNum = Number.MIN_SAFE_INTEGER;
    for (let row = 0; row < nestedArray.length; row++) {

        let currentBiggest = Math.max(...nestedArray[row]);

        if (currentBiggest >= biggestNum) {
            biggestNum = currentBiggest;
        }
    }

    return biggestNum;
}

console.log(solve([[20, 50, 10],
                   [8, 33, 145]]
   ));  

console.log(solve([[3, 5, 7, 12],
                   [-1, 4, 33, 2],
                   [8, 3, 0, 4]]
   ));