using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task3
{
    internal class LocalMax
    {
        public static void Main(string[] args)
        {
            int arrayLength = 30;
            var array = new int[arrayLength];

            Random random = new Random();
            int maxRandomValue = 1000;
            int minRandomValue = 100;

            for (int i = 0; i < arrayLength; ++i)
            {
                array[i] = random.Next(minRandomValue, maxRandomValue);

                Console.WriteLine($"[{i}]:{array[i]}");
            }

            int leftBound = 0;
            int rightBound = arrayLength - 1;
            int offset = 1;

            Console.WriteLine("Local max:");

            for (int i = 0; i < arrayLength; ++i)
            {
                bool isGreaterThenLeft = true;
                bool isGreaterThenRight = true;

                int leftItemIndex = i - offset;
                int rightItemIndex = i + offset;

                if (leftItemIndex >= leftBound)
                {
                    isGreaterThenLeft = array[i] >= array[leftItemIndex];
                }

                if (rightItemIndex <= rightBound)
                {
                    isGreaterThenRight = array[i] >= array[rightItemIndex];
                }

                if (isGreaterThenLeft && isGreaterThenRight)
                {
                    Console.WriteLine($"[{i}]:{array[i]}");
                }
            }
        }
    }
}
