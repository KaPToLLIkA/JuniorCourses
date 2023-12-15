namespace Functions_Task3
{
    internal class GetInt
    {
        public static void Main(string[] args)
        {
            string startMessage = "Print int value:";

            int parsedValue = GetIntFromConsoleInput(startMessage);

            Console.WriteLine($"Your value: {parsedValue}");
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
    }
}
