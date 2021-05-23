using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaBookManager.Interfaces
{
    interface LoaningInterface
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public DateTime LoaningDate { get; set; }
        public DateTime ExpectedReturn { get; set; }
        public DateTime? ActualReturn { get; set; }

        public string ToString();

    }
}
