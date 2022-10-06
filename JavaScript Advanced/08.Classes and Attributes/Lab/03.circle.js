class Circle{
    constructor(radius){
        this.radius = radius;
    }

    set diameter(value){this.radius = value / 2};
    get diameter(){return this.radius * 2}

    get area(){return Math.PI * this.radius ** 2};
};

let c = new Circle(2);
console.log(`Radius: ${c.radius}`); // 2      Radius: 2
console.log(`Diameter: ${c.diameter}`);// Diameter: 4
console.log(`Area: ${c.area}`); //Area: 12.566370614359172
c.diameter = 1.6;
console.log(`Radius: ${c.radius}`); //Radius: 0.8
console.log(`Diameter: ${c.diameter}`); // Diameter: 1.6
console.log(`Area: ${c.area}`); //Area: 2.0106192982974678
