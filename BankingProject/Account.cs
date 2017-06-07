using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BankingProject {

    public class Account {

        public int Id { get; set; }
        public double Balance { get; private set; }
        public double AvailableBalance { get; set; }
        public string Description { get; set; }
        private Customer customer = null;
        public Customer Customer {
            get {
                return customer;
            }
            set {
                customer = value;
                Customer cust = value;
                cust.Accounts.Add(this);
            }
        }
        public bool IsLocked { get; set; }

        private void CheckIsLocked() {
            if(IsLocked == true) {
                ApplicationException aex = new ApplicationException("The account is locked.");
                throw aex;
            }
        }
        public double GetBalance() {
            return Balance;
        }
        public void Transfer(double amount, Account acctIn) {
            CheckIsLocked();
            if (Withdraw(amount)) {
                acctIn.Deposit(amount);
                Debug.WriteLine("Transfer from " + this.Description + " to " + acctIn.Description);
            }
        }
        // return true of amount is negative
        private bool CheckForNegativeAmount(double amount) {
            if (amount < 0) {
                Debug.WriteLine("Amount cannot be less than zero.");
                return true;
            } else {
                return false;
            }
        }
        public bool Deposit(double amount) {
            CheckIsLocked();
            if (!CheckForNegativeAmount(amount)) {
                Balance += amount;
                Program.Logger("Deposit of " + amount.ToString() + " successful!");
                return true;
            }
            Program.Logger("Deposit of " + amount.ToString() + " failed because negaive amount!");
            return false;
        }
        public bool Withdraw(double amount) {
            CheckIsLocked();
            if (CheckForNegativeAmount(amount)) {
                return false;
            }
            if (amount > Balance) {
                Debug.WriteLine("Insufficient funds ...");
                return false;
            } else {
                Balance -= amount;
                return true;
            }
        }
        public void Display() {
            string message = String.Format("Account: id is {0}, desc is {1}, balance is {2}, cust name is {3}", 
                Id, Description, Balance, Customer.Name);
            Debug.WriteLine(message);
        }
        public Account(string description) {
            this.Description = description;
        }
        public Account() {
            IsLocked = false;
        }
    }
}
