using Microsoft.VisualStudio.TestTools.UnitTesting;
using VismaBookManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaBookManager.Models;

namespace VismaBookManager.Services.Tests
{
    [TestClass()]
    public class LibraryServiceTests
    {
        [TestMethod()]
        public void FilterBooksTestByAuthor()
        {
            string filterAuthor = "author1";
            List<Book> books = new List<Book>();
            List<Book> filteredBooks = new List<Book>();
            Book book1 = new Book("Name1", "author1", "category1", "language1",
                DateTime.Now, "ISBN1");
            Book book2 = new Book("Name2", "author12", "category2", "language2",
                DateTime.Now, "ISBN2");
            Book book3 = new Book("Name3", "author3", "category3", "language3",
                DateTime.Now, "ISBN3");
            Book book4 = new Book("Name4", "author14", "category4", "language4",
                DateTime.Now, "ISBN4");
            Book book5 = new Book("Name5", "author5", "category5", "language5",
                DateTime.Now, "ISBN5");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            filteredBooks = books.FindAll(b => b.Author.Contains(filterAuthor));
            Assert.AreEqual(book4, filteredBooks[2]);
        }

        [TestMethod()]
        public void FilterBooksTestByCategory()
        {
            string filterCategory = "category1";
            List<Book> books = new List<Book>();
            List<Book> filteredBooks = new List<Book>();
            Book book1 = new Book("Name1", "author1", "category1", "language1",
                DateTime.Now, "ISBN1");
            Book book2 = new Book("Name2", "author12", "category12", "language2",
                DateTime.Now, "ISBN2");
            Book book3 = new Book("Name3", "author3", "category3", "language3",
                DateTime.Now, "ISBN3");
            Book book4 = new Book("Name4", "author14", "category4", "language4",
                DateTime.Now, "ISBN4");
            Book book5 = new Book("Name5", "author5", "category15", "language5",
                DateTime.Now, "ISBN5");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            filteredBooks = books.FindAll(b => b.Category.Contains(filterCategory));
            Assert.AreEqual(book5, filteredBooks[2]);
        }

        [TestMethod()]
        public void FilterBooksTestByLanguage()
        {
            string filterLanguage = "language1";
            List<Book> books = new List<Book>();
            List<Book> filteredBooks = new List<Book>();
            Book book1 = new Book("Name1", "author1", "category1", "language1",
                DateTime.Now, "ISBN1");
            Book book2 = new Book("Name2", "author12", "category12", "language12",
                DateTime.Now, "ISBN2");
            Book book3 = new Book("Name3", "author3", "category3", "language13",
                DateTime.Now, "ISBN3");
            Book book4 = new Book("Name4", "author14", "category4", "language4",
                DateTime.Now, "ISBN4");
            Book book5 = new Book("Name5", "author5", "category15", "language5",
                DateTime.Now, "ISBN5");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            filteredBooks = books.FindAll(b => b.Language.Contains(filterLanguage));
            Assert.AreEqual(book3, filteredBooks[2]);
        }

        [TestMethod()]
        public void FilterBooksTestByISBN()
        {
            string filterISBN = "ISBN1";
            List<Book> books = new List<Book>();
            List<Book> filteredBooks = new List<Book>();
            Book book1 = new Book("Name1", "author1", "category1", "language1",
                DateTime.Now, "ISBN1");
            Book book2 = new Book("Name2", "author12", "category12", "language12",
                DateTime.Now, "ISBN2");
            Book book3 = new Book("Name3", "author3", "category3", "language13",
                DateTime.Now, "ISBN3");
            Book book4 = new Book("Name4", "author14", "category4", "language4",
                DateTime.Now, "ISBN4");
            Book book5 = new Book("Name5", "author5", "category15", "language5",
                DateTime.Now, "ISBN5");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            filteredBooks = books.FindAll(b => b.ISBN.Contains(filterISBN));
            Assert.AreEqual(book1, filteredBooks[0]);
        }

        [TestMethod()]
        public void FilterBooksTestByName()
        {
            string filterName = "ame1";
            List<Book> books = new List<Book>();
            List<Book> filteredBooks = new List<Book>();
            Book book1 = new Book("Name1", "author1", "category1", "language1",
                DateTime.Now, "ISBN1");
            Book book2 = new Book("Name2", "author12", "category12", "language12",
                DateTime.Now, "ISBN2");
            Book book3 = new Book("Name3", "author3", "category3", "language13",
                DateTime.Now, "ISBN3");
            Book book4 = new Book("Name4", "author14", "category4", "language4",
                DateTime.Now, "ISBN4");
            Book book5 = new Book("Name5", "author5", "category15", "language5",
                DateTime.Now, "ISBN5");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            filteredBooks = books.FindAll(b => b.Name.Contains(filterName));
            Assert.AreEqual(book1, filteredBooks[0]);
        }

        [TestMethod()]
        public void FilterBooksTestByTaken()
        {
            List<Book> books = new List<Book>();
            List<BookLoaning> bookLoanings = new List<BookLoaning>();
            List<Book> filteredBooks = new List<Book>();
            Book book1 = new Book("Name1", "author1", "category1", "language1",
                DateTime.Now, "ISBN1");
            Book book2 = new Book("Name2", "author12", "category12", "language12",
                DateTime.Now, "ISBN2");
            Book book3 = new Book("Name3", "author3", "category3", "language13",
                DateTime.Now, "ISBN3");
            Book book4 = new Book("Name4", "author14", "category4", "language4",
                DateTime.Now, "ISBN4");
            Book book5 = new Book("Name5", "author5", "category15", "language5",
                DateTime.Now, "ISBN5");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            BookLoaning loanedBook1 = new BookLoaning(0, "Name", "ISBN1", DateTime.Now, 
                DateTime.Now, null);
            BookLoaning loanedBook2 = new BookLoaning(1, "Name", "ISBN2", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook3 = new BookLoaning(2, "Name", "ISBN3", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook4 = new BookLoaning(3, "Name", "ISBN4", DateTime.Now,
                DateTime.Now, DateTime.Now);
            bookLoanings.Add(loanedBook1);
            bookLoanings.Add(loanedBook2);
            bookLoanings.Add(loanedBook3);
            bookLoanings.Add(loanedBook4);
            foreach (var book in books)
            {
                int appearance = 0;
                for (int i = bookLoanings.Count - 1; i >= 0; i--)
                {
                    if (book.ISBN == bookLoanings[i].ISBN && !bookLoanings[i].ActualReturn.HasValue)
                    {
                        appearance++;
                        break;
                    }
                }
                if (appearance == 0 != true)
                {
                    filteredBooks.Add(book);
                }
            }
            Assert.AreEqual(2, filteredBooks.Count);
        }

        [TestMethod()]
        public void FilterBooksTestByNotTaken()
        {
            List<Book> books = new List<Book>();
            List<BookLoaning> bookLoanings = new List<BookLoaning>();
            List<Book> filteredBooks = new List<Book>();
            Book book1 = new Book("Name1", "author1", "category1", "language1",
                DateTime.Now, "ISBN1");
            Book book2 = new Book("Name2", "author12", "category12", "language12",
                DateTime.Now, "ISBN2");
            Book book3 = new Book("Name3", "author3", "category3", "language13",
                DateTime.Now, "ISBN3");
            Book book4 = new Book("Name4", "author14", "category4", "language4",
                DateTime.Now, "ISBN4");
            Book book5 = new Book("Name5", "author5", "category15", "language5",
                DateTime.Now, "ISBN5");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            BookLoaning loanedBook1 = new BookLoaning(0, "Name", "ISBN1", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook2 = new BookLoaning(1, "Name", "ISBN2", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook3 = new BookLoaning(2, "Name", "ISBN3", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook4 = new BookLoaning(3, "Name", "ISBN4", DateTime.Now,
                DateTime.Now, DateTime.Now);
            bookLoanings.Add(loanedBook1);
            bookLoanings.Add(loanedBook2);
            bookLoanings.Add(loanedBook3);
            bookLoanings.Add(loanedBook4);
            foreach (var book in books)
            {
                int appearance = 0;
                for (int i = bookLoanings.Count - 1; i >= 0; i--)
                {
                    if (book.ISBN == bookLoanings[i].ISBN && !bookLoanings[i].ActualReturn.HasValue)
                    {
                        appearance++;
                        break;
                    }
                }
                if (appearance == 0 != false)
                {
                    filteredBooks.Add(book);
                }
            }
            Assert.AreEqual(3, filteredBooks.Count);
        }

        [TestMethod()]
        public void GetTakenBooksByNameTest()
        {
            List<BookLoaning> bookLoanings = new List<BookLoaning>();
            string name = "Name";
            BookLoaning loanedBook1 = new BookLoaning(0, "Name", "ISBN1", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook2 = new BookLoaning(1, "Name", "ISBN2", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook3 = new BookLoaning(2, "Name", "ISBN3", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook4 = new BookLoaning(3, "Name", "ISBN4", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook5 = new BookLoaning(4, "NotName", "ISBN4", DateTime.Now,
               DateTime.Now, DateTime.Now);
            bookLoanings.Add(loanedBook1);
            bookLoanings.Add(loanedBook2);
            bookLoanings.Add(loanedBook3);
            bookLoanings.Add(loanedBook4);
            bookLoanings.Add(loanedBook5);

            List<BookLoaning> loanedBooksByName = new List<BookLoaning>();

            for (int i = bookLoanings.Count - 1; i >= 0; i--)
            {
                if (bookLoanings[i].Name == name && bookLoanings[i].ActualReturn == null)
                {
                    loanedBooksByName.Add(bookLoanings[i]);
                }
            }
            Assert.AreEqual(2, loanedBooksByName.Count);
        }


        [TestMethod()]
        public void GetTakenBooksCountByNameTest()
        {
            List<BookLoaning> bookLoanings = new List<BookLoaning>();
            string name = "Name";
            BookLoaning loanedBook1 = new BookLoaning(0, "Name", "ISBN1", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook2 = new BookLoaning(1, "Name", "ISBN2", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook3 = new BookLoaning(2, "Name", "ISBN3", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook4 = new BookLoaning(3, "Name", "ISBN4", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook5 = new BookLoaning(4, "NotName", "ISBN4", DateTime.Now,
                DateTime.Now, DateTime.Now);
            bookLoanings.Add(loanedBook1);
            bookLoanings.Add(loanedBook2);
            bookLoanings.Add(loanedBook3);
            bookLoanings.Add(loanedBook4);
            bookLoanings.Add(loanedBook5);

            int count = 0;
            for (int i = bookLoanings.Count - 1; i >= 0; i--)
            {
                if (bookLoanings[i].Name == name && bookLoanings[i].ActualReturn == null)
                {
                    count++;
                }
                if (count >= 3)
                {
                    break;
                }
            }
            Assert.AreEqual(2, count);
        }


        [TestMethod()]
        public void IsBookTakenTest()
        {
            List<BookLoaning> bookLoanings = new List<BookLoaning>();
            string ISBN = "ISBN1";
            BookLoaning loanedBook1 = new BookLoaning(0, "Name", "ISBN1", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook2 = new BookLoaning(1, "Name", "ISBN2", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook3 = new BookLoaning(2, "Name", "ISBN3", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook4 = new BookLoaning(3, "Name", "ISBN4", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook5 = new BookLoaning(4, "NotName", "ISBN5", DateTime.Now,
               DateTime.Now, DateTime.Now);
            bookLoanings.Add(loanedBook1);
            bookLoanings.Add(loanedBook2);
            bookLoanings.Add(loanedBook3);
            bookLoanings.Add(loanedBook4);
            bookLoanings.Add(loanedBook5);

            bool testCase = false;
            for (int i = bookLoanings.Count - 1; i >= 0; i--)
            {
                if (bookLoanings[i].ISBN == ISBN && bookLoanings[i].ActualReturn == null)
                {
                    testCase=true;
                   
                }
            }
            Assert.AreEqual(true, testCase);
        }

        [TestMethod()]
        public void IsBookNotTakenTest()
        {
            List<BookLoaning> bookLoanings = new List<BookLoaning>();
            string ISBN = "ISBN4";
            BookLoaning loanedBook1 = new BookLoaning(0, "Name", "ISBN1", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook2 = new BookLoaning(1, "Name", "ISBN2", DateTime.Now,
                DateTime.Now, null);
            BookLoaning loanedBook3 = new BookLoaning(2, "Name", "ISBN3", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook4 = new BookLoaning(3, "Name", "ISBN4", DateTime.Now,
                DateTime.Now, DateTime.Now);
            BookLoaning loanedBook5 = new BookLoaning(4, "NotName", "ISBN4", DateTime.Now,
               DateTime.Now, DateTime.Now);
            bookLoanings.Add(loanedBook1);
            bookLoanings.Add(loanedBook2);
            bookLoanings.Add(loanedBook3);
            bookLoanings.Add(loanedBook4);
            bookLoanings.Add(loanedBook5);

            List<BookLoaning> loanedBooksByName = new List<BookLoaning>();
            bool testCase = false;
            for (int i = bookLoanings.Count - 1; i >= 0; i--)
            {
                if (bookLoanings[i].ISBN == ISBN && bookLoanings[i].ActualReturn == null)
                {
                    testCase = true;
                }
            }
            Assert.AreEqual(false, testCase);
        }

        [TestMethod()]
        public void FindBookIndex()
        {
            string ISBN = "ISBN5";
            List<Book> books = new List<Book>();
            Book book1 = new Book("Name1", "author1", "category1", "language1",
                DateTime.Now, "ISBN1");
            Book book2 = new Book("Name2", "author12", "category2", "language2",
                DateTime.Now, "ISBN2");
            Book book3 = new Book("Name3", "author3", "category3", "language3",
                DateTime.Now, "ISBN3");
            Book book4 = new Book("Name4", "author14", "category4", "language4",
                DateTime.Now, "ISBN4");
            Book book5 = new Book("Name5", "author5", "category5", "language5",
                DateTime.Now, "ISBN5");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            int index = -1;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ISBN == ISBN)
                {
                    index = i;
                    break;
                }
            }
            Assert.AreEqual(4, index);
        }

        [TestMethod()]
        public void FindBookIndexBotFound()
        {
            string ISBN = "ISBN6";
            List<Book> books = new List<Book>();
            Book book1 = new Book("Name1", "author1", "category1", "language1",
                DateTime.Now, "ISBN1");
            Book book2 = new Book("Name2", "author12", "category2", "language2",
                DateTime.Now, "ISBN2");
            Book book3 = new Book("Name3", "author3", "category3", "language3",
                DateTime.Now, "ISBN3");
            Book book4 = new Book("Name4", "author14", "category4", "language4",
                DateTime.Now, "ISBN4");
            Book book5 = new Book("Name5", "author5", "category5", "language5",
                DateTime.Now, "ISBN5");
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            int index = -1;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ISBN == ISBN)
                {
                    index = i;
                    break;
                }
            }
            Assert.AreEqual(-1, index);
        }

    }
}