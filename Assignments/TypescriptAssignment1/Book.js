"use strict";
class Book {
    isbn;
    bookName;
    bookTitle;
    bookAuthor;
    quantityOfBooks;
    bookPrice;
    constructor(isbn, bookName, bookTitle, bookAuthor, quantity, price) {
        this.isbn = isbn;
        this.bookName = bookName;
        this.bookTitle = bookTitle;
        this.bookAuthor = bookAuthor;
        this.quantityOfBooks = quantity;
        this.bookPrice = price;
    }
    calculateBill() {
        return this.quantityOfBooks * this.bookPrice;
    }
    displayDetails() {
        console.log("ISBN:", this.isbn);
        console.log("Book Name:", this.bookName);
        console.log("Title:", this.bookTitle);
        console.log("Author:", this.bookAuthor);
        console.log("Quantity:", this.quantityOfBooks);
        console.log("Price per Book:", this.bookPrice);
        console.log("Total Bill Amount:", this.calculateBill());
    }
}
// Usage
const book1 = new Book("12345", "TS Basics", "Learn TypeScript", "John Doe", 3, 500);
book1.displayDetails();
