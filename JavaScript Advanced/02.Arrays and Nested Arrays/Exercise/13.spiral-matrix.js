function solve(rows, cols) {

    let num = 0;
    let maxNum = rows * cols;
    let minRow = 0;
    let minCol = 0;
    let maxRow = rows - 1;
    let maxCol = cols - 1;

    let matrix = [];
    for (let r = 0; r < rows; r++) {
        matrix[r] = [];
    }

    while (num < maxNum) {
        //Go right
        for (let col = minCol; col <= maxCol && num < maxNum; col++) {
            matrix[minRow][col] = ++num;
        }
        minRow++;
        
        //Go down
        for (let row = minRow; row <= maxRow && num < maxNum; row++) {
            matrix[row][maxCol] = ++num;
        }
        maxCol--;

        //Go right
        for (let col = maxCol; col >= minCol && num < maxNum; col--) {
            matrix[maxRow][col] = ++num;
        }
        maxRow--;

        //Go up
        for (let row = maxRow; row >= minRow && num < maxNum; row--) {
            matrix[row][minCol] = ++num;      
        }
        minCol++;
    }

    matrix.forEach(row => console.log(row.join(' ')));
}

solve(3, 3);
solve(5, 5);