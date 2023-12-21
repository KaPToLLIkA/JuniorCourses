namespace Fundamentals_Task6
{
    internal class Shop
    {
        public static void Main(string[] args)
        {
            int diamondPrice = 50;

            Console.Write("Print available gold count: ");

            int goldCount = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Diamond price: {diamondPrice}\nPrint count of diamonds you want to buy: ");

            int diamondsCount = Convert.ToInt32(Console.ReadLine());

            goldCount -= diamondsCount * diamondPrice;

            Console.WriteLine($"Gold: {goldCount}, Diamonds: {diamondsCount}");
        }
    }
}
