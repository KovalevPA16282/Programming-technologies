using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOfBankAccount.Base;
using SystemOfBankAccount.ValueObjects;



namespace SystemOfBankAccount
{
    class LineOfCreaditAccount : BankAccount
    {
        public decimal MinimumBalance { get; private set; }

        public LineOfCreaditAccount(string owner, decimal minimalBalance) : base(owner, 0m)
        {
            if (minimalBalance < 0m)
                throw new ArgumentOutOfRangeException(nameof(minimalBalance), "MinimumBalance of credit card must be positive");
            MinimumBalance = minimalBalance;
        }

        /*public LineOfCreaditAccount(string owner, decimal intitialBalance)
            : base(owner, intitialBalance)
        {
        }*/

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                MakeWithdrawal(-Balance * 0.07m, DateTime.Now, "charge monthly interest");
            }
        }

        public override void MakeWithdrawal(decimal amount, DateTime date, string note)
        {

            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Error. Amount of withdrawal must be positive.");

            if (Balance - amount < -MinimumBalance)
                throw new InvalidOperationException("Error. Not sufficient rubls for this withdrawal");

            _allTransactions.Add(new Transaction(-amount, date, note));
        }
    }
}
