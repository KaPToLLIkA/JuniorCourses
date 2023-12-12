using System;

namespace Collections_Task3
{
    internal class DynamicArray
    {
        public static void Main(string[] args)
        {
            List<int> inputedValues = new();

            const string ExitCommand = "E"; 
            const string SummCommand = "S"; 

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

                        foreach (int value in inputedValues)
                        {
                            Console.Write($"{value}, ");
                            summ += value;
                        }

                        Console.WriteLine($"\nSumm: {summ}");

                        break;

                    case ExitCommand:
                        isRunning = false;
                        break;

                    default:
                        string numberInput = commandsInput;

                        if (int.TryParse(numberInput, out int number))
                        {
                            inputedValues.Add(number);

                            foreach (int value in inputedValues)
                            {
                                Console.Write($"{value}, ");
                            }

                            Console.WriteLine();
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
