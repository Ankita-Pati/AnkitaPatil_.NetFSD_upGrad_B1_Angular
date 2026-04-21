"use strict";
class Shapes {
    // Implementation
    area(a, b, c) {
        if (typeof b === "number" && c === undefined) {
            return a * b; // Rectangle
        }
        else if (typeof b === "number" && c === "triangle") {
            return 0.5 * a * b; // Triangle
        }
        else if (b === undefined) {
            return Math.PI * a * a; // Circle
        }
        else if (b === "square") {
            return a * a; // Square
        }
        throw new Error("Invalid parameters");
    }
}
// Usage
const shape = new Shapes();
console.log("Rectangle Area:", shape.area(10, 5));
console.log("Triangle Area:", shape.area(10, 5, "triangle"));
console.log("Circle Area:", shape.area(7));
console.log("Square Area:", shape.area(4, "square"));
