using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;
using WE02Library;

namespace WE02Console
{
    class Program
    {
        private static List<Account> _accounts;
        private static Account _currentAccount;
        static void Main(string[] args)
        {

            //var klanten = new List<Client>();
            //klanten.Add(new Client("Wim", "Hambrouck"));
            //klanten.Add(new Client("Johan", "Jannsens"));
            //klanten.Add(new Client("Els", "Leys"));



            _accounts = new List<Account>();
            _accounts.Add(new RegularAccount("23456", 1000M, DateTime.Now, 0.02M, null));
            //rekeningen.Add(new SavingsAccount("321654", 2000M, DateTime.Now, 0.05M, klanten[2], 0.02M));

            _currentAccount = _accounts[0];

            bool doorgaan = true;

            while (doorgaan)
            {
                Console.Clear();
                ConsoleHelper.TekenKader("MyBank© management system V1.0");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"-= CURRENT ACCOUNT =-\n{_currentAccount}");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;

                ConsoleHelper.TekenKader("Main menu", false);
                var opties = new List<string> { "Withdraw", "Deposit", "New bank account", "Switch account" };
                switch (ConsoleHelper.Menu(opties))
                {
                    case 0:
                        Console.WriteLine("Bye!");
                        doorgaan = false;
                        break;
                    case 1:
                        Withdraw(_currentAccount);
                        break;
                    case 2:
                        Deposit(_currentAccount);
                        break;
                    case 3:
                        CreateAccount();
                        break;
                    case 4:
                        SwitchAccount();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static void SwitchAccount()
        {
            Console.Clear();

            ConsoleHelper.TekenKader("Switch account", false);

            int i = 1;
            foreach (var account in _accounts)
            {
                Console.WriteLine($"{i++} - {account.IBAN} ({account.AccountType})");
            }
            Console.ReadLine();
        }

        private static void CreateAccount()
        {
            Console.Clear();
            ConsoleHelper.TekenKader("New bank account", false);
            var opties = new List<string> { "Regular account", "Savings account" };
            switch (ConsoleHelper.Menu(opties, "Cancel"))
            {
                case 0:
                    break;
                case 1:
                    _accounts.Add(NewRegularAccount());
                    break;
                case 2:
                    _accounts.Add(NewSavingsAccount());
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static RegularAccount NewRegularAccount()
        {
            Console.Write("IBAN: ");
            string iban = Console.ReadLine();

            Console.WriteLine("Credit cards (q to stop input):");
            var creditCards = new List<string>();
            
            string invoer = Console.ReadLine();
            while (invoer != "q")
            {
                creditCards.Add(invoer);
                invoer = Console.ReadLine();
            }

            return new RegularAccount(iban, 0, DateTime.Now, 0.2m, null, creditCards);
        }

        private static SavingsAccount NewSavingsAccount()
        {
            Console.Write("IBAN: ");
            string iban = Console.ReadLine();

            return new SavingsAccount(iban, 0, DateTime.Now, 0.5m, null, 0.2M);
        }

        private static void Deposit(Account currentAccount)
        {
            bool doorgaan = true;

            while (doorgaan)
            {
                Console.WriteLine();
                Console.Write("Amount to deposit: ");

                string input = Console.ReadLine();
                decimal amount;

                while (!decimal.TryParse(input, out amount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input must be a number.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.Write("Amount to deposit: ");
                    input = Console.ReadLine();
                }

                try
                {
                    currentAccount.Deposit(amount);
                    doorgaan = false;
                }
                catch (ArgumentException ex) // gegooid als bedrag < 0
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        private static void Withdraw(Account currentAccount)
        {
            bool doorgaan = true;

            while (doorgaan)
            {
                Console.WriteLine();
                Console.Write("Amount to withdraw: ");

                string input = Console.ReadLine();
                decimal amount;

                while (!decimal.TryParse(input, out amount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input must be a number.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.Write("Amount to withdraw: ");
                    input = Console.ReadLine();
                }

                try
                {
                    currentAccount.Withdraw(amount);
                    doorgaan = false;
                }
                catch (ArgumentException ex) // gegooid als bedrag < 0
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (InvalidOperationException ex) // gegooid als balance < -1000 zou worden door afhaling
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey(true);
                    doorgaan = false;
                }
            }
        }
    }
}
