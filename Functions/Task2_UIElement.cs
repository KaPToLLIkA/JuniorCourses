using System.Text;

namespace Functions_Task2
{
    internal class UIElement
    {
        public static void Main(string[] args)
        {
            int delayPerFrame = 100;
            bool isRunning = true;

            float minHealthValue = 0f;
            float maxHealthValue = 2230f;
            float deltaHealtValue = 60f;
            float currentHealthValue = minHealthValue;

            float minManaValue = 0f;
            float maxManaValue = 11350f;
            float deltaManaValue = 100f;
            float currentManaValue = minManaValue;

            while (isRunning)
            {
                currentHealthValue = Math.Clamp(currentHealthValue + deltaHealtValue, minHealthValue, maxHealthValue);
                currentManaValue = Math.Clamp(currentManaValue + deltaManaValue, minManaValue, maxManaValue);

                PrintHealthBar(
                    currentHealthValue,
                    maxHealthValue,
                    left: 10,
                    top: 10,
                    barLength: 40);

                PrintManaBar(
                    currentManaValue,
                    maxManaValue,
                    left: 10,
                    top: 12,
                    barLength: 40);

                if (currentHealthValue + float.Epsilon >= maxHealthValue)
                {
                    currentHealthValue = minHealthValue;
                }

                if (currentManaValue + float.Epsilon >= maxManaValue)
                {
                    currentManaValue = minManaValue;
                }

                Thread.Sleep(delayPerFrame);
                Console.Clear();
            }
        }

        private static void PrintHealthBar(
            float currentValue,
            float maxValue,
            int left,
            int top,
            int barLength
            )
        {
            ConsoleColor backgroundColor = ConsoleColor.Yellow;
            ConsoleColor foregroundColor = ConsoleColor.Green;

            PrintBar(
                currentValue,
                maxValue,
                backgroundColor,
                foregroundColor,
                left,
                top,
                barLength);
        }

        private static void PrintManaBar(
            float currentValue,
            float maxValue,
            int left,
            int top,
            int barLength
            )
        {
            ConsoleColor backgroundColor = ConsoleColor.Yellow;
            ConsoleColor foregroundColor = ConsoleColor.Blue;

            PrintBar(
                currentValue,
                maxValue,
                backgroundColor,
                foregroundColor,
                left,
                top,
                barLength);
        }

        private static void PrintBar(
            float currentValue,
            float maxValue,
            ConsoleColor backgroundColor,
            ConsoleColor foregroundColor,
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
