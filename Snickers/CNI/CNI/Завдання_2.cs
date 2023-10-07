using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNI
{
    internal class Завдання_2
    {
        static void Main(string[] args)
        {
            // Створення черги та додавання елементів (назв штатів США)
            Queue<string> statesQueue = new Queue<string>();
            statesQueue.Enqueue("California");
            statesQueue.Enqueue("Texas");
            statesQueue.Enqueue("New York");
            statesQueue.Enqueue("Florida");
            statesQueue.Enqueue("Illinois");

            // Виведення всіх елементів на консоль в прямому порядку
            Console.WriteLine("Елементи в прямому порядку:");
            foreach (string state in statesQueue)
            {
                Console.WriteLine(state);
            }

            // Виведення всіх елементів на консоль в зворотному порядку
            Console.WriteLine("\nЕлементи в зворотному порядку:");
            string[] statesArray = statesQueue.ToArray();
            for (int i = statesArray.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(statesArray[i]);
            }

            // Виведення кількості елементів у колекції
            Console.WriteLine("\nКількість елементів у колекції: " + statesQueue.Count);

            // Очищення колекції
            statesQueue.Clear();
            Console.WriteLine("\nКолекція очищена.");

            // Перевірка кількості елементів після очищення
            Console.WriteLine("Кількість елементів у колекції після очищення: " + statesQueue.Count);
        }
    }
}
