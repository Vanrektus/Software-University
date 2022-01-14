function solve(width, height, color) {
    const rectangle = {
        width: Number(width),
        height: Number(height),
        color: color.charAt(0).toUpperCase() + color.slice(1),
        calcArea() {
            return this.width * this.height;
        },
    };

    return rectangle;
}

let rectangle = solve(4, 5, "red");
console.log(rectangle.width);
console.log(rectangle.height);
console.log(rectangle.color);
console.log(rectangle.calcArea());
