class Student {
    rollNo: number;
    studName: string;
    marksInEng: number;
    marksInMaths: number;
    marksInScience: number;

    constructor(rollNo: number, name: string, eng: number, maths: number, science: number) {
        this.rollNo = rollNo;
        this.studName = name;
        this.marksInEng = eng;
        this.marksInMaths = maths;
        this.marksInScience = science;
    }

    calculateTotal(): number {
        return this.marksInEng + this.marksInMaths + this.marksInScience;
    }

    calculatePercentage(): number {
        return this.calculateTotal() / 3;
    }

    display(): void {
        console.log("Roll No:", this.rollNo);
        console.log("Name:", this.studName);
        console.log("Total Marks:", this.calculateTotal());
        console.log("Percentage:", this.calculatePercentage() + "%");
    }
}

// Usage
const student1 = new Student(1, "Ankita", 85, 90, 88);
student1.display();