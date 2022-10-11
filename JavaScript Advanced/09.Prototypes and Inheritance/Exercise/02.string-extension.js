(function solve() {
    String.prototype.ensureStart = function (str) {
        return this.startsWith(str) ? `${this}` : str + this;
    };
    String.prototype.ensureEnd = function (str) {
        return this.endsWith(str) ? `${this}` : this + str;
    };
    String.prototype.isEmpty = function () {
        return this.length == 0 ? true : false;
    };
    String.prototype.truncate = function(n) {
        if (this.length <= n) {
            return this.toString();
        }
        if (n < 4) {
            return '.'.repeat(n);
        }
        let words = this.split(' ');
        while ((words.join(' ') + '...').length > n) {
            if (words.length > 1) {
                words.pop();
            } else {
                words[0] = words[0].slice(0, n - 3)
            }
        }
        return words.join(' ').trim() + '...';
    };
    String.format = function (str, ...params) {
        params.forEach((w, i) => str = str.replace(`{${i}}`.toString(), w));
        return str;
    };
})()
let str = 'my    string   my       string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('');
console.log(str);

str = str.ensureStart('hello    ');
console.log(str);

str = str.ensureEnd('ing');
console.log(str);

str = str.ensureEnd('in');
console.log(str);

str = str.ensureEnd('');
console.log(str);

str = '        ';
console.log(str);

str = str.truncate(16);
console.log(str);

str = str.truncate(14);
console.log(str);

str = str.truncate(8);
console.log(str);

str = str.truncate(4);
console.log(str);

str = str.truncate(2);
console.log(str);

str = str.truncate(1);
console.log(str);

str = String.format('The {0} {1} fox',
  'quick', 'brown');
console.log(str);

str = String.format('jumps {0} {1}',
  'dog');
console.log(str);

