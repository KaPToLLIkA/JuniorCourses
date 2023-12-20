namespace ConditionalOperationsAndLoops_Task3
{
    internal class Sequence
    {
        public static void Main(string[] args)
        {
            int startValue = 5;
            int endValue = 96;
            int deltaValue = 7;
            
            for (int currentValue = startValue; currentValue <= endValue; currentValue += deltaValue)
            {
                Console.WriteLine($"{currentValue}");
            }
        }
    }
}
