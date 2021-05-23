using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VismaBookManager.ConsoleUI;
using VismaBookManager.Models;
using VismaBookManager.PublicationRepository;
using VismaBookManager.Services;

namespace VismaBookManager
{
    class BookRunner
    {
        private ConsoleInterface consoleUI;
        private BookRepository bookRepository;
        private BookLoaningRepository bookLoaningRepository;
        private LibraryService libraryService;

        public BookRunner(ConsoleInterface consoleUI)
        {
            this.consoleUI = consoleUI;
            bookRepository = new BookRepository();
            bookLoaningRepository = new BookLoaningRepository();
            libraryService = new LibraryService(bookRepository, bookLoaningRepository);
        }

        public void Run()
        {
            bool runner = true;
            while (runner)
            {
                consoleUI.Choice();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Input the book name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Input the book author");
                        string author = Console.ReadLine();
                        Console.WriteLine("Input the book category");
                        string category = Console.ReadLine();
                        Console.WriteLine("Input the book language");
                        string language = Console.ReadLine();
                        Console.WriteLine("Input the book publication date (the format is YYYY-MM-DD)");
                        DateTime publication_date = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Input the book ISBN");
                        string ISBN = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(bookRepository.AddBook(new Book(name, author, category, language, publication_date, ISBN))); 
                        break;
                    case 2:
                        consoleUI.Header();
                        consoleUI.PrintAllBooks(bookRepository.GetAllBooks());
                        Console.WriteLine("Input your name");
                        string takerName = Console.ReadLine();
                        Console.WriteLine("Input the ISBN of the book");
                        string takenISBN = Console.ReadLine();
                        Console.WriteLine("Input for how many days you want the book");
                        int takenFor = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine(libraryService.TakeBook(takenISBN,takerName,takenFor));

                        break;
                    case 3:
                        Console.WriteLine("Input your name");
                        string returnerName = Console.ReadLine();
                        
                        if (libraryService.TakenBookCount(returnerName) == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("You have no books to return");
                        }
                        else
                        {
                            consoleUI.HeaderForLoanedBooks();
                            consoleUI.PrintTakenBooks(libraryService.GetTakenBooksByName(returnerName));
                            Console.WriteLine("Input the index of which book you want to return");
                            int takenIndex = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine(libraryService.ReturnBook(takenIndex));
                        }
                        
                        break;
                    case 4:
                        consoleUI.Header();
                        consoleUI.PrintAllBooks(bookRepository.GetAllBooks());
                        consoleUI.FilterChoice();
                        int filterChoice = int.Parse(Console.ReadLine());
                        switch (filterChoice)
                        {
                            case 1:
                                Console.WriteLine("Input the author name");
                                string filterAuthor = Console.ReadLine();
                                consoleUI.Header();
                                consoleUI.PrintAllBooks(libraryService.FilterBooks(b => b.Author.Contains(filterAuthor)));
                                break;
                            case 2:
                                Console.WriteLine("Input the category");
                                string filterCategory = Console.ReadLine();
                                consoleUI.Header();
                                consoleUI.PrintAllBooks(libraryService.FilterBooks(b => b.Category.Contains(filterCategory)));
                                break;
                            case 3:
                                Console.WriteLine("Input the language");
                                string filterLanguage = Console.ReadLine();
                                consoleUI.Header();
                                consoleUI.PrintAllBooks(libraryService.FilterBooks(b => b.Language.Contains(filterLanguage)));
                                break;
                            case 4:
                                Console.WriteLine("Input the ISBN");
                                string filterISBN = Console.ReadLine();
                                consoleUI.Header();
                                consoleUI.PrintAllBooks(libraryService.FilterBooks(b => b.ISBN.Contains(filterISBN)));
                                break;
                            case 5:
                                Console.WriteLine("Input the name");
                                string filterName = Console.ReadLine();
                                consoleUI.Header();
                                consoleUI.PrintAllBooks(libraryService.FilterBooks(b => b.Name.Contains(filterName)));
                                break;
                            case 6:
                                Console.WriteLine("Do you want taken books? (Y/N)");
                                string filterTaken = Console.ReadLine();
                                bool filterBool = false;
                                if (filterTaken == "Y")
                                {
                                    filterBool = true;
                                }
                                consoleUI.Header();
                                consoleUI.PrintAllBooks(libraryService.FilterBooks(filterBool));
                                break;
                             default :

                                break;
                        }
                        break;
                    case 5:
                        consoleUI.Header();
                        consoleUI.PrintAllBooks(bookRepository.GetAllBooks());
                        Console.WriteLine("Input the ISBN of the book you want to delete");
                        string deletedISBN = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(bookRepository.RemoveBook(deletedISBN));
                        
                        break;
                    case 6:
                        runner = false;
                        break;


                }
            }
        }
    }
}
