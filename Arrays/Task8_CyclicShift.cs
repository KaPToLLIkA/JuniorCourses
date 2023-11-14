using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task8
{
    internal class CyclicShift
    {
        public static void Main(string[] args)
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, };

            Console.WriteLine("Before:");

            foreach (int number in numbers)
            {
                Console.Write($"{number}, ");
            }

            Console.WriteLine("\nPrint shift:");

            string input = Console.ReadLine();

            if (Int32.TryParse(input, out int shift))
            {
                int trimmedShift = shift % numbers.Length;
                int currentPosition = 0;
                int nextPosition = 0;
                int bufferItem = numbers[currentPosition];

                for (int i = 1; i < numbers.Length; i++)
                {
                    nextPosition = (currentPosition + trimmedShift) % numbers.Length;

                    (numbers[nextPosition], bufferItem) = (bufferItem, numbers[nextPosition]);

                    currentPosition = nextPosition;
                }

                nextPosition = (currentPosition + trimmedShift) % numbers.Length;
                numbers[nextPosition] = bufferItem;

                Console.WriteLine("After:");

                foreach (int number in numbers)
                {
                    Console.Write($"{number}, ");
                }
            }
        }
    }
}
