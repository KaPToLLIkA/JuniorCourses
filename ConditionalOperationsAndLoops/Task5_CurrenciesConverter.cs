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

            int emeralds = 10000;
            int diamonds = 10000;
            int gold = 10000;

            string commandsInput = string.Empty;
            bool isCommandInvalid = true;

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine(
                    $"Now your balance is: \n" +
                    $"{emeralds} {EmeraldsCurrencyName};\n" +
                    $"{diamonds} {DiamondsCurrencyName};\n" +
                    $"{gold} {GoldCurrencyName}\n");

                isCommandInvalid = true;

                while (isCommandInvalid)
                {
                    Console.WriteLine(
                        $"\nDo you want to excange currencies?\n" +
                        $"Print \"{YesCommand}\" if you want or \"{NoCommand}\" if not.");

                    commandsInput = Console.ReadLine().ToUpper();

                    if (commandsInput == YesCommand || commandsInput == NoCommand)
                    {
                        isCommandInvalid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nI don't understand you. Try again, please.\n");
                        Console.ResetColor();
                    }
                }

                Console.Clear();

                /*
                ДЛЯ МЕНТОРА:
                Здесь можно сделать выход через break по NoCommand,
                но я не знал как лучше будет и оставил так,
                хотя мне не нравится слишком большая вложенность тут.
                Судя по условию, в следующих заданиях исправится ситуация с большой вложенностью.
                */

                if (commandsInput == YesCommand)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nLet's start the conversion . . .");
                    Console.ResetColor();

                    bool isConversionFailed = true;
                    bool isCurrencyNameInvalid = true;
                    string currencyToConvertFrom = string.Empty;
                    string currencyToConvertTo = string.Empty;

                    while (isConversionFailed)
                    {

                        // Ввод первой валюты

                        while (isCurrencyNameInvalid)
                        {
                            Console.WriteLine(
                                $"Print index of the currency you want to convert from. \n" +
                                $"Available currencies:\n" +
                                $"1. {GoldCurrencyName},\n" +
                                $"2. {DiamondsCurrencyName},\n" +
                                $"3. {EmeraldsCurrencyName}.");

                            string currencyIndexInput = Console.ReadLine();

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
                                isCurrencyNameInvalid = false;
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

                        int maxGoldCount = 0;
                        int maxDiamondsCount = 0;
                        int maxEmeraldsCount = 0;

                        switch (currencyToConvertFrom)
                        {
                            case GoldCurrencyName:
                                maxEmeraldsCount = (int)(gold / EmeraldsPriceInGold);
                                maxDiamondsCount = (int)(gold / DiamondsPriceInGold);

                                break;
                            case DiamondsCurrencyName:
                                maxGoldCount = (int)(diamonds / GoldPriceInDiamonds);
                                maxEmeraldsCount = (int)(diamonds / EmeraldsPriceInDiamonds);

                                break;
                            case EmeraldsCurrencyName:
                                maxGoldCount = (int)(emeralds / GoldPriceInEmeralds);
                                maxDiamondsCount = (int)(emeralds / DiamondsPriceInEmeralds);

                                break;
                        }

                        isCurrencyNameInvalid = true;

                        while (isCurrencyNameInvalid)
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
                                    isCurrencyNameInvalid = false;
                                }
                            }

                            if (isCurrencyNameInvalid)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nI don't understand you. Try again, please.\n");
                                Console.ResetColor();
                            }
                        }

                        bool isCurrencyCountInvalid = true;
                        int targetCurrencyCount = 0;

                        while (isCurrencyCountInvalid)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(
                                $"\nYou can get no more than\n" +
                                $"{maxGoldCount} {GoldCurrencyName}" +
                                $"{maxDiamondsCount} {DiamondsCurrencyName}\n" +
                                $"{maxEmeraldsCount} {EmeraldsCurrencyName}\n");
                            Console.ResetColor();

                            Console.WriteLine(
                                $"Print the count of " +
                                $"{currencyToConvertTo} you want to receive.");

                            string currencyCountInput = Console.ReadLine();

                            if (Int32.TryParse(currencyCountInput, out targetCurrencyCount)
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

                        if (currencyToConvertFrom == GoldCurrencyName)
                        {
                            if (currencyToConvertTo == EmeraldsCurrencyName)
                            {
                                int price = (int)(targetCurrencyCount * EmeraldsPriceInGold);

                            }
                            else if (currencyToConvertTo == DiamondsCurrencyName)
                            {

                            }
                        }
                        else if (currencyToConvertFrom == EmeraldsCurrencyName)
                        {
                            if (currencyToConvertTo == GoldCurrencyName)
                            {

                            }
                            else if (currencyToConvertTo == DiamondsCurrencyName)
                            {

                            }
                        }
                        else if (currencyToConvertFrom == DiamondsCurrencyName)
                        {
                            if (currencyToConvertTo == EmeraldsCurrencyName)
                            {

                            }
                            else if (currencyToConvertTo == GoldCurrencyName)
                            {

                            }
                        }
                    }
                }
                else
                {
                    isWorking = false;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("power off");
        }
    }
}
