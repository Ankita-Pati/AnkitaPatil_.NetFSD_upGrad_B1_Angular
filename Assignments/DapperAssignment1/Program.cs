namespace DapperAssignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connString = "Data Source=LAPTOP-I4FPJV3B\\SQLEXPRESS;Initial Catalog=DapperAssignment1;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            BookRepository repo = new BookRepository(connString);

            while (true)
            {
                Console.WriteLine("\n1. Add Book");
                Console.WriteLine("2. Edit Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. Get Book by ID");
                Console.WriteLine("5. Get Book by Name");
                Console.WriteLine("6. List All Books");
                Console.WriteLine("7. List Books by Author");
                Console.WriteLine("8. List Books by Language");
                Console.WriteLine("9. List Books by Publisher");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var book = new Book();
                        Console.Write("Title: "); book.Title = Console.ReadLine();
                        Console.Write("Price: "); book.Price = decimal.Parse(Console.ReadLine());
                        Console.Write("Author: "); book.Author = Console.ReadLine();
                        Console.Write("Publisher: "); book.Publisher = Console.ReadLine();
                        Console.Write("Language: "); book.Language = Console.ReadLine();
                        Console.Write("Publish Date (yyyy-mm-dd): "); book.PublishDate = DateTime.Parse(Console.ReadLine());
                        repo.AddBook(book);
                        Console.WriteLine("Book added successfully!");
                        break;

                    case "2":
                        Console.Write("Enter Book ID to edit: ");
                        int editId = int.Parse(Console.ReadLine());
                        var editBook = repo.GetBook(editId);
                        if (editBook != null)
                        {
                            Console.Write("New Title: "); editBook.Title = Console.ReadLine();
                            Console.Write("New Price: "); editBook.Price = decimal.Parse(Console.ReadLine());
                            Console.Write("New Author: "); editBook.Author = Console.ReadLine();
                            Console.Write("New Publisher: "); editBook.Publisher = Console.ReadLine();
                            Console.Write("New Language: "); editBook.Language = Console.ReadLine();
                            Console.Write("New Publish Date (yyyy-mm-dd): "); editBook.PublishDate = DateTime.Parse(Console.ReadLine());
                            repo.EditBook(editBook);
                            Console.WriteLine("Book updated successfully!");
                        }
                        else Console.WriteLine("Book not found.");
                        break;

                    case "3":
                        Console.Write("Enter Book ID to delete: ");
                        int delId = int.Parse(Console.ReadLine());
                        repo.DeleteBook(delId);
                        Console.WriteLine("Book deleted successfully!");
                        break;

                    case "4":
                        Console.Write("Enter Book ID: ");
                        int getId = int.Parse(Console.ReadLine());
                        var bookById = repo.GetBook(getId);
                        if (bookById != null) Console.WriteLine($"{bookById.BookId} | {bookById.Title} | {bookById.Price} | {bookById.Author} | {bookById.Publisher} | {bookById.Language} | {bookById.PublishDate}");
                        else Console.WriteLine("Book not found.");
                        break;

                    case "5":
                        Console.Write("Enter Book Name: ");
                        string name = Console.ReadLine();
                        var bookByName = repo.GetBook(name);
                        if (bookByName != null) Console.WriteLine($"{bookByName.BookId} | {bookByName.Title} | {bookByName.Price} | {bookByName.Author} | {bookByName.Publisher} | {bookByName.Language} | {bookByName.PublishDate}");
                        else Console.WriteLine("Book not found.");
                        break;

                    case "6":
                        var allBooks = repo.GetAllBooks();
                        foreach (var b in allBooks)
                            Console.WriteLine($"{b.BookId} | {b.Title} | {b.Price} | {b.Author} | {b.Publisher} | {b.Language} | {b.PublishDate}");
                        break;

                    case "7":
                        Console.Write("Enter Author Name: ");
                        string author = Console.ReadLine();
                        var booksByAuthor = repo.GetAllBooksByAuthor(author);
                        booksByAuthor.ForEach(b => Console.WriteLine($"{b.BookId} | {b.Title} | {b.Price} | {b.Author} | {b.Publisher} | {b.Language} | {b.PublishDate}"));
                        break;

                    case "8":
                        Console.Write("Enter Language: ");
                        string lang = Console.ReadLine();
                        var booksByLang = repo.GetAllBooksByLanguage(lang);
                        booksByLang.ForEach(b => Console.WriteLine($"{b.BookId} | {b.Title} | {b.Price} | {b.Author} | {b.Publisher} | {b.Language} | {b.PublishDate}"));
                        break;

                    case "9":
                        Console.Write("Enter Publisher: ");
                        string pub = Console.ReadLine();
                        var booksByPub = repo.GetAllBooksByPublisher(pub);
                        booksByPub.ForEach(b => Console.WriteLine($"{b.BookId} | {b.Title} | {b.Price} | {b.Author} | {b.Publisher} | {b.Language} | {b.PublishDate}"));
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
