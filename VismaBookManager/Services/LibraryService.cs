using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VismaBookManager.Models;
using VismaBookManager.PublicationRepository;

namespace VismaBookManager.Services
{
    public class LibraryService
    {
        private BookRepository bookRepository;
        private BookLoaningRepository bookLoaningRepository;

        public LibraryService(BookRepository bookRepository, BookLoaningRepository bookLoaningRepository)
        {
            this.bookRepository = bookRepository;
            this.bookLoaningRepository = bookLoaningRepository;
            bookRepository.FileValidation();
            bookLoaningRepository.FileValidation();
        }

        public List<Book> FilterBooks(Predicate<Book> lambda)
        {
            return bookRepository.GetAllBooks().FindAll(lambda).ToList<Book>();
        }

        public List<Book> FilterBooks(bool criteria)
        {
            List<Book> books = bookRepository.GetAllBooks();
            List<BookLoaning> takenBooks = bookLoaningRepository.GetTakenBooks();
            List<Book> filteredBooks = new List<Book>();
        

            foreach(var book in books)
            {
                int appearance = 0;
                for (int i = takenBooks.Count-1; i >= 0; i--)
                {
                    if (book.ISBN == takenBooks[i].ISBN && !takenBooks[i].ActualReturn.HasValue)
                    {
                        appearance++;
                        break;
                    }
                }
                if (appearance==0 != criteria)
                {
                    filteredBooks.Add(book);
                }
            }
        
            return filteredBooks;
        }

        public List<BookLoaning> GetTakenBooksByName(string name)
        {
            List<BookLoaning> loanedBooks = bookLoaningRepository.GetTakenBooks();
            List<BookLoaning> loanedBooksByName = new List<BookLoaning>();

            for (int i = loanedBooks.Count - 1; i >= 0; i--)
            {
                if (loanedBooks[i].Name == name && loanedBooks[i].ActualReturn == null)
                {
                    loanedBooksByName.Add(loanedBooks[i]);
                }
            }
            return loanedBooksByName;
        }

        public string ReturnBook(int index)
        {
            string message = string.Empty;
            List<BookLoaning> loanedBooks = bookLoaningRepository.GetTakenBooks();
            if (loanedBooks[index].ExpectedReturn < DateTime.Now)
            {  
                message = "You are late but I will let it slide this time";
            }
            else
            {
                message = "Thank you for returning the book";
            }
            loanedBooks[index].ActualReturn = DateTime.Now;
            string jsonString = JsonSerializer.Serialize(loanedBooks);
            bookLoaningRepository.UpdateTakenBooks(jsonString);
            return message;
        }


        public int TakenBookCount (string name)
        {
            List<BookLoaning> loanedBooks = bookLoaningRepository.GetTakenBooks();
            int count = 0;
            for (int i = loanedBooks.Count - 1; i >= 0; i--)
            {
                if (loanedBooks[i].Name == name && loanedBooks[i].ActualReturn == null)
                {
                    count++;
                }
                if (count >= 3)
                {
                    break;
                }
            }
            return count;
        }

        public bool IsBookTaken(string ISBN)
        {
            List<BookLoaning> loanedBooks = bookLoaningRepository.GetTakenBooks();
            for (int i = loanedBooks.Count - 1; i >= 0; i--)
            {
                if (loanedBooks[i].ISBN == ISBN && loanedBooks[i].ActualReturn == null)
                {
                    return true;
                }
                
            }
            return false;
        }


        public string TakeBook(string ISBN, string name, int returnDay)
        {
            List<Book> books = bookRepository.GetAllBooks();
            List<BookLoaning> loanedBooks = bookLoaningRepository.GetTakenBooks();
            string borrowedBooks = string.Empty;
            string message = string.Empty;
            int count = TakenBookCount(name);
            int index = findBookIndex(ISBN);
            bool isBookTaken = IsBookTaken(ISBN);
            if (count <= 3 && !isBookTaken)
            {
                if (index == -1)
                {
                    message = "The ISBN you entered could nto be found";
                }
                else
                {
                    if (returnDay <= 60)
                    {
                        loanedBooks.Add(new BookLoaning(loanedBooks.Count, name, books[index].ISBN,
                            DateTime.Now, DateTime.Now.AddDays(returnDay), null));
                        borrowedBooks = JsonSerializer.Serialize(loanedBooks);
                        bookLoaningRepository.UpdateTakenBooks(borrowedBooks);
                        message = "You may take the book";
                    }
                    else
                    {
                        message = "You cant take the book for so long";
                    }
                }    
            }
            else
            {
                if (isBookTaken)
                {
                    message = "This book is taken :/";
                }
                else
                {
                    message = "YOU HAVE ENOUGH BOOKS";
                }
            }
            return message;
        }

        public int findBookIndex(string ISBN)
        {
            List<Book> books = bookRepository.GetAllBooks();
            int index = -1;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ISBN == ISBN)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        
    }
}
