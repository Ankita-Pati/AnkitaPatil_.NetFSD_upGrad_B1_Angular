let numbers = [10, 20, 30, 10, 40, 20, 50, 60, 60];
console.log("\n1. Remove Duplicates:");
let uniqueNumbers = [...new Set(numbers)];
console.log(uniqueNumbers);

console.log("\n2. Second Largest Number:");
let sortedDesc = [...new Set(numbers)].sort((a, b) => b - a);
let secondLargest = sortedDesc[1];
console.log(secondLargest);

console.log("\n3. Frequency of Each Element:");
let frequency = numbers.reduce((freq, num) => {
  freq[num] = (freq[num] || 0) + 1;
  return freq;
}, {});
console.log(frequency);

console.log("\n4. First Non-Repeating Number:");
let firstNonRepeating = numbers.find(num => frequency[num] === 1);
console.log(firstNonRepeating);

console.log("\n5. Rotate Array by 2 Positions:");
let rotateBy2 = [...numbers.slice(2), ...numbers.slice(0, 2)];
console.log(rotateBy2);

console.log("\n6. Flatten Nested Array:");
let nestedArray = [1, 2, [3, 4, [5]]];
function flattenArray(arr) {
  return arr.reduce((flat, item) => {
    return flat.concat(Array.isArray(item) ? flattenArray(item) : item);
  }, []);
}
let flattened = flattenArray(nestedArray);
console.log(flattened);


console.log("\n7. Find Missing Number:");
let sequence = [1, 2, 3, 5, 6];
let missingNumber = (() => {
  let n = sequence.length + 1;
  let expectedSum = (n * (n + 1)) / 2;
  let actualSum = sequence.reduce((sum, num) => sum + num, 0);
  return expectedSum - actualSum;
})();
console.log(missingNumber);
