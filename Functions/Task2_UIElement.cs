using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions_Task2
{
    internal class UIElement
    {
        public static void Main(string[] args)
        {
            int delayPerFrame = 100;
            bool isRunning = true;

            float minValue = 0f;
            float maxValue = 2230f;
            float deltaValue = 60f;

            while (isRunning)
            {
                float currentValue = minValue;

                while (currentValue < maxValue)
                {
                    currentValue = Math.Clamp(currentValue + deltaValue, minValue, maxValue);

                    PrintHealthBar(
                        currentValue,
                        maxValue,
                        left: 10,
                        top: 20,
                        barLength: 40);

                    Thread.Sleep(delayPerFrame);
                    Console.Clear();
                }
            }
        }

        private static void PrintHealthBar(
            float currentValue,
            float maxValue,
            ConsoleColor backgroundColor = ConsoleColor.Green,
            ConsoleColor foregroundColor = ConsoleColor.Yellow,
            int left = 0,
            int top = 0,
            int barLength = 30,
            string filledPart = "\u2588",
            string unfilledPart = "\u2591",
            string barLeftBorder = "",
            string barRightBorder = ""
            )
        {
            if (currentValue < 0 || currentValue > maxValue)
            {
                throw new ArgumentException(
                    $"Current value: {currentValue} - is not in range [0, {maxValue}].");
            }

            float fillingKoefficient = currentValue / maxValue;

            int filledLength = (int)Math.Round(barLength * fillingKoefficient, MidpointRounding.AwayFromZero);
            int unfilledLength = barLength - filledLength;

            Console.SetCursorPosition(left, top);

            ConsoleColor curBackgroundColor = Console.BackgroundColor;
            ConsoleColor curForegroundColor = Console.ForegroundColor;

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;

            string filledBarBody = RepeatString(filledPart, filledLength);
            string unfilledBarBody = RepeatString(unfilledPart, unfilledLength);

            string bar = $"{barLeftBorder}{filledBarBody}{unfilledBarBody}{barRightBorder}";

            Console.Write($"{bar}");

            Console.BackgroundColor = curBackgroundColor;

            Console.Write($" {currentValue}/{maxValue}");

            Console.ForegroundColor = curForegroundColor;
        }

        private static string RepeatString(string repeatable, int count)
        {
            StringBuilder stringBuilder = new();

            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append(repeatable);
            }

            return stringBuilder.ToString();
        }
    }
}
