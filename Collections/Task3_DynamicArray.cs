namespace Collections_Task3
{
    internal class DynamicArray
    {
        public static void Main(string[] args)
        {
            const string ExitCommand = "E";
            const string SummCommand = "S";

            Dictionary<string, string> commandsDescriptions = new()
            {
                {SummCommand, "Summ all numbers"},
                {ExitCommand, "Exit"},
            };

            List<int> inputedValues = new();

            bool isRunning = true;

            while (isRunning)
            {
                PrintMenu(commandsDescriptions);

                string commandsInput = Console.ReadLine();

                switch (commandsInput)
                {
                    case SummCommand:
                        SummValues(inputedValues);
                        break;

                    case ExitCommand:
                        isRunning = false;
                        break;

                    default:

                        if(int.TryParse(commandsInput, out int parsedValue))
                        {
                            inputedValues.Add(parsedValue);
                        }
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

        private static void SummValues(List<int> values)
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
