using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConditionalOperationsAndLoops_Task5
{
    internal class CurrenciesConverter
    {
        public static void Main(string[] args)
        {
            float DiamondPriceInGold = 10f;
            float EmeraldPriceInDiamonds = 20f;

            float DiamondPriceInEmeralds = 1.0f / EmeraldPriceInDiamonds;
            float EmeraldPriceInGold = EmeraldPriceInDiamonds * DiamondPriceInGold;

            float GoldPriceInDiamonds = 1.0f / DiamondPriceInGold;
            float GoldPriceInEmeralds = 1.0f / EmeraldPriceInGold;

            string GoldCurrencyName = "GOLD";
            string DiamondsCurrencyName = "DIAMONDS";
            string EmeraldsCurrencyName = "EMERALDS";

            const string ExitCommand = "0";

            const string GoldToDiamondsCommand = "1";
            const string GoldToEmeraldsCommand = "2";

            const string DiamondsToGoldCommand = "3";
            const string DiamondsToEmeraldsCommand = "4";

            const string EmeraldsToGoldCommand = "5";
            const string EmeraldsToDiamondsCommand = "6";

            string commandsInput = string.Empty;

            float goldCount = 10000;
            float diamondsCount = 0;
            float emeraldsCount = 0;

            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine(
                    $"Now your balance is: \n" +
                    $"{emeraldsCount} {EmeraldsCurrencyName};\n" +
                    $"{diamondsCount} {DiamondsCurrencyName};\n" +
                    $"{goldCount} {GoldCurrencyName}\n");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(
                    $"\nCurrency exchange rates:\n" +
                    $"1 {DiamondsCurrencyName} = {DiamondPriceInGold} {GoldCurrencyName}\n" +
                    $"1 {EmeraldsCurrencyName} = {EmeraldPriceInGold} {GoldCurrencyName}\n" +
                    $"1 {EmeraldsCurrencyName} = {EmeraldPriceInDiamonds} {DiamondsCurrencyName}");
                Console.ResetColor();

                Console.WriteLine(
                    $"Print index of menu command:\n" +
                    $"1. {GoldCurrencyName} To {DiamondsCurrencyName}\n" +
                    $"2. {GoldCurrencyName} To {EmeraldsCurrencyName}\n" +
                    $"3. {DiamondsCurrencyName} To {GoldCurrencyName}\n" +
                    $"4. {DiamondsCurrencyName} To {EmeraldsCurrencyName}\n" +
                    $"5. {EmeraldsCurrencyName} To {GoldCurrencyName}\n" +
                    $"6. {EmeraldsCurrencyName} To {DiamondsCurrencyName}\n" +
                    $"0. EXIT.");

                commandsInput = Console.ReadLine();

                Console.Clear();

                if (commandsInput != GoldToDiamondsCommand
                    && commandsInput != GoldToEmeraldsCommand
                    && commandsInput != DiamondsToGoldCommand
                    && commandsInput != DiamondsToEmeraldsCommand
                    && commandsInput != EmeraldsToGoldCommand
                    && commandsInput != EmeraldsToDiamondsCommand
                    && commandsInput != ExitCommand)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nI don't understand you. Try again, please.\n");
                    Console.ResetColor();
                } 
                else if (commandsInput == ExitCommand)
                {
                    isWorking = false;
                }
                else
                {
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

                    string conversionTypeCommand = commandsInput;
                    float requiredCurrencyCount = 0;
                    float notEnoughCount = 0;

                    switch (conversionTypeCommand)
                    {
                        case GoldToDiamondsCommand:
                            requiredCurrencyCount = requestedCurrencyCount * DiamondPriceInGold;

                            if (requiredCurrencyCount > goldCount)
                            {
                                notEnoughCount = requiredCurrencyCount - goldCount;

                                Console.WriteLine($"{notEnoughCount} {GoldCurrencyName} was not enough\n");
                            }
                            else
                            {
                                goldCount -= requiredCurrencyCount;
                                diamondsCount += requestedCurrencyCount;
                            }

                            break;

                        case GoldToEmeraldsCommand:
                            requiredCurrencyCount = requestedCurrencyCount * EmeraldPriceInGold;

                            if (requiredCurrencyCount > goldCount)
                            {
                                notEnoughCount = requiredCurrencyCount - goldCount;

                                Console.WriteLine($"{notEnoughCount} {GoldCurrencyName} was not enough\n");
                            }
                            else
                            {
                                goldCount -= requiredCurrencyCount;
                                emeraldsCount += requestedCurrencyCount;
                            }

                            break;

                        case DiamondsToGoldCommand:
                            requiredCurrencyCount = requestedCurrencyCount * GoldPriceInDiamonds;

                            if (requiredCurrencyCount > diamondsCount)
                            {
                                notEnoughCount = requiredCurrencyCount - diamondsCount;

                                Console.WriteLine($"{notEnoughCount} {DiamondsCurrencyName} was not enough\n");
                            }
                            else
                            {
                                diamondsCount -= requiredCurrencyCount;
                                goldCount += requestedCurrencyCount;
                            }

                            break;

                        case DiamondsToEmeraldsCommand:
                            requiredCurrencyCount = requestedCurrencyCount * EmeraldPriceInDiamonds;

                            if (requiredCurrencyCount > diamondsCount)
                            {
                                notEnoughCount = requiredCurrencyCount - diamondsCount;

                                Console.WriteLine($"{notEnoughCount} {DiamondsCurrencyName} was not enough\n");
                            }
                            else
                            {
                                diamondsCount -= requiredCurrencyCount;
                                emeraldsCount += requestedCurrencyCount;
                            }

                            break;

                        case EmeraldsToGoldCommand:
                            requiredCurrencyCount = requestedCurrencyCount * GoldPriceInEmeralds;

                            if (requiredCurrencyCount > emeraldsCount)
                            {
                                notEnoughCount = requiredCurrencyCount - emeraldsCount;

                                Console.WriteLine($"{notEnoughCount} {EmeraldsCurrencyName} was not enough\n");
                            }
                            else
                            {
                                emeraldsCount -= requiredCurrencyCount;
                                goldCount += requestedCurrencyCount;
                            }

                            break;

                        case EmeraldsToDiamondsCommand:
                            requiredCurrencyCount = requestedCurrencyCount * DiamondPriceInEmeralds;

                            if (requiredCurrencyCount > emeraldsCount)
                            {
                                notEnoughCount = requiredCurrencyCount - emeraldsCount;

                                Console.WriteLine($"{notEnoughCount} {EmeraldsCurrencyName} was not enough\n");
                            }
                            else
                            {
                                emeraldsCount -= requiredCurrencyCount;
                                diamondsCount += requestedCurrencyCount;
                            }

                            break;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("power off");
        }
    }
}
