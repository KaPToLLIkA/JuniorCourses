using System;
using System.Security;

namespace Collections_Task3
{
    internal class DynamicArray
    {
        public static void Main(string[] args)
        {
            const string ExitCommand = "E";
            const string SummCommand = "S";
            const string AddValueCommand = "A";

            Dictionary<string, string> commandsDescriptions = new()
            {
                {SummCommand, "Summ all numbers"},
                {AddValueCommand, "Add value"},
                {ExitCommand, "Exit"},
            };

            List<string> availableCommands = new()
            {
                ExitCommand,
                AddValueCommand,
                SummCommand,
            };

            List<int> inputedValues = new();

            bool isRunning = true;

            while (isRunning)
            {
                PrintMenu(commandsDescriptions);

                string commandsInput = GetCommandFromConsoleInput(availableCommands);
                
                switch (commandsInput)
                {
                    case SummCommand:
                        ProcessSummCommand(inputedValues);
                        break;

                    case AddValueCommand:
                        int value = GetIntFromConsoleInput("Print value:");

                        inputedValues.Add(value);
                        break;

                    case ExitCommand:
                        isRunning = false;
                        break;
                }
            }
        }

        private static void PrintMenu(Dictionary<string, string> commandsDescriptions)
        {
            Console.WriteLine("Menu:");

            foreach (KeyValuePair<string, string> keyValue in commandsDescriptions)
            {
                Console.WriteLine($"{keyValue.Key} {keyValue.Value}");
            }
        }

        private static string GetCommandFromConsoleInput(List<string> availableCommands)
        {
            string inputedCommand = "";

            while (!availableCommands.Contains(inputedCommand))
            {
                Console.WriteLine("Print command:");

                inputedCommand = Console.ReadLine();
            }

            return inputedCommand;
        }

        private static int GetIntFromConsoleInput(string startMessage)
        {
            int parsedValue;
            string input;

            do
            {
                Console.WriteLine(startMessage);

                input = Console.ReadLine();

            } while (!int.TryParse(input, out parsedValue));

            return parsedValue;
        }

        private static void ProcessSummCommand(List<int> values)
        {
            int summ = 0;

            foreach (int value in values)
            {
                Console.Write($"{value}, ");
                summ += value;
            }

            Console.WriteLine($"\nSumm: {summ}");
        }
    }
}
