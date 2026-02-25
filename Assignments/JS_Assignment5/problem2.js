class BankAccount {

    constructor(accountHolder, balance) {
        this.accountHolder = accountHolder;
        this.balance = balance;
    }

    deposit(amount) {
        if (amount > 0) {
            this.balance += amount;
            console.log(amount + " deposited successfully.");
        } else {
            console.log("Invalid deposit amount.");
        }
    }

    withdraw(amount) {
        if (amount <= 0) {
            console.log("Invalid withdrawal amount.");
        } 
        else if (amount > this.balance) {
            console.log("Insufficient balance! Cannot withdraw.");
        } 
        else {
            this.balance -= amount;
            console.log(amount + " withdrawn successfully.");
        }
    }

    checkBalance() {
        console.log("Current balance: " + this.balance);
    }
}

let acc1 = new BankAccount("Rahul", 5000);

acc1.deposit(1000);
acc1.withdraw(2000);
acc1.withdraw(10000); 
acc1.checkBalance();