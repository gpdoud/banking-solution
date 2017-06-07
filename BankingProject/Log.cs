using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject {

    public class Log {

        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }

        public Log(string Message) {
            this.Message = Message;
            this.Timestamp = DateTime.Now;
            this.Id = 0;
        }
        public Log() {

        }
    }
}
