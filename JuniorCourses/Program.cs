namespace JuniorCourses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Random random = new Random();

            float chanceIcyEmbrace = 0.9f;

            float currentChance = random.NextSingle();

            if (currentChance <= chanceIcyEmbrace)
            {
                // do smth
            }
        }
    }
}