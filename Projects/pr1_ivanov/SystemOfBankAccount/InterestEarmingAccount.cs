using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOfBankAccount.Base;

namespace SystemOfBankAccount
{
    //вклад
    class InterestEarmingAccount : BankAccount
    {

        public InterestEarmingAccount(string owner, decimal intitialBalance)
            : base(owner, intitialBalance)
        {

        }


        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }

    }
}
