class Product {
    constructor({ name, price, category = "General" }) {
        this.name = name;
        this.price = price;
        this.category = category;
    }

    getDetails = () => {
        console.log(`Product: ${this.name}
Price: ₹${this.price}
Category: ${this.category}`);
    }

    applyDiscount(discount = 10) {
        this.price -= this.price * (discount / 100);
        console.log(`Discount applied: ${discount}%`);
    }
}

let productData = {
    name: "Laptop",
    price: 50000
};

let newProductData = { ...productData, category: "Electronics" };
let p1 = new Product(newProductData);

p1.getDetails();
p1.applyDiscount();  
p1.getDetails();