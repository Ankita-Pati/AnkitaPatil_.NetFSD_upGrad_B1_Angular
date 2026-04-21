"use strict";
// Credit Card Payment Class
class CreditCardPayment {
    amount;
    constructor(amount) {
        this.amount = amount;
    }
    pay() {
        console.log(`Paid ${this.amount} using Credit Card`);
    }
    refund() {
        console.log("Refund initiated to Credit Card");
    }
}
// UPI Payment Class
class UPIPayment {
    amount;
    constructor(amount) {
        this.amount = amount;
    }
    pay() {
        console.log(`Paid ${this.amount} using UPI`);
    }
}
// Usage
const credit = new CreditCardPayment(1000);
credit.pay();
credit.refund();
const upi = new UPIPayment(500);
upi.pay();
