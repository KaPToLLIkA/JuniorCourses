using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperationsAndLoops_Task9
{
    internal class Multiples
    {
        public static void Main(string[] args)
        {
            int minNumber = 1;
            int maxNumber = 27;

            Console.WriteLine($"Print number in range [{minNumber};{maxNumber}]:");

            bool isNumberInvalid = true;
            int number = 0;

            while (isNumberInvalid)
            {
                string inputNumber = Console.ReadLine();

                if (Int32.TryParse(inputNumber, out number)
                    && number >= minNumber
                    && number <= maxNumber)
                {
                    isNumberInvalid = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.Clear();

            int minValidValue = 100;
            int maxValidValue = 999;

            for (int i = 0; i <= maxValidValue; i += number)
            {
                if (i >= minValidValue)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
