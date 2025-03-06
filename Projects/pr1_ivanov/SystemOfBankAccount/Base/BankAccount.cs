using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOfBankAccount.ValueObjects;

namespace SystemOfBankAccount.Base
{
    // abstract - когда не надо создавать класс, для послед. ООП
    abstract class BankAccount 
    {
        // _ = будем использовать поле
        protected List<Transaction> _allTransactions = new List<Transaction>();
        // s_ = static
        private static int s_accountNumberSeed = 1000000000;
        public NumberOfBankAccount Number { get; }
        public string Owner { get; set; }

        // decimal точнее чем double (нету ошибок округления)
        public decimal Balance 
        { 
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }  
                return balance;                
            }

        }
        public BankAccount(string owner, decimal intitialBalance)
        {
            Number = new NumberOfBankAccount(s_accountNumberSeed++);
            Owner = owner;
            MakeDeposit(intitialBalance, DateTime.Now, "Initial balance");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Error. Amount of deposit must be positive.");
            var deposit = new Transaction(amount, date, note);
                _allTransactions.Add(deposit);


        }
        // withdrawal - списание
        public virtual void MakeWithdrawal(decimal amount, DateTime date, string note)
        {

            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Error. Amount of withdrawal must be positive."); 

            if (Balance-amount < 0)
                throw new InvalidOperationException( "Error. Not sufficient rubls for this withdrawal");

            _allTransactions.Add(new Transaction(-amount,date,note));
        }
        
        public string GetAccountHistory()
        {
            // класс string неизменяем // нельзя изменить написанное
            var str = new StringBuilder();
            foreach (var item in _allTransactions)
            {
                str.AppendLine(item.ToString());
            }
            return str.ToString();
        }

        public abstract void PerformMonthEndTransactions();


    }
}
