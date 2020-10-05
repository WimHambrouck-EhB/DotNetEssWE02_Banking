using System;
using System.Collections.Generic;
using System.Text;

namespace BankingLibrary
{
    class RegularAccount : Account
    {
        public List<string> CreditCards { get; set; }

        public RegularAccount(string iban, decimal balance, DateTime creationDate, decimal interest, List<string> creditCards = null) : base(iban, balance, creationDate, interest)
        {
            if(creditCards == null)
            {
                CreditCards = new List<string>();
            }
            else
            {
                CreditCards = creditCards;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                "Credit cards: " + string.Join(", ", CreditCards);
        }
    }
}
