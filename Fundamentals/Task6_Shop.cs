namespace Fundamentals_Task6
{
    internal class Shop
    {
        public static void Main(string[] args)
        {
            int diamondPrice = 50;

            Console.Write("Print available gold count: ");

            int availableGoldCount = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Diamond price: {diamondPrice}\nPrint count of diamonds you want to buy: ");

            int requestedDiamondsCount = Convert.ToInt32(Console.ReadLine());

            int diamondsCount = requestedDiamondsCount;
            int remainingGoldCount = availableGoldCount - requestedDiamondsCount * diamondPrice;

            Console.WriteLine($"Gold: {remainingGoldCount}, Diamonds: {diamondsCount}");
        }
    }
}
