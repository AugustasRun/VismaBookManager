using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaBookManager.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using VismaBookManager.Models;

namespace VismaBookManager.PublicationRepository
{
    public class BookRepository
    {
        public string AddBook(Book book)
        {
            List<Book> books = new List<Book>();

            string jsonString;
           
           
            jsonString = File.ReadAllText("Books.json");
           
            if (jsonString != "")
            {
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            if (books.Contains(book))
            {
                return "The book currently exists";
            }
            else
            {
                books.Add(book);
                jsonString = JsonSerializer.Serialize(books);
                File.WriteAllText("Books.json", jsonString);
                return "The book added succesfully";
            }

        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            string jsonString;
            jsonString = File.ReadAllText("Books.json");
            if (jsonString != "")
            {
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            return books;

        }
        public string RemoveBook(string ISBN)
        {
            List<Book> books = new List<Book>();
           
            string jsonString = File.ReadAllText("Books.json");
            if (jsonString != "")
            {
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
                List<Book> removedBookList = books.FindAll(b => b.ISBN != ISBN);
                jsonString = JsonSerializer.Serialize(removedBookList);
                File.WriteAllText("Books.json", jsonString);
                return "The book removed Succefully";
            }
            else
            {
                return "Book list is empty there is nothin to remove";
            }
        }

        public void FileValidation()
        {
            if (!File.Exists("Books.json"))
            {
                File.Create("Books.json").Close();
            }
        }

    }

}



