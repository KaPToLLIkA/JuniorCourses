namespace Collections_Task2
{
    internal class Clients
    {
        public static void Main(string[] args)
        {
            Queue<int> clients = GenerateClientsQueue(count: 26, minCostValue: 100, maxCostValue: 1000);

            int currentCoins = 0;
            int servicedClientsCount = 0;

            while (clients.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"Queue length: {clients.Count}");
                Console.WriteLine($"Serviced clients count: {servicedClientsCount}");
                Console.WriteLine($"Current coins: {currentCoins}");

                int nextPurchaseAmount = clients.Dequeue();

                Console.WriteLine($"Next client purchase amount: {nextPurchaseAmount}");
                Console.WriteLine("Press any key to service this client...");

                Console.ReadKey();

                servicedClientsCount++;
                currentCoins += nextPurchaseAmount;
            }

            Console.Clear();
            Console.WriteLine("Queue is empty.");
            Console.WriteLine($"Serviced clients count: {servicedClientsCount}");
            Console.WriteLine($"Total coins: {currentCoins}");
        }

        private static Queue<int> GenerateClientsQueue(int count, int minCostValue, int maxCostValue)
        {
            Queue<int> clients = new();

            Random random = new();

            for (int i = 0; i < count; ++i)
            {
                clients.Enqueue(random.Next(minCostValue, maxCostValue));
            }

            return clients;
        }
    }
}
