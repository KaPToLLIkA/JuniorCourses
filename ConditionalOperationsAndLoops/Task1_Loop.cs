namespace ConditionalOperationsAndLoops_Task1
{
    internal class Loop
    {
        public static void Main(string[] args)
        {
            Console.Write("Print message: ");
            string message = Console.ReadLine();

            Console.Write("Repeating count: ");
            int repeatingCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= repeatingCount; i++)
            {
                Console.WriteLine($"{i} : {message}");
            }
        }
    }
}
