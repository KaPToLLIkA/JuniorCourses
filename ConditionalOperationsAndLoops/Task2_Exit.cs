namespace ConditionalOperationsAndLoops_Task2
{
    internal class Exit
    {
        public static void Main(string[] args)
        {
            string exitCommand = "exit";

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Repeat.");
                Console.WriteLine("Print EXIT to exit.");

                string input = Console.ReadLine().ToLower();

                if (input == exitCommand)
                {
                    isRunning = false;
                }
            }

            Console.WriteLine("Exited");
        }
    }
}
