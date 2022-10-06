class List {
    #innerCollection = [];
    constructor() {
        this.size = this.#innerCollection.length;
    }
    add(value) {
        this.#innerCollection.push(value);
        this.#innerCollection.sort((a, b) => a - b);
        this.size++;
    }
    remove(value) {
        if (value < 0 || value >= this.size) {
            throw new Error;
        }
        this.size--;
        return this.#innerCollection.splice(value, 1);
    }
    get(value) {
        if (value < 0 || value >= this.size) {
            throw new Error;
        }
        return this.#innerCollection[value];
    }
}

let list = new List();
list.add(50);
console.log(list.size);
list.add(16);
console.log(list.size);
list.add(78);
list.add(105);
console.log(list.size);
list.add(5);
list.add(10);
console.log(list.size);
console.log(list.get(1));
list.remove(1);
console.log(list.size);
list.remove(3);
console.log(list.size);
console.log(list.get(1));
