function solve(matrix) {

    let rightDiagonalSum = 0;
    let leftDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {

        rightDiagonalSum += matrix[row][row];
        leftDiagonalSum += matrix[row][matrix[row].length - 1 - row];
    }

    let result = rightDiagonalSum + ' ' + leftDiagonalSum;
    return result;
}

console.log(solve([[20, 40],
[10, 60]]
)); 