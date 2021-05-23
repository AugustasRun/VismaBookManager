using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VismaBookManager.Models;

namespace VismaBookManager.PublicationRepository
{
    public class BookLoaningRepository
    {
        public List<BookLoaning> GetTakenBooks()
        {
            List<BookLoaning> loanedBooks = new List<BookLoaning>();
            string borrowedBooks = File.ReadAllText("BorrewedBooks.json");
            if (borrowedBooks != "")
            {
                loanedBooks = JsonSerializer.Deserialize<List<BookLoaning>>(borrowedBooks);
            }
            return loanedBooks;

        }

        public void UpdateTakenBooks(string jsonString)
        {
            File.WriteAllText("BorrewedBooks.json", jsonString);
        }

        public void FileValidation()
        {
            if (!File.Exists("BorrewedBooks.json"))
            {
                File.Create("BorrewedBooks.json").Close();
            }
        }

    }
}
