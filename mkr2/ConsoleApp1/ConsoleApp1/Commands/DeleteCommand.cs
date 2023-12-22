using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    public class DeleteCommand : ICommand
    {
        private ShoppingList _shoppingList; // Посилання на список покупок
        private ShoppingItem _item;        // Елемент покупки, який буде видалено

        // Конструктор
        public DeleteCommand(ShoppingList shoppingList, ShoppingItem item)
        {
            _shoppingList = shoppingList;
            _item = item;
        }

        public void Execute()
        {
            _shoppingList.Remove(_item); // Виконати видалення
        }

        public void Undo()
        {
            _shoppingList.Add(_item); // Скасувати видалення, додати назад елемент
        }

        public void Redo()
        {
            Execute(); // Повторити видалення
        }
    }

}
