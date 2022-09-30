function counterBuilder() {
    let counter = 0;

    return function c() {
        counter++;
        console.log(counter);
    }
}

let counter = counterBuilder();
let counter2 = counterBuilder();
counter();
counter();
counter();
counter();

counter2();