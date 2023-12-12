namespace Collections_Task5
{
    internal class Merge
    {
        public static void Main(string[] args)
        {
            List<int> list1 = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> list2 = new() { 1, 2, 3, 13, 2, 10, 15, 16, 1, 0 };

            PrintList(list1);
            PrintList(list2);

            List<int> resultList = MergeLists(list1, list2);

            PrintList(resultList);
        }

        private static List<int> MergeLists(List<int> list1, List<int> list2)
        {
            HashSet<int> set = new();
            List<int> resultList = new();

            foreach (int item in list1)
            {
                set.Add(item);
            }

            foreach (int item in list2)
            {
                set.Add(item);
            }

            foreach (int item in set)
            {
                resultList.Add(item);
            }

            return resultList;
        }

        private static void PrintList(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine();
        }
    }
}
