function generateReport() {
    let checkedBoxesIndices = [];
    let checkedBoxes = document.querySelectorAll('input');

    // checkedBoxes.forEach((el, index) => {
    //     if (el.checked) {
    //         checkedBoxesIndices.push(index);
    // };
    
    for (let i = 0; i < checkedBoxes.length; i++) {
        const element = checkedBoxes[i];

        if (element.checked) {
            checkedBoxesIndices.push(i);
        }
    }

    let result = [];
    let rowsElements = document.querySelectorAll('tbody tr');
    let rows = Array.from(rowsElements);

    for (const row of rows) {
        let object = {};

        for (const index of checkedBoxesIndices) {
            let propertyName = checkedBoxes[index].name;
            let propertyData = row.children[index].textContent;
            object[propertyName] = propertyData;
        }

        result.push(object);
    }

    let report = JSON.stringify(result);
    let outputElement = document.getElementById('output');
    outputElement.textContent = report;
}