using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ShoppingItem
    {
        public string Name { get; set; }       // Назва товару
        public int Quantity { get; set; }      // Кількість товару
        public bool IsBought { get; set; }     // Статус куплення товару

        // Конструктор класу
        public ShoppingItem(string name, int quantity, bool isBought)
        {
            Name = name;
            Quantity = quantity;
            IsBought = isBought;
        }

        // Перевизначення методу ToString для зручності виведення
        public override string ToString()
        {
            return $"Item: {Name} | Quantity: {Quantity} | Bought: {(IsBought ? "Yes" : "No")}";
        }
    }
}
