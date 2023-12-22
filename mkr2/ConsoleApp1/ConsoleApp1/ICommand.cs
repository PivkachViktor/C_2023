using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ICommand
    {
        void Execute(); // Виконання команди
        void Undo();    // Скасування команди
        void Redo();    // Повторення команди
    }
}
