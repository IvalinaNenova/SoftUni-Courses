class Figure {
    constructor() {
        this.units = 'cm';
    }

    get area() { return this._area }

    changeUnits(value) {
        if (value == 'cm' || value == 'mm' || value == 'm') {
            this.units = value
        }
    }

    toString() { return `Figures units: ${this.units}` }
}
class Circle extends Figure {
    constructor(radius) {
        super();
        this._radius = radius;
    }
    get radius() {
        switch (this.units) {
            case 'cm': return this._radius;
            case 'mm': return this._radius * 10;
            case 'm': return this._radius / 100;
        }
    };
    
    set radius(value) { this._radius = value };

    get area() { return Math.PI * this._radius ** 2 };

    toString() { return super.toString() + ` Area: ${this.area} - radius: ${this._radius}` }
}

class Rectangle extends Figure {
    constructor(width, height, units){
        super();
        this._width = width;
        this._height = height;
        this.units = units;
    }
    get width() { 
        switch (this.units) {
            case 'cm': return this._width;
            case 'mm': return this._width * 10;
            case 'm': return this._width / 100;
        }
    }
    get height() {
        switch (this.units) {
            case 'cm': return this._height;
            case 'mm': return this._height * 10;
            case 'm': return this._height / 100;
        }
    }
    get area() { return this.width * this.height; }
    toString() { return super.toString() + ` Area: ${this.area} - width: ${this.width}, height: ${this.height}`};
}

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
