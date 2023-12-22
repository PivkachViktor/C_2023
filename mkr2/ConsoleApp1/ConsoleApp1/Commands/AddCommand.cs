using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    public class AddCommand : ICommand
    {
        private ShoppingList _shoppingList; // Посилання на список покупок
        private ShoppingItem _item;        // Елемент покупки, який буде додано

        // Конструктор
        public AddCommand(ShoppingList shoppingList, ShoppingItem item)
        {
            _shoppingList = shoppingList;
            _item = item;
        }

        public void Execute()
        {
            _shoppingList.Add(_item); // Додати елемент до списку
        }

        public void Undo()
        {
            _shoppingList.Remove(_item); // Скасувати додавання
        }

        public void Redo()
        {
            Execute(); // Повторити додавання
        }
    }

}
