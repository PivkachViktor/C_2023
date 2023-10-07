using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections;

namespace CNI
{
    class Class1
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            // Додавання елементів у стек (приклад)
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            int product = CalculateProductOfOddElementsAtEvenPositions(stack);

            if (product == 0)
            {
                Console.WriteLine("Непарних елементів, що стоять на парних позиціях в стеку немає");
            }
            else
            {
                Console.WriteLine("Добуток непарних елементів на парних позиціях: " + product);
            }
        }

        static int CalculateProductOfOddElementsAtEvenPositions(Stack<int> stack)
        {
            int product = 1;
            int position = 0;

            foreach (int element in stack)
            {
                if (position % 2 == 0 && element % 2 != 0)
                {
                    product *= element;
                }

                position++;
            }

            return product;

        }
    }
}