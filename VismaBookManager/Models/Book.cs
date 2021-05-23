using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaBookManager.Interfaces;

namespace VismaBookManager.Models
{
    public class Book : PublicationInterface, IEquatable<Book>
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public DateTime Publication_date { get; set; }
        public string ISBN { get; set; }

        public Book(string name, string author, string category,
            string language, DateTime publication_date, string iSBN)
        {
            Name = name;
            Author = author;
            Category = category;
            Language = language;
            Publication_date = publication_date;
            ISBN = iSBN;
        }

        public bool Equals(Book other)
        {
            if (this.ISBN.Equals(other.ISBN))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("|{0,-15}|{1,-20}|{2,-15}|{3,-15}|{4,-20}|{5,-20}|", this.Name,this.Author, this.Category,this.Language,this.Publication_date.ToShortDateString(),this.ISBN);
        }
    }
}
