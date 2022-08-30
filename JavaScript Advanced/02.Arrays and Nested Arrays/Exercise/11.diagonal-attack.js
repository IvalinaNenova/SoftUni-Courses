function solve(array) {

    let squareMatrix = fillMatrix(array);
    let size = squareMatrix.length;

    let rightDiagonalSum = 0;
    let leftDiagonalSum = 0;

    for (let row = 0; row < size; row++) {

        rightDiagonalSum += squareMatrix[row][row];
        leftDiagonalSum += squareMatrix[row][size - 1 - row];
    }

    if (rightDiagonalSum == leftDiagonalSum) {

        for (let row = 0; row < size; row++) {
            for (let col = 0; col < size; col++) {
                if (col != size - 1 - row && row != col) {
                    squareMatrix[row][col] = rightDiagonalSum;
                }
            }           
        }
    } 

    squareMatrix.forEach(el => console.log(el.join(' ')));

    function fillMatrix(array) {
        let matrix = [];

        for (let row = 0; row < array.length; row++) {
            matrix[row] = array[row].split(' ').map(x => Number(x));
        }

        return matrix;
    }
}

solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);