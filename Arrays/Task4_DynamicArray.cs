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
            const string SummCommand = "S";
            const string ExitCommand = "E";
            
            var array = new int[0];

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(
                    "Print command:\n" +
                    $"{SummCommand}: Summ all numbers\n" +
                    $"{ExitCommand}: Exit");

                string commandsInput = Console.ReadLine();

                Console.Clear();

                switch (commandsInput)
                {
                    case SummCommand:
                        int summ = 0;

                        for (int i = 0; i < array.Length; ++i)
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
                        string numberInput = commandsInput;

                        if (Int32.TryParse(numberInput, out int number))
                        {
                            var tmpArray = new int[array.Length + 1];

                            for (int i = 0; i < array.Length; ++i)
                            {
                                tmpArray[i] = array[i];
                            }

                            array = tmpArray;

                            array[array.Length - 1] = number;
                        }
                        else
                        {
                            Console.WriteLine("Error.");
                        }
                        break;
                }
            }
        }
    }
}
