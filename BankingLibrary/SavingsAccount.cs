﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankingLibrary
{
    public class SavingsAccount : Account
    {
        public decimal LoyaltyBonus { get; set; }

        public override string AccountType => "Savings account";

        public SavingsAccount(string iban, decimal balance, DateTime creationDate, decimal interest, decimal loyaltyBonus) : base(iban, balance, creationDate, interest)
        {
            LoyaltyBonus = loyaltyBonus;
        }

        public override string ToString()
        {
            return base.ToString() + $", Loyalty bonus: {LoyaltyBonus:C}";
        }
    }
}
