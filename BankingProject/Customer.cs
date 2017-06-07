using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BankingProject {

    public class Customer {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Account> Accounts = new List<Account>();

        public void MonthlyStatement() {
            foreach(Account account in this.Accounts) {
                string description = account.Description;
                double balance = account.GetBalance();
                string type = account.GetType().Name;
                string message = String.Format("{2}: {0} balance is {1}", description, balance, type);
                Debug.WriteLine(message);
            }
        }
        public void Display() {
            string message = String.Format("Id is {0}, Name is {1}, Username is {2}", Id, Name, Username, Password);
            Debug.WriteLine(message);
        }

        public Customer(int id, string aName) {
            this.Id = id;
            this.Name = aName;
        }
        public Customer(string aName) {
            this.Name = aName;
        }
        public Customer() {
        }
    }
}
