using System;
using System.Collections.Generic;

namespace ConditionalOperationsAndLoops_Task5
{
    internal class CurrenciesConverter
    {
        public static void Main(string[] args)
        {
            const float DiamondsPriceInGold = 10f;
            const float EmeraldsPriceInDiamonds = 20f;

            const float DiamondsPriceInEmeralds = 1.0f / EmeraldsPriceInDiamonds;
            const float EmeraldsPriceInGold = EmeraldsPriceInDiamonds * DiamondsPriceInGold;

            const float GoldPriceInDiamonds = 1.0f / DiamondsPriceInGold;
            const float GoldPriceInEmeralds = 1.0f / EmeraldsPriceInGold;

            const string GoldCurrencyName = "GOLD";
            const string DiamondsCurrencyName = "DIAMONDS";
            const string EmeraldsCurrencyName = "EMERALDS";
            const string YesCommand = "YES";
            const string NoCommand = "NO";

            float goldCount = 10000;
            float diamondsCount = 0;
            float emeraldsCount = 0;

            string commandsInput = string.Empty;

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine(
                    $"Now your balance is: \n" +
                    $"{emeraldsCount} {EmeraldsCurrencyName};\n" +
                    $"{diamondsCount} {DiamondsCurrencyName};\n" +
                    $"{goldCount} {GoldCurrencyName}\n");

                Console.WriteLine(
                    $"\nDo you want to excange currencies?\n" +
                    $"Print \"{YesCommand}\" if you want or \"{NoCommand}\" if not.");

                commandsInput = Console.ReadLine().ToUpper();

                Console.Clear();

                if (commandsInput == YesCommand)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nLet's start the conversion . . .");
                    Console.ResetColor();

                    bool isConversionFailed = true;
                    bool isCurrencyIndexInvalid = true;
                    string currencyToConvertFrom = string.Empty;
                    string currencyToConvertTo = string.Empty;

                    while (isConversionFailed)
                    {
                        while (isCurrencyIndexInvalid)
                        {
                            Console.WriteLine(
                                $"Print index of the currency you want to convert from. \n" +
                                $"Available currencies:\n" +
                                $"1. {GoldCurrencyName},\n" +
                                $"2. {DiamondsCurrencyName},\n" +
                                $"3. {EmeraldsCurrencyName}.");

                            string currencyIndexInput = Console.ReadLine();
                            Console.Clear();

                            if (Int32.TryParse(currencyIndexInput, out int currencyIndex)
                                && currencyIndex >= 1 && currencyIndex <= 3)
                            {
                                currencyToConvertFrom = currencyIndex switch
                                {
                                    1 => GoldCurrencyName,
                                    2 => DiamondsCurrencyName,
                                    3 => EmeraldsCurrencyName,
                                    _ => throw new NotImplementedException()
                                };

                                if ((currencyToConvertFrom == GoldCurrencyName && goldCount > 0)
                                    || (currencyToConvertFrom == DiamondsCurrencyName && diamondsCount > 0)
                                    || (currencyToConvertFrom == EmeraldsCurrencyName && emeraldsCount > 0))
                                {
                                    isCurrencyIndexInvalid = false;
                                } 
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nNot enough {currencyToConvertFrom}. Try again, please.\n");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nI don't understand you. Try again, please.\n");
                                Console.ResetColor();
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(
                            $"\nCurrency exchange rates:\n" +
                            $"1 {DiamondsCurrencyName} = {DiamondsPriceInGold} {GoldCurrencyName}\n" +
                            $"1 {EmeraldsCurrencyName} = {EmeraldsPriceInGold} {GoldCurrencyName}\n" +
                            $"1 {EmeraldsCurrencyName} = {EmeraldsPriceInDiamonds} {DiamondsCurrencyName}");
                        Console.ResetColor();

                        float maxGoldCount = 0;
                        float maxDiamondsCount = 0;
                        float maxEmeraldsCount = 0;

                        switch (currencyToConvertFrom)
                        {
                            case GoldCurrencyName:
                                maxEmeraldsCount = goldCount / EmeraldsPriceInGold;
                                maxDiamondsCount = goldCount / DiamondsPriceInGold;

                                break;
                            case DiamondsCurrencyName:
                                maxGoldCount = diamondsCount / GoldPriceInDiamonds;
                                maxEmeraldsCount = diamondsCount / EmeraldsPriceInDiamonds;

                                break;
                            case EmeraldsCurrencyName:
                                maxGoldCount = emeraldsCount / GoldPriceInEmeralds;
                                maxDiamondsCount = emeraldsCount / DiamondsPriceInEmeralds;

                                break;
                        }

                        isCurrencyIndexInvalid = true;

                        while (isCurrencyIndexInvalid)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(
                                $"\nYou can get no more than\n" +
                                $"{maxGoldCount} {GoldCurrencyName}\n" +
                                $"{maxDiamondsCount} {DiamondsCurrencyName}\n" +
                                $"{maxEmeraldsCount} {EmeraldsCurrencyName}\n");
                            Console.ResetColor();

                            Console.WriteLine(
                                $"Print index of the currency you want to convert to. \n" +
                                $"Available currencies:\n" +
                                $"1. {GoldCurrencyName},\n" +
                                $"2. {DiamondsCurrencyName},\n" +
                                $"3. {EmeraldsCurrencyName}.");

                            string currencyIndexInput = Console.ReadLine();

                            Console.Clear();

                            if (Int32.TryParse(currencyIndexInput, out int currencyIndex)
                                && currencyIndex >= 1 && currencyIndex <= 3)
                            {
                                currencyToConvertTo = currencyIndex switch
                                {
                                    1 => GoldCurrencyName,
                                    2 => DiamondsCurrencyName,
                                    3 => EmeraldsCurrencyName,
                                    _ => throw new NotImplementedException()
                                };

                                if (currencyToConvertTo != currencyToConvertFrom)
                                {
                                    isCurrencyIndexInvalid = false;
                                }
                            }

                            if (isCurrencyIndexInvalid)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nI don't understand you. Try again, please.\n");
                                Console.ResetColor();
                            }
                        }

                        bool isCurrencyCountInvalid = true;
                        float targetCurrencyCount = 0;

                        while (isCurrencyCountInvalid)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(
                                $"\nYou can get no more than\n" +
                                $"{maxGoldCount} {GoldCurrencyName}\n" +
                                $"{maxDiamondsCount} {DiamondsCurrencyName}\n" +
                                $"{maxEmeraldsCount} {EmeraldsCurrencyName}\n");
                            Console.ResetColor();

                            Console.WriteLine(
                                $"Print the count of " +
                                $"{currencyToConvertTo} you want to receive.");

                            string currencyCountInput = Console.ReadLine();

                            Console.Clear();

                            if (float.TryParse(currencyCountInput, out targetCurrencyCount)
                                 && targetCurrencyCount > 0)
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

                        Console.ForegroundColor = ConsoleColor.Red;

                        if (currencyToConvertFrom == GoldCurrencyName)
                        {
                            if (currencyToConvertTo == EmeraldsCurrencyName)
                            {
                                float requiredCurrencyCount = targetCurrencyCount * EmeraldsPriceInGold;
                                if (requiredCurrencyCount > goldCount)
                                {
                                    float notEnoughCount = requiredCurrencyCount - goldCount;

                                    Console.WriteLine($"{notEnoughCount} {currencyToConvertFrom} was not enough\n");
                                }
                                else
                                {
                                    goldCount -= requiredCurrencyCount;
                                    emeraldsCount += targetCurrencyCount;
                                    isConversionFailed = false;
                                }
                            }
                            else if (currencyToConvertTo == DiamondsCurrencyName)
                            {
                                float requiredCurrencyCount = targetCurrencyCount * DiamondsPriceInGold;
                                if (requiredCurrencyCount > goldCount)
                                {
                                    float notEnoughCount = requiredCurrencyCount - goldCount;

                                    Console.WriteLine($"{notEnoughCount} {currencyToConvertFrom} was not enough\n");
                                }
                                else
                                {
                                    goldCount -= requiredCurrencyCount;
                                    diamondsCount += targetCurrencyCount;
                                    isConversionFailed = false;
                                }
                            }
                        }
                        else if (currencyToConvertFrom == EmeraldsCurrencyName)
                        {
                            if (currencyToConvertTo == GoldCurrencyName)
                            {
                                float requiredCurrencyCount = targetCurrencyCount * GoldPriceInEmeralds;
                                if (requiredCurrencyCount > emeraldsCount)
                                {
                                    float notEnoughCount = requiredCurrencyCount - emeraldsCount;

                                    Console.WriteLine($"{notEnoughCount} {currencyToConvertFrom} was not enough\n");
                                }
                                else
                                {
                                    emeraldsCount -= requiredCurrencyCount;
                                    goldCount += targetCurrencyCount;
                                    isConversionFailed = false;
                                }
                            }
                            else if (currencyToConvertTo == DiamondsCurrencyName)
                            {
                                float requiredCurrencyCount = targetCurrencyCount * DiamondsPriceInEmeralds;
                                if (requiredCurrencyCount > emeraldsCount)
                                {
                                    float notEnoughCount = requiredCurrencyCount - emeraldsCount;

                                    Console.WriteLine($"{notEnoughCount} {currencyToConvertFrom} was not enough\n");
                                }
                                else
                                {
                                    emeraldsCount -= requiredCurrencyCount;
                                    goldCount += targetCurrencyCount;
                                    isConversionFailed = false;
                                }
                            }
                        }
                        else if (currencyToConvertFrom == DiamondsCurrencyName)
                        {
                            if (currencyToConvertTo == EmeraldsCurrencyName)
                            {
                                float requiredCurrencyCount = targetCurrencyCount * EmeraldsPriceInDiamonds;
                                if (requiredCurrencyCount > diamondsCount)
                                {
                                    float notEnoughCount = requiredCurrencyCount - diamondsCount;

                                    Console.WriteLine($"{notEnoughCount} {currencyToConvertFrom} was not enough\n");
                                }
                                else
                                {
                                    diamondsCount -= requiredCurrencyCount;
                                    emeraldsCount += targetCurrencyCount;
                                    isConversionFailed = false;
                                }
                            }
                            else if (currencyToConvertTo == GoldCurrencyName)
                            {
                                float requiredCurrencyCount = targetCurrencyCount * GoldPriceInDiamonds;
                                if (requiredCurrencyCount > diamondsCount)
                                {
                                    float notEnoughCount = requiredCurrencyCount - diamondsCount;

                                    Console.WriteLine($"{notEnoughCount} {currencyToConvertFrom} was not enough\n");
                                }
                                else
                                {
                                    diamondsCount -= requiredCurrencyCount;
                                    goldCount += targetCurrencyCount;
                                    isConversionFailed = false;
                                }
                            }
                        }

                        if (isConversionFailed)
                        {
                            Console.WriteLine("Conversion failed");
                        }

                        Console.ResetColor();
                    }
                }
                else if (commandsInput == NoCommand)
                {
                    isWorking = false;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("power off");
        }
    }
}
