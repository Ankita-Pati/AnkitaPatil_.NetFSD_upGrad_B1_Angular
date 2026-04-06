using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperAssignment1
{
    public class BookRepository
    {
        private readonly string connectionString;

        public BookRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(connectionString);

        public void AddBook(Book book)
        {
            using (var db = Connection)
            {
                string sql = @"INSERT INTO Book (Title, Price, Author, Publisher, Language, PublishDate)
                           VALUES (@Title, @Price, @Author, @Publisher, @Language, @PublishDate)";
                db.Execute(sql, book);
            }
        }

        public void EditBook(Book book)
        {
            using (var db = Connection)
            {
                string sql = @"UPDATE Book 
                           SET Title=@Title, Price=@Price, Author=@Author, Publisher=@Publisher, 
                               Language=@Language, PublishDate=@PublishDate
                           WHERE BookId=@BookId";
                db.Execute(sql, book);
            }
        }

        public void DeleteBook(int id)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM Book WHERE BookId=@Id";
                db.Execute(sql, new { Id = id });
            }
        }

        public Book GetBook(int id)
        {
            using (var db = Connection)
            {
                return db.QuerySingleOrDefault<Book>("SELECT * FROM Book WHERE BookId=@Id", new { Id = id });
            }
        }

        public Book GetBook(string name)
        {
            using (var db = Connection)
            {
                return db.QuerySingleOrDefault<Book>("SELECT * FROM Book WHERE Title=@Title", new { Title = name });
            }
        }

        public List<Book> GetAllBooks()
        {
            using (var db = Connection)
            {
                return db.Query<Book>("SELECT * FROM Book").ToList();
            }
        }

        public List<Book> GetAllBooksByAuthor(string author)
        {
            using (var db = Connection)
            {
                return db.Query<Book>("SELECT * FROM Book WHERE Author=@Author", new { Author = author }).ToList();
            }
        }

        public List<Book> GetAllBooksByLanguage(string lang)
        {
            using (var db = Connection)
            {
                return db.Query<Book>("SELECT * FROM Book WHERE Language=@Language", new { Language = lang }).ToList();
            }
        }

        public List<Book> GetAllBooksByPublisher(string publisher)
        {
            using (var db = Connection)
            {
                return db.Query<Book>("SELECT * FROM Book WHERE Publisher=@Publisher", new { Publisher = publisher }).ToList();
            }
        }
    }
}
