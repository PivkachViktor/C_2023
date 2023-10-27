using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class FinancialMonitoring
    {
        private decimal Threshold = 400000; 
        private List<BankAccount> Accounts = new List<BankAccount>();

        public void AddAccount(BankAccount account)
        {
            Accounts.Add(account);
        }

        public void CheckReplenishments()
        {
            foreach (var account in Accounts)
            {
                decimal totalReplenishmentAmount = 0;
                foreach (var replenishment in account.Replenishments)
                {
                    totalReplenishmentAmount += replenishment.Amount;
                }
                if (totalReplenishmentAmount > Threshold)
                {
                    SendDataToTaxAuthority(account);
                }
            }
        }

        private void SendDataToTaxAuthority(BankAccount account)
        {
            Console.WriteLine($"Notification to the tax authority: Account {account.OwnerName}, TIN {account.TIN} exceeded the replenishment threshold.");
        }
    }
}
