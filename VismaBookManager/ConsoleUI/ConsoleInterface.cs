using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaBookManager.Interfaces;
using VismaBookManager.Models;

namespace VismaBookManager.ConsoleUI
{
    class ConsoleInterface : UIInterface
    {
        public void PrintAllBooks(List<Book> books)
        {
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books[i].ToString());
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        public void PrintTakenBooks(List<BookLoaning> takenBooks)
        {
            for (int i = 0; i < takenBooks.Count; i++)
            {
                Console.WriteLine(takenBooks[i].ToString());
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
        public void Header()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,-15}|{1,-20}|{2,-15}|{3,-15}|{4,-20}|{5,-20}|", "Name","Author", "Category","Language","Publication Date","ISBN");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        }

        public void HeaderForLoanedBooks()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,-10}|{1,-20}|{2,-20}|{3,-15}|{4,-20}|", "Index", "Name","ISBN","Loaning Date","Expected Return");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }

        public void Choice()
        {
            Console.WriteLine("Welcome to the Visma library what would like to do, just type in the number");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Take a book");
            Console.WriteLine("3. Return a book");
            Console.WriteLine("4. Filter Books");
            Console.WriteLine("5. Delete a Book");
            Console.WriteLine("6. Exit");
        }

        public void FilterChoice()
        {
            Console.WriteLine("Just type in the number how you want to filter books");
            Console.WriteLine("1. Filter by author");
            Console.WriteLine("2. Filter by category");
            Console.WriteLine("3. Filter by language");
            Console.WriteLine("4. Filter by ISBN");
            Console.WriteLine("5. Filter by name");
            Console.WriteLine("6. Filter taken or available books");
            Console.WriteLine("7. Return to menu");
        }

        
    }
}
