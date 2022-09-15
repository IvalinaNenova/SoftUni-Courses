function colorize() {
    let tableElements = document.querySelectorAll('tr:nth-of-type(2n)');
    let tableElementsArray = Array.from(tableElements);
    
    tableElementsArray.forEach(x => {
        x.style.backgroundColor = 'teal';
    })

    // let tableElements = document.getElementsByTagName('tr');
    // let rows = Array.from(tableElements);

    // rows.forEach((x, i) =>{
    //     if (i % 2 != 0 ) {
    //         x.style.backgroundColor = 'teal';
    //     }
    // })
}