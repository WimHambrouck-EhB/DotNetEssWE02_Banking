using System;

namespace BankingLibrary
{
    public abstract class Account
    {
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Interest { get; set; }
        public abstract string AccountType { get; }
        public Client Client { get; set; }


        public Account(string iban, decimal balance, DateTime creationDate, decimal interest, Client client)
        {
            IBAN = iban;
            Balance = balance;
            CreationDate = creationDate;
            Interest = interest;
            Client = client;
        }

        /// <summary>
        /// Adds an amount to the balance of the account.
        /// </summary>
        /// <param name="amount">The amount to be added.</param>
        /// <exception cref="AmountInvalidException">Thrown when amount is 0 or negative.</exception>
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                throw new AmountInvalidException("Deposited amount must be a number higher than 0!");
            }
        }

        /// <summary>
        /// Subtracts an amount from the balance of the account.
        /// </summary>
        /// <param name="amount">The amount to subtract.</param>
        /// <exception cref="AmountInvalidException">Thrown when amount is 0 or negative.</exception>
        /// <exception cref="InvalidOperationException">Thrown if subtraction of amount would result in account to be overdrawn.</exception>"
        public void Withdraw(decimal amount)
        {
            decimal minimumBalance = -1000;

            if (amount <= 0)
            {
                throw new AmountInvalidException("Withdrawn amount must be a positive number!");
            }

            if (Balance - amount >= minimumBalance)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException($"Withdrawal would exceed minimum balance of {minimumBalance}!");
            }
        }

        public override string ToString()
        {
            return $"Client: {Client}, IBAN: {IBAN}, Balance: {Balance:C}, Created on: {CreationDate}, Interest: {Interest}";
        }
    }
}
