function solve(input) {
    let data = JSON.parse(input);
    let htmlText = ['<table>'];
    let singleObject = data[0];


    htmlText.push(makeHeaderRowFromKeys(singleObject));
    data.forEach(obj => htmlText.push(makeRowsFromValues(obj)));
    htmlText.push('</table>')

    function makeHeaderRowFromKeys(array) {
        let keys = [];
        Object.keys(array).forEach(key => {
            keys.push(`<th>${escapeHTML(key)}</th>`);
        })

        return '<tr>' + keys.join('') + '</tr>';
    }
    function makeRowsFromValues(obj) {
        let rows = [];
        Object.values(obj).forEach(value => {
            rows.push(`<td>${escapeHTML(value)}</td>`);
        })

        return '<tr>' + rows.join('') + '</tr>';
    }
    function escapeHTML(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

    return htmlText.join('\r\n')
}

console.log(solve(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]`
));