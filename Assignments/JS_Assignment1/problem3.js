let purchaseAmount = 4500;

let discount = 0;
let finalAmount = 0;

if (purchaseAmount >= 5000) {
    discount = purchaseAmount * 0.20;  
} else if (purchaseAmount >= 3000) {
    discount = purchaseAmount * 0.10;   
} else {
    discount = 0;  
}

finalAmount = purchaseAmount - discount;

console.log("Purchase Amount: Rs " + purchaseAmount);
console.log("Discount Amount: Rs " + discount);
console.log("Final Payable Amount: Rs " + finalAmount);