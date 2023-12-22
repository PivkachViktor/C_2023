using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CommandManager
    {
        private Stack<ICommand> _executedCommands; // Стек виконаних команд
        private Stack<ICommand> _undoneCommands;  // Стек скасованих команд

        public CommandManager()
        {
            _executedCommands = new Stack<ICommand>();
            _undoneCommands = new Stack<ICommand>();
        }

        // Виконати команду
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _executedCommands.Push(command);
            _undoneCommands.Clear(); // При новій команді стираємо скасовані
        }

        // Скасувати останню виконану команду
        public void UndoLastCommand()
        {
            if (_executedCommands.Count > 0)
            {
                ICommand command = _executedCommands.Pop();
                command.Undo();
                _undoneCommands.Push(command);
            }
        }

        // Повторити останню скасовану команду
        public void RedoLastUndoneCommand()
        {
            if (_undoneCommands.Count > 0)
            {
                ICommand command = _undoneCommands.Pop();
                command.Redo();
                _executedCommands.Push(command);
            }
        }
    }

}
