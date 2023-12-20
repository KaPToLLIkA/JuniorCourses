namespace OOP
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
                    Main,
                    "Concrete Row Column"
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

                if (Int32.TryParse(input, out intConvertedInput)
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
