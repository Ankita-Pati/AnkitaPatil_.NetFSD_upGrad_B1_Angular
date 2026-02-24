let employees = [
 { id:1, name:"Ravi", dept:"IT", salary:70000 },
 { id:2, name:"Anita", dept:"HR", salary:50000 },
 { id:3, name:"Karan", dept:"IT", salary:80000 },
 { id:4, name:"Meena", dept:"Finance", salary:60000 }
];

console.log("\n1. Total Salary Expense:");
let totalSalary = employees.reduce((total, emp) => {
  return total + emp.salary;
}, 0);
console.log("₹" + totalSalary);

console.log("\n2. Highest & Lowest Paid Employee:");
let highestPaid = employees.reduce((max, emp) => 
  emp.salary > max.salary ? emp : max
);
let lowestPaid = employees.reduce((min, emp) => 
  emp.salary < min.salary ? emp : min
);
console.log("Highest Paid:", highestPaid);
console.log("Lowest Paid:", lowestPaid);

console.log("\n3. IT Department Salary Increased by 15%:");
let updatedEmployees = employees.map(emp => {
  if (emp.dept === "IT") {
    return {
      ...emp,
      salary: +(emp.salary * 1.15).toFixed(2)
    };
  }
  return emp;
});
console.log(updatedEmployees);

console.log("\n4. Grouped by Department:");
let groupedByDept = employees.reduce((groups, emp) => {
  groups[emp.dept] = groups[emp.dept] || [];
  groups[emp.dept].push(emp);
  return groups;
}, {});
console.log(groupedByDept);

console.log("\n5. Department-wise Average Salary:");
let deptAverage = Object.keys(groupedByDept).reduce((result, dept) => {
  let total = groupedByDept[dept].reduce((sum, emp) => sum + emp.salary, 0);
  result[dept] = (total / groupedByDept[dept].length).toFixed(2);
  return result;
}, {});
console.log(deptAverage);

console.log("\n6. Sorted by Salary (High → Low):");
let sortedEmployees = [...employees].sort((a, b) => b.salary - a.salary);
console.log(sortedEmployees);

console.log("\nBONUS 1: After 10% Tax Deduction");
let afterTax = employees.map(emp => ({
  ...emp,
  salaryAfterTax: +(emp.salary * 0.9).toFixed(2)
}));
console.log(afterTax);

console.log("\nBONUS 2: Above Average Salary");
let averageSalary = totalSalary / employees.length;
let aboveAverage = employees.filter(emp => emp.salary > averageSalary);
console.log("Average Salary:", averageSalary);
console.log(aboveAverage);

console.log("\nBONUS 3: HTML Table Format");
let htmlTable = `
<table border="1">
<tr>
<th>ID</th>
<th>Name</th>
<th>Department</th>
<th>Salary</th>
</tr>
${employees.map(emp => `
<tr>
<td>${emp.id}</td>
<td>${emp.name}</td>
<td>${emp.dept}</td>
<td>${emp.salary}</td>
</tr>
`).join("")}
</table>
`;
console.log(htmlTable);
