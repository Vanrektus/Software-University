function solve() {
    class Figure {
        constructor() {
            this.units = 'cm';
        }

        get area() {

        }

        changeUnits(units) {
            this.units = units;
        }

        toString() {
            return `Figures units: ${this.unit}`
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();

            this.radius = radius;
        }

        get area() {
            return Math.PI * (this.radius ** 2);
        }

        toString() {
            return super.toString() + ` Area: ${this.area} - radius: ${this.radius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            this.width = width;
            this.height = height;
            this.units = units;
        }

        get area() {
            return this.width * this.height;
        }

        toString() {
            return super.toString() + ` Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle,
    };
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