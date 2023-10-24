using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConditionalOperationsAndLoops_Task5
{
    internal class CurrenciesConverter
    {
        public static void Main(string[] args)
        {
            const string ExitCommand = "0";

            const string GoldToDiamondsCommand = "1";
            const string GoldToEmeraldsCommand = "2";

            const string DiamondsToGoldCommand = "3";
            const string DiamondsToEmeraldsCommand = "4";

            const string EmeraldsToGoldCommand = "5";
            const string EmeraldsToDiamondsCommand = "6";

            float diamondPriceInGold = 10f;
            float emeraldPriceInDiamonds = 20f;

            float diamondPriceInEmeralds = 1.0f / emeraldPriceInDiamonds;
            float emeraldPriceInGold = emeraldPriceInDiamonds * diamondPriceInGold;

            float goldPriceInDiamonds = 1.0f / diamondPriceInGold;
            float goldPriceInEmeralds = 1.0f / emeraldPriceInGold;

            string goldCurrencyName = "GOLD";
            string diamondsCurrencyName = "DIAMONDS";
            string emeraldsCurrencyName = "EMERALDS";

            string commandsInput = string.Empty;

            float goldCount = 10000;
            float diamondsCount = 0;
            float emeraldsCount = 0;

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine(
                    $"Now your balance is: \n" +
                    $"{emeraldsCount} {emeraldsCurrencyName};\n" +
                    $"{diamondsCount} {diamondsCurrencyName};\n" +
                    $"{goldCount} {goldCurrencyName}\n");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(
                    $"\nCurrency exchange rates:\n" +
                    $"1 {diamondsCurrencyName} = {diamondPriceInGold} {goldCurrencyName}\n" +
                    $"1 {emeraldsCurrencyName} = {emeraldPriceInGold} {goldCurrencyName}\n" +
                    $"1 {emeraldsCurrencyName} = {emeraldPriceInDiamonds} {diamondsCurrencyName}");
                Console.ResetColor();

                Console.WriteLine(
                    $"Print index of menu command:\n" +
                    $"1. {goldCurrencyName} To {diamondsCurrencyName}\n" +
                    $"2. {goldCurrencyName} To {emeraldsCurrencyName}\n" +
                    $"3. {diamondsCurrencyName} To {goldCurrencyName}\n" +
                    $"4. {diamondsCurrencyName} To {emeraldsCurrencyName}\n" +
                    $"5. {emeraldsCurrencyName} To {goldCurrencyName}\n" +
                    $"6. {emeraldsCurrencyName} To {diamondsCurrencyName}\n" +
                    $"0. EXIT.");

                commandsInput = Console.ReadLine();

                Console.Clear();

                bool isCurrencyCountInvalid = true;
                float requestedCurrencyCount = 0;

                Console.Clear();
                Console.WriteLine("Print the currency count you want to receive:");

                while (isCurrencyCountInvalid)
                {
                    string currencyCountInput = Console.ReadLine();

                    if (float.TryParse(currencyCountInput, out requestedCurrencyCount)
                        && requestedCurrencyCount >= 0)
                    {
                        isCurrencyCountInvalid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nI don't understand you. Try again, please.\n");
                        Console.ResetColor();
                    }
                }

                float requiredCurrencyCount = 0;
                float notEnoughCount = 0;

                switch (commandsInput)
                {
                    case GoldToDiamondsCommand:
                        requiredCurrencyCount = requestedCurrencyCount * diamondPriceInGold;

                        if (requiredCurrencyCount > goldCount)
                        {
                            notEnoughCount = requiredCurrencyCount - goldCount;

                            Console.WriteLine($"{notEnoughCount} {goldCurrencyName} was not enough\n");
                        }
                        else
                        {
                            goldCount -= requiredCurrencyCount;
                            diamondsCount += requestedCurrencyCount;
                        }
                        break;

                    case GoldToEmeraldsCommand:
                        requiredCurrencyCount = requestedCurrencyCount * emeraldPriceInGold;

                        if (requiredCurrencyCount > goldCount)
                        {
                            notEnoughCount = requiredCurrencyCount - goldCount;

                            Console.WriteLine($"{notEnoughCount} {goldCurrencyName} was not enough\n");
                        }
                        else
                        {
                            goldCount -= requiredCurrencyCount;
                            emeraldsCount += requestedCurrencyCount;
                        }
                        break;

                    case DiamondsToGoldCommand:
                        requiredCurrencyCount = requestedCurrencyCount * goldPriceInDiamonds;

                        if (requiredCurrencyCount > diamondsCount)
                        {
                            notEnoughCount = requiredCurrencyCount - diamondsCount;

                            Console.WriteLine($"{notEnoughCount} {diamondsCurrencyName} was not enough\n");
                        }
                        else
                        {
                            diamondsCount -= requiredCurrencyCount;
                            goldCount += requestedCurrencyCount;
                        }
                        break;

                    case DiamondsToEmeraldsCommand:
                        requiredCurrencyCount = requestedCurrencyCount * emeraldPriceInDiamonds;

                        if (requiredCurrencyCount > diamondsCount)
                        {
                            notEnoughCount = requiredCurrencyCount - diamondsCount;

                            Console.WriteLine($"{notEnoughCount} {diamondsCurrencyName} was not enough\n");
                        }
                        else
                        {
                            diamondsCount -= requiredCurrencyCount;
                            emeraldsCount += requestedCurrencyCount;
                        }
                        break;

                    case EmeraldsToGoldCommand:
                        requiredCurrencyCount = requestedCurrencyCount * goldPriceInEmeralds;

                        if (requiredCurrencyCount > emeraldsCount)
                        {
                            notEnoughCount = requiredCurrencyCount - emeraldsCount;

                            Console.WriteLine($"{notEnoughCount} {emeraldsCurrencyName} was not enough\n");
                        }
                        else
                        {
                            emeraldsCount -= requiredCurrencyCount;
                            goldCount += requestedCurrencyCount;
                        }
                        break;

                    case EmeraldsToDiamondsCommand:
                        requiredCurrencyCount = requestedCurrencyCount * diamondPriceInEmeralds;

                        if (requiredCurrencyCount > emeraldsCount)
                        {
                            notEnoughCount = requiredCurrencyCount - emeraldsCount;

                            Console.WriteLine($"{notEnoughCount} {emeraldsCurrencyName} was not enough\n");
                        }
                        else
                        {
                            emeraldsCount -= requiredCurrencyCount;
                            diamondsCount += requestedCurrencyCount;
                        }
                        break;

                    case ExitCommand:
                        isWorking = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nCommand input error. Try again.\n");
                        Console.ResetColor();
                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("power off");
        }
    }
}
