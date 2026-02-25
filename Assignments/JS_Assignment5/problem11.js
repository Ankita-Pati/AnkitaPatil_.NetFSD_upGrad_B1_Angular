class User {

    constructor(username, password) {
        this.username = username;
        this._password = "";   
        this.password = password; 
    }

    set password(newPassword) {
        if (newPassword.length >= 6) {
            this._password = newPassword;
            console.log("Password set successfully.");
        } else {
            console.log("Password must be at least 6 characters long.");
        }
    }

    get password() {
        return this._password;
    }
}

let u1 = new User("Rahul", "12345");   
u1.password = "secure123";            
console.log("Stored Password:", u1.password);