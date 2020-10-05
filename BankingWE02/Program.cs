using BankingLibrary;
using System;
using System.Collections.Generic;

namespace BankingWE02
{
    class Program
    {
        static void Main(string[] args)
        {

            var rekeningen = new List<Account>();
            rekeningen.Add(new RegularAccount("23456", 1000M, DateTime.Now, 0.02M));
            rekeningen.Add(new SavingsAccount("321654", 2000M, DateTime.Now, 0.05M, 0.02M));


            foreach (var rekening in rekeningen)
            {
                Console.WriteLine(rekening);
                Console.WriteLine();
            }

        }
    }
}
