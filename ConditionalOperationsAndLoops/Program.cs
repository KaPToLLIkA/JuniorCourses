namespace ConditionalOperationsAndLoops
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
                null,
                null,
                null,
                null,
                new CourseTask(
                    ConditionalOperationsAndLoops_Task5.CurrenciesConverter.Main,
                    "Currencies converter"
                ),
                new CourseTask(
                    ConditionalOperationsAndLoops_Task6.ConsoleMenu.Main,
                    "Console menu"
                ),
                new CourseTask(
                    ConditionalOperationsAndLoops_Task7.NameBox.Main,
                    "Name box"
                ),
                new CourseTask(
                    ConditionalOperationsAndLoops_Task8.PasswordApp.Main,
                    "Password app"
                ),
                new CourseTask(
                    ConditionalOperationsAndLoops_Task9.Multiples.Main,
                    "Multiples"
                ),
                new CourseTask(
                    ConditionalOperationsAndLoops_Task10.PowerOfTwo.Main,
                    "Power of two"
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