using System;
using System.Collections.Generic;
using System.Data.SQLite;
using BookStoreApp.Models;

namespace BookStoreApp.Data
{
    public class BookRepository
    {
        private readonly string _connectionString = "Data Source=books.db;Version=3;";

        public BookRepository()
        {
            CreateTableIfNotExists();
        }

        private void CreateTableIfNotExists()
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Books (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Author TEXT NOT NULL,
                    Title TEXT NOT NULL,
                    Publisher TEXT NOT NULL,
                    PageCount INTEGER NOT NULL,
                    Genre TEXT NOT NULL,
                    Price REAL NOT NULL
                );";
            cmd.ExecuteNonQuery();
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            using var con = new SQLiteConnection(_connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Books;";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(new Book
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Author = reader["Author"].ToString()!,
                    Title = reader["Title"].ToString()!,
                    Publisher = reader["Publisher"].ToString()!,
                    PageCount = Convert.ToInt32(reader["PageCount"]),
                    Genre = reader["Genre"].ToString()!,
                    Price = Convert.ToDecimal(reader["Price"])
                });
            }
            return books;
        }

        public void AddBook(Book book)
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Books (Author, Title, Publisher, PageCount, Genre, Price)
                VALUES (@Author, @Title, @Publisher, @PageCount, @Genre, @Price);";
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
            cmd.Parameters.AddWithValue("@PageCount", book.PageCount);
            cmd.Parameters.AddWithValue("@Genre", book.Genre);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.ExecuteNonQuery();
        }

        public void UpdateBook(Book book)
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = @"
                UPDATE Books SET
                    Author = @Author,
                    Title = @Title,
                    Publisher = @Publisher,
                    PageCount = @PageCount,
                    Genre = @Genre,
                    Price = @Price
                WHERE Id = @Id;";
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
            cmd.Parameters.AddWithValue("@PageCount", book.PageCount);
            cmd.Parameters.AddWithValue("@Genre", book.Genre);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Id", book.Id);
            cmd.ExecuteNonQuery();
        }

        public void DeleteBook(int id)
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Books WHERE Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
