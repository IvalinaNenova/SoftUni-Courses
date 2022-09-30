function sum3(a) {
    return (b) => {
        return (c) => {
            return a + b + c;
        }
    }
}

const arrowSum = a => b => c => a + b + c;

console.log(sum3(5)(6)(8)); 
console.log(arrowSum(5)(6)(8)); 

let sum5 = sum3(5);
let sum5and6 = sum5(6);
let totalSum = sum5and6(8);
console.log(totalSum);