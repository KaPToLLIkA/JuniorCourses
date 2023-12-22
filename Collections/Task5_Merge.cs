namespace Collections_Task5
{
    internal static class Merge
    {
        public static void Main(string[] args)
        {
            int[] list1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] list2 = new int[] { 1, 2, 3, 13, 2, 10, 15, 16, 1, 0 };

            list1.ToList().Print();
            list2.ToList().Print();

            List<int> resultList = new();

            resultList.AddUniqueRange(list1);
            resultList.AddUniqueRange(list2);

            resultList.Print();
        }

        public static void AddUniqueRange<T>(this List<T> list, T[] values)
        {
            foreach (T value in values)
            {
                if (list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
        }

        public static void Print<T>(this List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine();
        }
    }
}
