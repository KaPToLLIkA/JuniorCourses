namespace Fundamentals_Task5
{
    internal class Swap
    {
        public static void Main(string[] args)
        {
            string firstName = "Petrov";
            string lastName = "Vitya";

            Console.WriteLine($"First name: {firstName}, last name: {lastName}");

            (firstName, lastName) = (lastName, firstName);

            Console.WriteLine($"First name: {firstName}, last name: {lastName}");
        }
    }
}
