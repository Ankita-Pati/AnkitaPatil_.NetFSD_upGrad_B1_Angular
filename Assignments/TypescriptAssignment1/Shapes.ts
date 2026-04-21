class Shapes {

    // Overload signatures
    area(length: number, breadth: number): number; // Rectangle
    area(base: number, height: number, type: "triangle"): number; // Triangle
    area(radius: number): number; // Circle
    area(side: number, type: "square"): number; // Square

    // Implementation
    area(a: number, b?: number | string, c?: string): number {

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