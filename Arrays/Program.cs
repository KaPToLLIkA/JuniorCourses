﻿namespace Arrays
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
                    Arrays_Task1.ConcreteRowColumn.Main,
                    "Concrete Row Column"
                ),
                new CourseTask(
                    Arrays_Task2.MaxElement.Main,
                    "Max element"
                ),
                new CourseTask(
                    Arrays_Task3.LocalMax.Main,
                    "Local max"
                ),
                new CourseTask(
                    Arrays_Task4.DynamicArray.Main,
                    "Dynamic array"
                ),
                new CourseTask(
                    Arrays_Task5.SubArray.Main,
                    "Sub array"
                ),
                new CourseTask(
                    Arrays_Task6.Sort.Main,
                    "Merge sort"
                ),
                new CourseTask(
                    Arrays_Task7.Split.Main,
                    "Split"
                ),
                new CourseTask(
                    Arrays_Task8.CyclicShift.Main,
                    "Cyclic shift"
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