class Vehicle {
    brand: string;
    speed: number;

    constructor(brand: string, speed: number) {
        this.brand = brand;
        this.speed = speed;
    }

    move(): void {
        console.log("Vehicle is moving");
    }
}

// Car class
class Car extends Vehicle {
    fuelType: string;

    constructor(brand: string, speed: number, fuelType: string) {
        super(brand, speed);
        this.fuelType = fuelType;
    }

    // Method Overriding
    move(): void {
        console.log(`Car is moving at ${this.speed} km/h`);
    }
}

// Bike class
class Bike extends Vehicle {
    hasGear: boolean;

    constructor(brand: string, speed: number, hasGear: boolean) {
        super(brand, speed);
        this.hasGear = hasGear;
    }

    // Method Overriding
    move(): void {
        console.log(`Bike is moving at ${this.speed} km/h`);
    }
}

// Usage
const car1 = new Car("Toyota", 80, "Petrol");
const bike1 = new Bike("Yamaha", 60, true);

car1.move();   // Overridden method
bike1.move();

// Accessing parent properties
console.log("Car Brand:", car1.brand);
console.log("Bike Brand:", bike1.brand);