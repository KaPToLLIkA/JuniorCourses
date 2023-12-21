namespace Collections_Task5
{
    internal class Merge
    {
        public static void Main(string[] args)
        {
            int[] list1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] list2 = new int[] { 1, 2, 3, 13, 2, 10, 15, 16, 1, 0 };

            PrintList(list1.ToList()); 
            PrintList(list2.ToList());

            List<int> resultList = MergeLists(list1, list2);

            PrintList(resultList);
        }

        private static List<int> MergeLists(int[] list1, int[] list2)
        {
            List<int> resultList = new();

            foreach (int number in list1)
            {
                if (resultList.Contains(number) == false)
                {
                    resultList.Add(number);
                }
            }

            foreach (int number in list2)
            {
                if (resultList.Contains(number) == false)
                {
                    resultList.Add(number);
                }
            }

            return resultList;
        }

        private static void PrintList(List<int> list)
        {
            foreach (int number in list)
            {
                Console.Write($"{number}, ");
            }

            Console.WriteLine();
        }
    }
}
