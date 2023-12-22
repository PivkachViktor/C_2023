using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    public class ShoppingList
    {
        private List<ShoppingItem> _items;

        public ShoppingList()
        {
            _items = new List<ShoppingItem>();
        }

        // Додати елемент до списку
        public void Add(ShoppingItem item)
        {
            _items.Add(item);
            Console.WriteLine($"Added: {item}");
        }

        // Видалити елемент із списку
        public void Remove(ShoppingItem item)
        {
            if (_items.Remove(item))
            {
                Console.WriteLine($"Removed: {item}");
            }
            else
            {
                Console.WriteLine("Item not found in the list.");
            }
        }

        // Редагувати елемент в списку
        public void Edit(ShoppingItem oldItem, ShoppingItem newItem)
        {
            int index = _items.IndexOf(oldItem);
            if (index != -1)
            {
                _items[index] = newItem;
                Console.WriteLine($"Edited: {oldItem} to {newItem}");
            }
            else
            {
                Console.WriteLine("Item not found in the list.");
            }
        }

        
        // Показати весь список покупок з виведенням індексу
        public void DisplayList()
        {
            Console.WriteLine("===== Shopping List =====");
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"Index {i}: {_items[i]}");
            }
            Console.WriteLine("=========================");
        }


        // Отримати елемент за індексом
        public ShoppingItem GetItemByIndex(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                return _items[index];
            }
            return null;
        }

        // Підрахувати кількість елементів у списку
        public int Count => _items.Count;
    }

}
