using ConsoleApp1;
using System;


//Доційно використовувати шаблон Singleton.за допомогою нього можна створити і отримувати єдиний екземпляр класу у моєму випадку це FinancialMonitiring.
class Program
{
    static void Main()
    {
        BankAccount account1 = new BankAccount("John Doe", "00");
        BankAccount account2 = new BankAccount("Jane Smith", "01");

        FinancialMonitoring financialMonitoring = new FinancialMonitoring();
        financialMonitoring.AddAccount(account1);
        financialMonitoring.AddAccount(account2);

        
        account1.ReplenishAccount(new AccountReplenishment { Purpose = "Salary", Date = DateTime.Now, Amount = 200000 });
        account2.ReplenishAccount(new AccountReplenishment { Purpose = "Car Sale", Date = DateTime.Now, Amount = 250000 });

        financialMonitoring.CheckReplenishments();

        Console.ReadLine();
    }
}