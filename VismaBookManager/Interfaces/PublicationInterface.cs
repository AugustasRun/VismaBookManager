using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaBookManager.Interfaces
{
    interface PublicationInterface 
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public DateTime Publication_date { get; set; }
        public string ISBN { get; set; }

        public string ToString();



    }
}
