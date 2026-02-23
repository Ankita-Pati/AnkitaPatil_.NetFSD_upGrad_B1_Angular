let number = 7;

let sign = (number >= 0) ? "Positive" : "Negative";

let parity;
if (number % 2 === 0) {
    parity = "Even";
} else {
    parity = "Odd";
}

console.log("Numbers from 1 to " + number + ":");

for (let i = 1; i <= number; i++) {
    console.log(i);
}

console.log("Number:", number);
console.log("Sign:", sign);
console.log("Parity:", parity);