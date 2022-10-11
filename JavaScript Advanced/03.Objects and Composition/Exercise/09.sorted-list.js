function solve() {
    return output = {
        numbers: [],
        size: 0,
        add(n) {
            this.numbers.push(Number(n));
            this.setSize();
        },
        remove(i) {
            if (i >= 0 && i < this.numbers.length) {
                this.numbers.splice(i, 1);
                this.setSize();
            }
        },
        get(i) {
            if (i >= 0 && i < this.numbers.length) {
                return this.numbers[i];
            }
        },
        setSize() {
            this.numbers.sort((a, b) => a - b);
            this.size = this.numbers.length;
        }
    };
}