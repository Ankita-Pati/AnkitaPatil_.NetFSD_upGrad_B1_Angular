"use strict";
class BankAccount {
    depositorName;
    accountNumber;
    accountType;
    balance;
    constructor(name, accNo, type, initialBalance) {
        this.depositorName = name;
        this.accountNumber = accNo;
        this.accountType = type;
        this.balance = initialBalance;
    }
    deposit(amount) {
        this.balance += amount;
        console.log(`Deposited: ${amount}`);
    }
    withdraw(amount) {
        if (amount > this.balance) {
            console.log("Insufficient Balance!");
        }
        else {
            this.balance -= amount;
            console.log(`Withdrawn: ${amount}`);
        }
    }
    display() {
        console.log("Depositor Name:", this.depositorName);
        console.log("Balance:", this.balance);
    }
}
// Usage
const account = new BankAccount("Ankita", 123456, "Savings", 5000);
account.deposit(2000);
account.withdraw(3000);
account.display();
