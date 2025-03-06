using System;
using System.Collections.Generic;
using SystemOfBankAccount.Base;

namespace SystemOfBankAccount
{
    class Program
    {          

        static void Main(string[] args)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();
            //bankAccounts.Add(new BankAccount())

            //var account1 = new InterestEarmingAccount("Qwerty1", 1000);
            /*Console.WriteLine($"Account {account1.Number.Value} "+
                                $"was created for {account1.Owner} " +
                                $"with {account1.Balance} initialBalance" );*/

            //var account2 = new LineOfCreaditAccount("Qwerty2", 2000);
            /*Console.WriteLine($"Account {account2.Number.Value} " +
                                $"was created for {account2.Owner} " +
                                $"with {account2.Balance} initialBalance");*/


            /*
            // m - обознача
            account1.MakeDeposit(100m, DateTime.Now, "GOIDA!!!!!");
            account1.MakeDeposit(777777m, DateTime.Now, "GOIDA!!!!!");
            account1.MakeWithdrawal(500m, DateTime.Now, "GOIDA!!!!!");

            Console.WriteLine($"Account {account1.Number.Value} " +
                                $"was created for {account1.Owner} " +
                                $"with {account1.Balance} initialBalance");

            Console.WriteLine(account1.GetAccountHistory());
            */
            
            try
            {
                var account3 = new LineOfCreaditAccount("Qwerty3", 1000);
                account3.MakeWithdrawal(10, DateTime.Now, "Sosal?");
                Console.WriteLine(account3.GetAccountHistory());

                Console.WriteLine($"Account {account3.Number.Value} " +
                                    $"was created for {account3.Owner} " +
                                    $"with {account3.Balance} initialBalance");
            }
            catch (ArgumentOutOfRangeException e) // самый дальний по ветви наследования // 
            {
                Console.WriteLine(e.Message, e.ParamName);
            }
            catch (InvalidOperationException e) 
            {
                Console.WriteLine(e.Message,e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e.ToString());
            }
            



        }
    }
}