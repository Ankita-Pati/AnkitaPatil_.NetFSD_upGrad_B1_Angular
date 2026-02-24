let students = [
  { name: "Akhil", marks: 85 },
  { name: "Priya", marks: 72 },
  { name: "Ravi", marks: 90 },
  { name: "Meena", marks: 45 },
  { name: "Karan", marks: 30 }
];

console.log("\n1. Passed Students:");
let passedStudents = students.filter(student => student.marks >= 40);
console.log(passedStudents);

console.log("\n2. Distinction Students:");
let distinctionStudents = students.filter(student => student.marks >= 85);
console.log(distinctionStudents);

console.log("\n3. Class Average:");
let average = students.reduce((total, student) => {
  return total + student.marks;
}, 0) / students.length;

console.log("Average Marks:", average.toFixed(2));

console.log("\n4. Topper:");
let topper = students.reduce((top, student) => {
  return student.marks > top.marks ? student : top;
});
console.log(topper);

console.log("\n5. Failed Students Count:");
let failedCount = students.filter(student => student.marks < 40).length;
console.log(failedCount);

console.log("\n6. Students with Grades:");
let gradedStudents = students.map(student => {
  let grade;
  if (student.marks >= 85) grade = "A";
  else if (student.marks >= 60) grade = "B";
  else if (student.marks >= 40) grade = "C";
  else grade = "Fail";
  return { ...student, grade };
});

console.log(gradedStudents);

console.log("\nBONUS 1: Add Rank");
let rankedStudents = [...students]
  .sort((a, b) => b.marks - a.marks)
  .map((student, index) => ({
    ...student,
    rank: index + 1
  }));
console.log(rankedStudents);

console.log("\nBONUS 2: Remove Lowest Scorer");
let lowestMarks = Math.min(...students.map(s => s.marks));
let removedLowest = students.filter(s => s.marks !== lowestMarks);
console.log(removedLowest);

console.log("\nBONUS 3: Leaderboard");
let leaderboard = [...students].sort((a, b) => b.marks - a.marks);
console.log(leaderboard);
