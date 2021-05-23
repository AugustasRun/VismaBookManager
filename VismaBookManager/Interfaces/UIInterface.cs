using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaBookManager.Models;

namespace VismaBookManager.Interfaces
{
    interface UIInterface
    {
        public void PrintAllBooks(List<Book> books);

        public void PrintTakenBooks(List<BookLoaning> takenBooks);

    }
}
