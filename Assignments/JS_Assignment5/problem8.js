class Payment {
    pay(amount) {
        console.log("Processing payment of " + amount);
    }
}

class CreditCardPayment extends Payment {
    constructor(cardNumber) {
        super();
        this.cardNumber = cardNumber;
    }

    pay(amount) {
        console.log("Paid ₹" + amount + " using Credit Card ending with " 
                    + this.cardNumber.slice(-4));
    }
}

class UPIPayment extends Payment {
    constructor(upiId) {
        super();
        this.upiId = upiId;
    }

    pay(amount) {
        console.log("Paid ₹" + amount + " using UPI ID: " + this.upiId);
    }
}

class CashPayment extends Payment {
    pay(amount) {
        console.log("Paid ₹" + amount + " in Cash.");
    }
}

let payments = [
    new CreditCardPayment("1234567812345678"),
    new UPIPayment("rahul@upi"),
    new CashPayment()
];

payments.forEach(p => p.pay(2000));