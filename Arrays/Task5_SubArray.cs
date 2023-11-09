using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task5
{
    internal class SubArray
    {
        public static void Main(string[] args)
        {
            int arrayLength = 30;
            var array = new int[arrayLength];

            Random random = new Random();
            int maxRandomValue = 5;
            int minRandomValue = 1;

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = random.Next(minRandomValue, maxRandomValue);

                Console.Write($"{array[i]}, ");
            }

            int maxRepetitionsCount = int.MinValue;
            int numberWithMaxRepetitons = int.MinValue;
            
            int numbersCount = 1;
            int previousNumber = array[0];

            for (int i = 1; i < arrayLength; i++)
            {
                if (array[i] == previousNumber)
                {
                    numbersCount++;
                }
                else
                {
                    if (numbersCount > maxRepetitionsCount)
                    {
                        numberWithMaxRepetitons = previousNumber;
                        maxRepetitionsCount = numbersCount;
                    }

                    numbersCount = 1;
                }

                previousNumber = array[i];
            }

            Console.WriteLine($"\nNumber: {numberWithMaxRepetitons} Count: {maxRepetitionsCount}");
        }
    }
}
