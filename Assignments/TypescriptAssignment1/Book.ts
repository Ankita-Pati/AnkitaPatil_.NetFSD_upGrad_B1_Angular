class Book {
    isbn: string;
    bookName: string;
    bookTitle: string;
    bookAuthor: string;
    quantityOfBooks: number;
    bookPrice: number;

    constructor(isbn: string, bookName: string, bookTitle: string, bookAuthor: string, quantity: number, price: number) {
        this.isbn = isbn;
        this.bookName = bookName;
        this.bookTitle = bookTitle;
        this.bookAuthor = bookAuthor;
        this.quantityOfBooks = quantity;
        this.bookPrice = price;
    }

    calculateBill(): number {
        return this.quantityOfBooks * this.bookPrice;
    }

    displayDetails(): void {
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