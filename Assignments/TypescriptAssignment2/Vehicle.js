"use strict";
class Vehicle {
    brand;
    speed;
    constructor(brand, speed) {
        this.brand = brand;
        this.speed = speed;
    }
    move() {
        console.log("Vehicle is moving");
    }
}
// Car class
class Car extends Vehicle {
    fuelType;
    constructor(brand, speed, fuelType) {
        super(brand, speed);
        this.fuelType = fuelType;
    }
    // Method Overriding
    move() {
        console.log(`Car is moving at ${this.speed} km/h`);
    }
}
// Bike class
class Bike extends Vehicle {
    hasGear;
    constructor(brand, speed, hasGear) {
        super(brand, speed);
        this.hasGear = hasGear;
    }
    // Method Overriding
    move() {
        console.log(`Bike is moving at ${this.speed} km/h`);
    }
}
// Usage
const car1 = new Car("Toyota", 80, "Petrol");
const bike1 = new Bike("Yamaha", 60, true);
car1.move(); // Overridden method
bike1.move();
// Accessing parent properties
console.log("Car Brand:", car1.brand);
console.log("Bike Brand:", bike1.brand);
