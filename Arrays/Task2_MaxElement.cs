using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task2
{
    internal class MaxElement
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int maxRandomValue = 20;
            int minRandomValue = 10;

            int maxValueInArray = int.MinValue;

            int rowsCount = 10;
            int columnsCount = 10;

            var array = new int[columnsCount, rowsCount];

            Console.WriteLine($"Array:");

            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    array[i, j] = random.Next(minRandomValue, maxRandomValue);

                    Console.Write($"{array[i, j],3}, ");

                    if (array[i, j] > maxValueInArray)
                    {
                        maxValueInArray = array[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Max value: {maxValueInArray}");
            Console.WriteLine($"Result Array:");

            int rewriteValue = 0;

            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    if (array[i, j] == maxValueInArray)
                    {
                        array[i, j] = rewriteValue;
                    }

                    Console.Write($"{array[i, j],3}, ");
                }

                Console.WriteLine();
            }
        }
    }
}
