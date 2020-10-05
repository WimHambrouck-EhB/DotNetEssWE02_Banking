using BankingLibrary;
using System;
using System.Collections.Generic;

namespace BankingWE02
{
    class Program
    {
        static void Main(string[] args)
        {
            var cards = new List<string> { "1234 456", "3216547" };

            var regular = new RegularAccount("BE81 1234 5678 9871", 1000M, DateTime.Now, 0.02M, cards);

            

            Console.WriteLine(regular);

        }
    }
}
