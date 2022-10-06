class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(point1, point2) {
        let side1 = point1.x - point2.x;
        let side2 = point2.y - point1.y;
        return Math.sqrt(side1 ** 2 + side2 ** 2);
    }
}
let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
