namespace Collections
{
    internal class CourseTask
    {
        public CourseTask(Action<string[]> entryPoint, string description)
        {
            EntryPoint = entryPoint;
            Description = description;
        }

        public string Description { get; }

        public Action<string[]> EntryPoint { get; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var courseTasks = new List<CourseTask>
            {
                new CourseTask(
                    Collections_Task1.Dictionary.Main,
                    "Dictionary"
                ),
                new CourseTask(
                    Collections_Task2.Clients.Main,
                    "Clients"
                ),
                new CourseTask(
                    Collections_Task3.DynamicArray.Main,
                    "Dynamic array"
                ),
                new CourseTask(
                    Collections_Task4.PersonnelAccounting.Main,
                    "Personnel accounting"
                ),
                new CourseTask(
                    Collections_Task5.Merge.Main,
                    "Merge"
                ),
            };

            string noTaskText = "... task does'not exist ...";

            Console.WriteLine("Print number of task. \nAvailable:");

            for (int i = 0; i < courseTasks.Count; i++)
            {
                Console.WriteLine($"{i + 1} {courseTasks[i]?.Description ?? noTaskText}");
            }

            int taskIndex = GetValidatedIntInput(1, courseTasks.Count + 1) - 1;

            Console.Clear();

            courseTasks[taskIndex]?.EntryPoint.Invoke(args);
        }

        static int GetValidatedIntInput(int minInclusive, int maxExclusive)
        {
            bool isInputInvalid = true;
            string input = string.Empty;
            int intConvertedInput = 0;

            while (isInputInvalid)
            {
                input = Console.ReadLine();

                if (int.TryParse(input, out intConvertedInput)
                    && intConvertedInput >= minInclusive
                    && intConvertedInput < maxExclusive)
                {
                    isInputInvalid = false;
                }
                else
                {
                    Console.WriteLine(
                        $"Try again... \n" +
                        $"Value range is [{minInclusive};{maxExclusive}).");
                }
            }

            return intConvertedInput;
        }
    }
}
