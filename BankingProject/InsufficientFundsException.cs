using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject {
    class InsufficientFundsException  : Exception {

        public double Amount { get; set; }
        public double Balance { get; set; }

        public InsufficientFundsException(string Message, Exception innerException) 
            : base(Message, innerException) {
        }
        public InsufficientFundsException(string Message) 
            : base(Message) {
        }
        public InsufficientFundsException() 
            : base() {
        }
    }
}
