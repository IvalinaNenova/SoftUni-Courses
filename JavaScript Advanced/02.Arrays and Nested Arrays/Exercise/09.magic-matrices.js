function solve(matrix) {

    let size = matrix.length;
    let targetSum = matrix[0].reduce((acc, num) => acc + num);
    let rowSum = 0;
    let isMagic = true;

    matrix.forEach(arr => {
        rowSum = arr.reduce((acc, num) => acc + num);
        if (rowSum != targetSum) {
            isMagic = false;
        }
    })

    if (!isMagic) {
        return false;
    }

    for (let col = 0; col < size; col++) {
        let colSum = 0;
        for (let row = 0; row < size; row++) {
            colSum += matrix[row][col];
        }

        if (colSum != targetSum) {
            isMagic = false;
            break;
        }
    }

    return isMagic;
}

console.log(solve([[4, 5, 6],
                   [6, 5, 4],
                   [5, 5, 5]]
                   ));

console.log(solve([[11, 32, 45],
                   [21, 0, 1],
                   [21, 1, 1]]
                   ));