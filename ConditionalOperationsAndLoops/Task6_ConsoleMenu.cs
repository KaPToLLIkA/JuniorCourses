using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperationsAndLoops_Task6
{
    internal class ConsoleMenu
    {
        public static void Main(string[] args)
        {
            const string SetColorCommand = "1";
            const string SummValuesCommand = "2";
            const string SubstractValuesCommand = "3";
            const string DivideValuesCommand = "4";
            const string ExitCommand = "0";

            ConsoleColor currentBackgroundColor = Console.ForegroundColor;

            IEnumerable<ConsoleColor> availableColors = Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>();

            bool isRunning = true;

            while (isRunning)
            {
                Console.ForegroundColor = currentBackgroundColor;

                Console.WriteLine(
                    $"Select command:\n" +
                    $"Print \"{SetColorCommand}\" to set console bg color.\n" +
                    $"Print \"{SummValuesCommand}\" to summ values.\n" +
                    $"Print \"{SubstractValuesCommand}\" to substract values.\n" +
                    $"Print \"{DivideValuesCommand}\" to divide values.\n" +
                    $"Print \"{ExitCommand}\" to exit.\n");

                string commandsInput = Console.ReadLine();

                Console.Clear();

                bool isInputInvalid = true;
                float firstValue = 0f;
                float secondValue = 0f;

                switch (commandsInput)
                {
                    case SetColorCommand:
                        
                        Console.WriteLine($"Print color index: ");

                        for (int i = 0; i < availableColors.Count(); i++)
                        {
                            Console.WriteLine($"{i} {availableColors.ElementAt(i)}");
                        }

                        bool isIndexInvalid = true;

                        while (isIndexInvalid)
                        {
                            string indexInput = Console.ReadLine();

                            if (Int32.TryParse(indexInput, out int colorIndex)
                                && colorIndex >= 0
                                && colorIndex < availableColors.Count())
                            {
                                currentBackgroundColor = availableColors.ElementAt(colorIndex);
                                isIndexInvalid = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Input error.\n");
                                Console.ForegroundColor = currentBackgroundColor;
                            }
                        }

                        break;

                    case SummValuesCommand:
                        Console.WriteLine($"Print first value:");

                        isInputInvalid = true;

                        while (isInputInvalid)
                        {
                            string firstValueInput = Console.ReadLine();

                            if (float.TryParse(firstValueInput, out firstValue))
                            {
                                isInputInvalid = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Input error.\n");
                                Console.ForegroundColor = currentBackgroundColor;
                            }
                        }

                        isInputInvalid = true;

                        Console.WriteLine($"Print second value:");

                        while (isInputInvalid)
                        {
                            string secondValueInput = Console.ReadLine();

                            if (float.TryParse(secondValueInput, out secondValue))
                            {
                                isInputInvalid = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Input error.\n");
                                Console.ForegroundColor = currentBackgroundColor;
                            }
                        }

                        float resultOfSumm = firstValue + secondValue;

                        Console.WriteLine($"{firstValue} + {secondValue} = {resultOfSumm}");

                        break;

                    case SubstractValuesCommand:
                        Console.WriteLine($"Print first value:");

                        isInputInvalid = true;

                        while (isInputInvalid)
                        {
                            string firstValueInput = Console.ReadLine();

                            if (float.TryParse(firstValueInput, out firstValue))
                            {
                                isInputInvalid = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Input error.\n");
                                Console.ForegroundColor = currentBackgroundColor;
                            }
                        }

                        isInputInvalid = true;

                        Console.WriteLine($"Print second value:");

                        while (isInputInvalid)
                        {
                            string secondValueInput = Console.ReadLine();

                            if (float.TryParse(secondValueInput, out secondValue))
                            {
                                isInputInvalid = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Input error.\n");
                                Console.ForegroundColor = currentBackgroundColor;
                            }
                        }

                        float resultOfSubstraction = firstValue - secondValue;

                        Console.WriteLine($"{firstValue} - {secondValue} = {resultOfSubstraction}");

                        break;

                    case DivideValuesCommand:
                        Console.WriteLine($"Print first value:");

                        isInputInvalid = true;

                        while (isInputInvalid)
                        {
                            string firstValueInput = Console.ReadLine();

                            if (float.TryParse(firstValueInput, out firstValue))
                            {
                                isInputInvalid = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Input error.\n");
                                Console.ForegroundColor = currentBackgroundColor;
                            }
                        }

                        isInputInvalid = true;

                        Console.WriteLine($"Print second value:");

                        while (isInputInvalid)
                        {
                            string secondValueInput = Console.ReadLine();

                            if (float.TryParse(secondValueInput, out secondValue)
                                && secondValue != 0)
                            {
                                isInputInvalid = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Input error.\n");
                                Console.ForegroundColor = currentBackgroundColor;
                            }
                        }

                        float resultOfDivision = firstValue / secondValue;

                        Console.WriteLine($"{firstValue} / {secondValue} = {resultOfDivision}");

                        break;

                    case ExitCommand:
                        isRunning = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input error.\n");
                        break;
                }

            }
        }
    }
}
