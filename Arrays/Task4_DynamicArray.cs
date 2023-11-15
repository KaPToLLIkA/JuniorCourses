using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Task4
{
    internal class DynamicArray
    {
        public static void Main(string[] args)
        {
            const string InputNumberCommand = "1";
            const string SummCommand = "2";
            const string ExitCommand = "0";

            int arrayInitialSize = 0;
            int arraySizeDelta = 1;
            int currentArraySize = 0;
            int lastEmptyItemIndex = 0;
            
            var array = new int[arrayInitialSize];

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(
                    "Print command number:\n" +
                    $"{InputNumberCommand}. Input new number\n" +
                    $"{SummCommand}. Summ all numbers\n" +
                    $"{ExitCommand}. Exit");

                string commandsInput = Console.ReadLine();

                Console.Clear();

                switch (commandsInput)
                {
                    case InputNumberCommand:
                        Console.WriteLine("Print number:");

                        string numberInput = Console.ReadLine();

                        if (Int32.TryParse(numberInput, out var number))
                        {
                            if (currentArraySize >= array.Length)
                            {
                                Console.WriteLine("Array expanding");

                                int newArraySize = array.Length + arraySizeDelta;
                                var newArray = new int[newArraySize];

                                for (int i = 0; i < array.Length; ++i)
                                {
                                    newArray[i] = array[i];
                                }

                                array = newArray;
                            }

                            array[lastEmptyItemIndex] = number;
                            lastEmptyItemIndex++;
                            currentArraySize++;
                        }
                        else
                        {
                            Console.WriteLine("Error.");
                        }
                        break;

                    case SummCommand:
                        int summ = 0;

                        for (int i = 0; i < currentArraySize; ++i)
                        {
                            Console.Write($"{array[i]}, ");

                            summ += array[i];
                        }

                        Console.WriteLine($"\nCurrent summ: {summ}");
                        break;

                    case ExitCommand:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Error.");
                        break;
                }
            }
        }
    }
}
