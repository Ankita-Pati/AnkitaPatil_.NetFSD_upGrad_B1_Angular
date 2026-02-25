class Student {

    constructor(name) {
        this.name = name;
        this.marks = [];  
    }

    addMark(mark) {
        if (mark >= 0 && mark <= 100) {
            this.marks.push(mark);
            console.log("Mark added:", mark);
        } else {
            console.log("Invalid mark! Enter between 0 and 100.");
        }
    }

    getAverage() {
        if (this.marks.length === 0) {
            return 0;
        }

        let sum = 0;
        for (let m of this.marks) {
            sum += m;
        }

        return sum / this.marks.length;
    }

    getGrade() {
        let avg = this.getAverage();

        if (avg >= 90) return "A";
        else if (avg >= 75) return "B";
        else if (avg >= 50) return "C";
        else return "Fail";
    }
}

let s1 = new Student("Rahul");

s1.addMark(95);
s1.addMark(85);
s1.addMark(90);

console.log("Average:", s1.getAverage());
console.log("Grade:", s1.getGrade());