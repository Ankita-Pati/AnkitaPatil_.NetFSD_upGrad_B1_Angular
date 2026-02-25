class Wallet {

    #balance = 0;

    constructor(initialAmount = 0) {
        if (initialAmount >= 0) {
            this.#balance = initialAmount;
        }
    }

    addMoney(amount) {
        if (amount > 0) {
            this.#balance += amount;
            console.log(`₹${amount} added successfully.`);
        } else {
            console.log("Invalid amount.");
        }
    }

    spendMoney(amount) {
        if (amount <= 0) {
            console.log("Invalid amount.");
        } 
        else if (amount > this.#balance) {
            console.log("Insufficient balance.");
        } 
        else {
            this.#balance -= amount;
            console.log(`₹${amount} spent successfully.`);
        }
    }

    getBalance() {
        return this.#balance;
    }
}

let myWallet = new Wallet(1000);

myWallet.addMoney(500);
myWallet.spendMoney(300);

console.log("Current Balance:", myWallet.getBalance());
