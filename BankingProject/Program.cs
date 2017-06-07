using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingLibraryProject;

namespace BankingProject {

    public class Program {

        public static void Logger(string Message) {
            LogCollection.Logger(Message);
        }

        void Run() {
            Customer cust1 = new Customer(1, "Max Tech Training");
            cust1.Username = "MTT12345";
            cust1.Password = "password";
            cust1.Display();

            Account acct1 = new Account("My First Account");
            acct1.Id = 100;
            acct1.Deposit(100.0);
            acct1.Customer = cust1;
            acct1.Display();
            acct1.Withdraw(25.0);
            acct1.Display();
            acct1.Withdraw(1000.0);
            acct1.Display();
            acct1.Deposit(-300.0);
            acct1.Display();
            acct1.Withdraw(-500.0);
            acct1.Display();
            // transfer 25 from one to another
            Account acct2 = new Account();
            acct2.Id = 200;
            acct2.Description = "My second account";
            acct2.Customer = cust1;
            acct2.Display();

            acct1.Display();
            acct2.Display();
            acct1.Transfer(25.0, acct2);
            acct1.Display();
            acct2.Display();

            // savings class
            Savings sav1 = new Savings("My first savings account");
            sav1.Id = 300;
            sav1.Customer = cust1;
            sav1.Deposit(500.00);
            sav1.Withdraw(200.00);
            sav1.Display();
            sav1.intRate = .12;
            sav1.PayInterest();
            sav1.Display();
            sav1.IsLocked = true;
            try {
                sav1.Deposit(10.00);
            } catch(ApplicationException ex) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            double bal = acct1.Balance;

            // produce monthly statement
            cust1.MonthlyStatement();
        }

        static void Main(string[] args) {
            try {
                (new Program()).Run();
            } catch (NegativeInputException ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("The amount is " + ex.Amount.ToString());
                Console.WriteLine("press any key ...");
                Console.ReadKey();
            } catch(InsufficientFundsException ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine("The amount is " + ex.Amount.ToString());
                Console.WriteLine("The balance is " + ex.Balance.ToString());
                Console.WriteLine("press any key ...");
                Console.ReadKey();
            } catch (Exception ex) {
                Console.WriteLine("GENERAL EXCEPTION: " + ex.Message);
                Console.WriteLine("press any key ...");
                Console.ReadKey();
            }
        }
    }
}
