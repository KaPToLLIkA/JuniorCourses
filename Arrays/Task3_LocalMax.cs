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

            int offset = 1;

            Console.WriteLine("Local max:");

            if (array[0] >= array[1])
            {
                Console.WriteLine($"[{0}]:{array[0]}");
            }

            for (int i = offset; i < arrayLength - offset; ++i)
            {
                int leftItemIndex = i - offset;
                int rightItemIndex = i + offset;

                if (array[i] >= array[leftItemIndex] && array[i] >= array[rightItemIndex])
                {
                    Console.WriteLine($"[{i}]:{array[i]}");
                }
            }

            int endItemIndex = arrayLength - 1;
            int preEndItemIndex = endItemIndex - 1;

            if (array[endItemIndex] >= array[preEndItemIndex])
            {
                Console.WriteLine($"[{endItemIndex}]:{array[endItemIndex]}");
            }
        }
    }
}
