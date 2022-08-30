function solve(array) {

    let numbersMatrix = [];
    array.forEach(el => numbersMatrix.push(el.split(' ').map(Number)));
    
    let size = numbersMatrix.length;

    let rightDiagonalSum = 0;
    let leftDiagonalSum = 0;

    for (let row = 0; row < size; row++) {

        rightDiagonalSum += numbersMatrix[row][row];
        leftDiagonalSum += numbersMatrix[row][size - 1 - row];
    }

    if (rightDiagonalSum == leftDiagonalSum) {

        for (let row = 0; row < size; row++) {
            for (let col = 0; col < size; col++) {
                if (col != size - 1 - row && row != col) {
                    numbersMatrix[row][col] = rightDiagonalSum;
                }
            }           
        }
    } 

    numbersMatrix.forEach(el => console.log(el.join(' ')));
}

solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);