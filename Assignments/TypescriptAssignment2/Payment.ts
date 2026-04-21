// Payment Interface
interface Payment {
    amount: number;
    pay(): void;
}

// Refundable Interface
interface Refundable {
    refund(): void;
}

// Credit Card Payment Class
class CreditCardPayment implements Payment, Refundable {
    amount: number;

    constructor(amount: number) {
        this.amount = amount;
    }

    pay(): void {
        console.log(`Paid ${this.amount} using Credit Card`);
    }

    refund(): void {
        console.log("Refund initiated to Credit Card");
    }
}

// UPI Payment Class
class UPIPayment implements Payment {
    amount: number;

    constructor(amount: number) {
        this.amount = amount;
    }

    pay(): void {
        console.log(`Paid ${this.amount} using UPI`);
    }
}

// Usage
const credit = new CreditCardPayment(1000);
credit.pay();
credit.refund();

const upi = new UPIPayment(500);
upi.pay();