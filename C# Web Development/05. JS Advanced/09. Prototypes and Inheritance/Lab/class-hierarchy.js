function solve() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        get area() {
            return this.area;
        }

        changeUnits(unitsValue) {
            this.units = unitsValue;
        }

        convertUnits(value) {
            switch (this.units) {
                case 'm':
                    return value /= 100;

                case 'mm':
                    return value *= 10;
            }

            return value;
        }

        toString() {
            return `Figures units: ${this.units}`
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();

            this.radius = radius;
        }

        get area() {
            this.convertedRadius = this.convertUnits(this.radius);

            return Math.PI * (this.convertedRadius ** 2);
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - radius: ${this.convertedRadius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);

            this.width = width;
            this.height = height;
        }

        get area() {
            this.convertedWidth = this.convertUnits(this.width);
            this.convertedHeight = this.convertUnits(this.height);

            return this.convertedWidth * this.convertedHeight;
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - width: ${this.convertedWidth}, height: ${this.convertedHeight}`;
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