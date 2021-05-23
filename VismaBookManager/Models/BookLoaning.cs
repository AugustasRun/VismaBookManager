using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaBookManager.Interfaces;

namespace VismaBookManager.Models
{
    public class BookLoaning : LoaningInterface
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public DateTime LoaningDate { get; set; }
        public DateTime ExpectedReturn { get; set; }
        public DateTime? ActualReturn { get; set; }

        public BookLoaning(int index, string name, string iSBN, 
            DateTime loaningDate, DateTime expectedReturn, 
            DateTime? actualReturn)
        {
            Index = index;
            Name = name;
            ISBN = iSBN;
            LoaningDate = loaningDate;
            ExpectedReturn = expectedReturn;
            ActualReturn = actualReturn;
        }

        public override string ToString()
        {
            return string.Format("|{0,-10}|{1,-20}|{2,-20}|{3,-15}|{4,-20}|", this.Index, this.Name,this.ISBN,LoaningDate.ToShortDateString(),ExpectedReturn.ToShortDateString());
        }
    }
}
