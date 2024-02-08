namespace ConditionalOperationsAndLoops_Task4
{
    internal class Summ
    {
        public static void Main(string[] args)
        {
            int minRandomValue = 0;
            int maxRandomValue = 100;

            Random random = new();

            int maxValue = random.Next(minRandomValue, maxRandomValue);

            Console.WriteLine($"Value: {maxValue}");

            int firstDivider = 3;
            int secondDivider = 5;

            int summ = 0;

            for (int value = firstDivider; value <= maxValue; value++)
            {
                if (value % firstDivider == 0 || value % secondDivider == 0)
                {
                    summ += value;
                }
            }

            Console.WriteLine($"Summ: {summ}");
        }
    }
}
