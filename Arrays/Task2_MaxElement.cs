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
            int rowsCount = 10;
            int columnsCount = 10;

            Random random = new Random();
            int maxRandomValue = 20;
            int minRandomValue = 10;

            int maxValueInArray = int.MinValue;

            var array = new int[rowsCount, columnsCount];

            Console.WriteLine($"Array:");

            for (int y = 0; y < rowsCount; ++y)
            {
                for (int x = 0; x < columnsCount; ++x)
                {
                    array[y, x] = random.Next(minRandomValue, maxRandomValue);

                    Console.Write($"{array[y, x],3}, ");

                    if (array[y, x] > maxValueInArray)
                    {
                        maxValueInArray = array[y, x];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Max value: {maxValueInArray}");
            Console.WriteLine($"Result Array:");

            int stubNumber = 0;

            for (int y = 0; y < rowsCount; ++y)
            {
                for (int x = 0; x < columnsCount; ++x)
                {
                    if (array[y, x] == maxValueInArray)
                    {
                        array[y, x] = stubNumber;
                    }

                    Console.Write($"{array[y, x],3}, ");
                }

                Console.WriteLine();
            }
        }
    }
}
