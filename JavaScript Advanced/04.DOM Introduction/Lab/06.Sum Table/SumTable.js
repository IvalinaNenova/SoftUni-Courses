function sumTable() {
    let costElements = document.querySelectorAll('tr td:nth-of-type(2)');

    let costCells = Array.from(costElements);
    costCells.pop();
    
    let sum = costCells.reduce((a, x) => {
       return a + Number(x.textContent);
    }, 0)

    let resultElement = document.getElementById('sum');
    resultElement.textContent = sum;
}