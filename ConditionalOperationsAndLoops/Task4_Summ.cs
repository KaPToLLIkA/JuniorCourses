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
            int thirdDivider = firstDivider * secondDivider;

            int summ = 0;

            int minFirtsArithmetic = firstDivider;
            int firstSequenceLength = maxValue / firstDivider;
            int maxFirstArithmetic = firstSequenceLength * firstDivider;

            int minSecondArithmetic = secondDivider;
            int secondSequenceLength = maxValue / secondDivider;
            int maxSecondArithmetic = secondSequenceLength * secondDivider;

            int minThirdArithmetic = thirdDivider;
            int thirdSequenceLength = maxValue / thirdDivider;
            int maxThirdArithmetic = thirdSequenceLength * thirdDivider;

            summ += (minFirtsArithmetic + maxFirstArithmetic) / 2 * firstSequenceLength;
            summ += (minSecondArithmetic + maxSecondArithmetic) / 2 * secondSequenceLength;
            summ -= (minThirdArithmetic + maxThirdArithmetic) / 2 * thirdSequenceLength;

            Console.WriteLine($"Summ: {summ}");
        }
    }
}
