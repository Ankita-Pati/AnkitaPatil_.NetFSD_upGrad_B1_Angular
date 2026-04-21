"use strict";
class Student {
    rollNo;
    studName;
    marksInEng;
    marksInMaths;
    marksInScience;
    constructor(rollNo, name, eng, maths, science) {
        this.rollNo = rollNo;
        this.studName = name;
        this.marksInEng = eng;
        this.marksInMaths = maths;
        this.marksInScience = science;
    }
    calculateTotal() {
        return this.marksInEng + this.marksInMaths + this.marksInScience;
    }
    calculatePercentage() {
        return this.calculateTotal() / 3;
    }
    display() {
        console.log("Roll No:", this.rollNo);
        console.log("Name:", this.studName);
        console.log("Total Marks:", this.calculateTotal());
        console.log("Percentage:", this.calculatePercentage() + "%");
    }
}
// Usage
const student1 = new Student(1, "Ankita", 85, 90, 88);
student1.display();
