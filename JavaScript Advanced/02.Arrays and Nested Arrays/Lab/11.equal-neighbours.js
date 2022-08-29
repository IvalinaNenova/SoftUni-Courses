function solve(matrix) {

    let numberOfNeighbours = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {


            if (row < matrix.length - 1) {
                if (matrix[row][col] === matrix[row + 1][col]) {
                    numberOfNeighbours++;
                }
            }

            if (matrix[row][col] === matrix[row][col + 1]) {
                numberOfNeighbours++;
            }
        }
    }

    return numberOfNeighbours;
}

console.log(solve([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]
));

console.log(solve([['test', 'yes', 'yo', 'ho'],
                   ['well', 'done', 'yo', '6'],
                   ['not', 'done', 'yet', '5']]
));