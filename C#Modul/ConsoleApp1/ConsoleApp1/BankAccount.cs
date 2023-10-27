using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BankAccount
    {
        public string OwnerName { get; set; }
        public string TIN { get; set; }
        public decimal Balance { get; private set; }
        public List<AccountReplenishment> Replenishments { get; } = new List<AccountReplenishment>();

        public BankAccount(string ownerName, string tin)
        {
            OwnerName = ownerName;
            TIN = tin;
            Balance = 0;
        }

        public void ReplenishAccount(AccountReplenishment replenishment)
        {
            Replenishments.Add(replenishment);
            Balance += replenishment.Amount;
        }
    }
}
