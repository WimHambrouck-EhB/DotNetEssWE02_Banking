using System;
using System.Collections.Generic;
using WE02Library;

namespace WE02Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var klanten = new List<Client>();
            klanten.Add(new Client("Wim", "Hambrouck"));
            klanten.Add(new Client("Johan", "Jannsens"));
            klanten.Add(new Client("Els", "Leys"));



            var rekeningen = new List<Account>();
            rekeningen.Add(new RegularAccount("23456", 1000M, DateTime.Now, 0.02M, klanten[0]));
            rekeningen.Add(new SavingsAccount("321654", 2000M, DateTime.Now, 0.05M, klanten[2], 0.02M));


            foreach (var rekening in rekeningen)
            {
                Console.WriteLine(rekening);
                Console.WriteLine("----------------------------------------");
            }

        }
    }
}
