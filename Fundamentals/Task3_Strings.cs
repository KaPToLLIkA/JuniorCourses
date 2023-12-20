namespace Fundamentals_Task3
{
    internal class Strings
    {
        public static void Main(string[] args)
        {
            Console.Write("What is your name?\nMy name is: ");
            string name = Console.ReadLine();

            Console.Write("How old are you?\nMy age is: ");
            string age = Console.ReadLine();

            Console.WriteLine($"Your name is {name} and you are is {age} years old.");
        }
    }
}
