function solve(array) {
    let [rows, cols, startRow, startCol] = array;

    let matrix = [];
    for (let row = 0; row < rows; row++) {
         matrix[row] = [];
    }

    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
            let num = Math.max(Math.abs(startRow - row), Math.abs(startCol - col)) + 1;
            matrix[row][col] = num;         
        }
    }

    matrix.forEach(row => console.log(row.join(' ')));
}


solve([4, 4, 0, 0]);
solve([5, 5, 2, 2]);
solve([3, 3, 2, 2]);