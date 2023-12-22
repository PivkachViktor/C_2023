using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Commands
{
    public class EditCommand : ICommand
    {
        private ShoppingList _shoppingList; // Посилання на список покупок
        private ShoppingItem _oldItem;     // Старий елемент покупки
        private ShoppingItem _newItem;     // Новий елемент покупки

        // Конструктор
        public EditCommand(ShoppingList shoppingList, ShoppingItem oldItem, ShoppingItem newItem)
        {
            _shoppingList = shoppingList;
            _oldItem = oldItem;
            _newItem = newItem;
        }

        public void Execute()
        {
            _shoppingList.Edit(_oldItem, _newItem); // Виконати редагування
        }

        public void Undo()
        {
            _shoppingList.Edit(_newItem, _oldItem); // Скасувати редагування
        }

        public void Redo()
        {
            Execute(); // Повторити редагування
        }
    }

}
