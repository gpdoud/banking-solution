using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject {

    public class NegativeInputException : Exception {

        public double Amount { get; set; }

        public NegativeInputException(string Message, Exception innerException) 
            : base(Message, innerException) {
        }
        public NegativeInputException(string Message) 
            : base(Message) {
        }
        public NegativeInputException() 
            : base() {
        }
    }
}
