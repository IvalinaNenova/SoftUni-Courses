function solution() {
    let result = '';

    return {
        append(str) {
            result += str;
        },
        removeStart(num) {
            result = result.substring(num);
        },
        removeEnd(num) {
            result = result.substring(0, result.length - num);
        },
        print() {
            console.log(result);
        }
    };
}

let firstZeroTest = solution();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
