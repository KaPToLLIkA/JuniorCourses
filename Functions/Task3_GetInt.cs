using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions_Task3
{
    internal class GetInt
    {
        public static void Main(string[] args)
        {
            string startMessage = "Print int value:";
            string onErrorMessage = "Wrong value. Try again.";

            int parsedValue = GetIntFromConsoleInput(startMessage, onErrorMessage);

            Console.WriteLine($"Your value: {parsedValue}");
        }

        private static int GetIntFromConsoleInput(string startMessage, string onErrorMessage)
        {
            bool isInputInvalid = true;

            int parsedValue = 0;

            while (isInputInvalid)
            {
                Console.WriteLine(startMessage);

                string input = Console.ReadLine();

                if (int.TryParse(input, out parsedValue))
                {
                    isInputInvalid = false;
                }
                else
                {
                    PrintErrorMessage(onErrorMessage);
                }
            }

            return parsedValue;
        }

        private static void PrintErrorMessage(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ForegroundColor = currentColor;
        }
    }
}
