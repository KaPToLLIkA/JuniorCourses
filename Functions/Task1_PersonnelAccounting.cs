using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Functions_Task1
{
    internal class PersonnelAccounting
    {
        public static void Main(string[] args)
        {
            const string AddAccountCommand = "1";
            const string DeleteAccountCommand = "2";
            const string PrintAllAccountsCommand = "3";
            const string FindAccountByUserNameCommand = "4";

            string exitCommand = "0";

            string[] availableCommands = new string[]
            {
                AddAccountCommand,
                DeleteAccountCommand,
                PrintAllAccountsCommand,
                FindAccountByUserNameCommand,
                exitCommand,
            };

            string[] commandsDescriptions = new string[]
            {
                "Add new account",
                "Delete account by id",
                "Print all accounts",
                "Find account by Last Name",
                "Exit"
            };

            string[] personnelFullNames = new string[] 
            { 
                "Ivanov Ivan Ivanovich",
                "Petrov Vasya Pupkin",
                "Petrov Vitya Who",
                "Kolopuev Igor Nikolaevich"
            };

            string[] personnelPositions = new string[]
            {
                "Team lead",
                "Grandpa",
                "CEO",
                "Lead ingeneer"
            };

            bool isRunning = true;

            while (isRunning)
            {
                PrintMenu(availableCommands, commandsDescriptions);
                
                string recognizedCommand = ProcessCommandsInput(availableCommands);

                switch (recognizedCommand)
                {
                    case AddAccountCommand:
                        AddAccountCommandProcess(ref personnelFullNames, ref personnelPositions);
                        break;

                    case DeleteAccountCommand:
                        DeleteAccountCommandProcess(ref personnelFullNames, ref personnelPositions);
                        break;

                    case PrintAllAccountsCommand:
                        PrintAllAccounts(personnelFullNames, personnelPositions);
                        break;

                    case FindAccountByUserNameCommand:
                        FindCommandProcess(personnelFullNames, personnelPositions);
                        break;
                }

                isRunning = recognizedCommand != exitCommand;
            }
        }

        private static void PrintMenu(string[] availableCommands, string[] commandsDescriptions)
        {
            ConsoleColor currentColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Menu:");

            Console.ForegroundColor = ConsoleColor.Magenta;

            for (int i = 0; i < availableCommands.Length; i++)
            {
                Console.WriteLine($"{availableCommands[i]} : {commandsDescriptions[i]}");
            }

            Console.ForegroundColor = currentColor;
        }

        private static string ProcessCommandsInput(string[] availableCommands)
        {
            bool isCommandInvalid = true;
            string recognizedCommand = string.Empty;

            while (isCommandInvalid)
            {
                Console.WriteLine("Print command:");

                string commandInput = Console.ReadLine();

                string lowerCommandInput = commandInput.ToLower();

                if (availableCommands.Contains(lowerCommandInput))
                {
                    isCommandInvalid = false;
                    recognizedCommand = commandInput;
                }
                else
                {
                    PrintErrorMessage("Error. Try again.");
                }
            }

            return recognizedCommand;
        }

        private static void AddAccountCommandProcess(ref string[] personnelFullNames, ref string[] personnelPositions)
        {
            Console.WriteLine("Print user: Last Name, First Name, Patronymic");

            string fullName = Console.ReadLine() ?? "";

            Console.WriteLine("Print personnel position:");

            string position = Console.ReadLine() ?? "";
           
            personnelFullNames = AddItemToArray(personnelFullNames, fullName);
            personnelPositions = AddItemToArray(personnelPositions, position);
        }

        private static void DeleteAccountCommandProcess(ref string[] personnelFullNames, ref string[] personnelPositions)
        {
            Console.Clear();

            PrintAllAccounts(personnelFullNames, personnelPositions);

            string startMessage = "Print ID of personnel to remove:";
            string onErrorMessage = "Error. Try again.";

            int id = GetIntFromConsoleInput(startMessage, onErrorMessage);

            DeleteAccountById(id, ref personnelFullNames, ref personnelPositions);
        }

        private static void PrintAllAccounts(string[] personnelFullNames, string[] personnelPositions)
        {
            Console.Clear();

            string idTitle = "ID";
            string fullNameTitle = "Full name";
            string positionTitle = "Position";

            char separatorFiller = '=';
            string headerSeparator = new(separatorFiller, Console.BufferWidth);

            Console.WriteLine($"{idTitle,4} : {fullNameTitle} - {positionTitle}");
            Console.WriteLine(headerSeparator);

            for (int i = 0; i < personnelFullNames.Length; ++i)
            {
                Console.WriteLine($"{i,4} : {personnelFullNames[i]} - {personnelPositions[i]}");
            }
        }

        public static void FindCommandProcess(string[] personnelFullNames, string[] personnelPositions)
        {
            Console.Clear();

            int[] foundIds = FindAccountIdsByLastName(personnelFullNames);

            if (foundIds.Length == 0)
            {
                PrintErrorMessage("Account with this FULL NAME does not exist");
            }
            else
            {
                Console.WriteLine("Found accounts:");

                foreach (int foundId in foundIds)
                {
                    Console.WriteLine($"{personnelFullNames[foundId]} - {personnelPositions[foundId]}");
                }
            }
        }

        public static int[] FindAccountIdsByLastName(string[] personnelFullNames)
        {
            int[] foundIds = new int[0];

            Console.WriteLine("Search request building...");
            Console.WriteLine("Print user Last Name");

            string targetLastName = Console.ReadLine();
            string lowerTargetLastName = targetLastName.ToLower();

            int lastNameIndex = 0;
            char fullNameSeparator = ' ';

            for (int i = 0; i < personnelFullNames.Length; ++i)
            {
                string[] fullNameComponents = personnelFullNames[i].Split(fullNameSeparator);
                

                if (fullNameComponents.Length > lastNameIndex)
                {
                    string lowerLastName = fullNameComponents[lastNameIndex].ToLower();

                    if (lowerLastName.Contains(lowerTargetLastName))
                    {
                        foundIds = AddItemToArray(foundIds, i);
                    }
                }
            }

            return foundIds;
        }

        public static void DeleteAccountById(int id, ref string[] personnelFullNames, ref string[] personnelPositions)
        {
            if (id >= 0 && id < personnelFullNames.Length)
            {
                personnelFullNames = RemoveItemFromArray(personnelFullNames, id);
                personnelPositions = RemoveItemFromArray(personnelPositions, id);

                PrintAllAccounts(personnelFullNames, personnelPositions);
            }
            else
            {
                PrintErrorMessage("Requested ID does not exist");
            }
        }
        private static int GetIntFromConsoleInput(string startMessage, string onErrorMessage)
        {
            bool isInputInvalid = true;

            int parsedValue = 0;

            while (isInputInvalid)
            {
                Console.WriteLine(startMessage);

                string input = Console.ReadLine();

                if (int.TryParse(input, out parsedValue))
                {
                    isInputInvalid = false;
                }
                else
                {
                    PrintErrorMessage(onErrorMessage);
                }
            }

            return parsedValue;
        }

        private static void PrintErrorMessage(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ForegroundColor = currentColor;
        }

        #region arrays

        private static T[] AddItemToArray<T>(T[] array, T item)
        {
            T[] newArray = ArrayResize(array, array.Length + 1);
            newArray[newArray.Length - 1] = item;

            return newArray;
        }

        private static T[] RemoveItemFromArray<T>(T[] array, int itemIndex)
        {
            T[] tmpArray = new T[array.Length - 1];

            int leftPartLength = itemIndex;
            int rightPartLength = array.Length - leftPartLength - 1;

            ArrayCopy(array, 0, tmpArray, 0, leftPartLength);
            ArrayCopy(array, itemIndex + 1, tmpArray, itemIndex, rightPartLength);

            return tmpArray;
        }

        private static T[] ArrayResize<T>(T[] array, int newSize)
        {
            T[] newArray = new T[newSize];

            ArrayCopy(array, 0, newArray, 0, array.Length);

            return newArray;
        }

        private static void ArrayCopy<T>(
            T[] source,
            int sourceIndex,
            T[] destination,
            int destinationIndex,
            int length)
        {
            int sourceRightBorder = sourceIndex + length;
            int destinationRightBorder = destinationIndex + length;

            if (sourceRightBorder > source.Length 
                || destinationRightBorder > destination.Length)
            {
                throw new IndexOutOfRangeException(
                    $"Source - border: {sourceRightBorder}, length: {source.Length}" +
                    $"Destination - border: {destinationRightBorder}, length: {destination.Length}");
            }

            for (int i = 0; i < length; ++i)
            {
                destination[destinationIndex++] = source[sourceIndex++];
            }
        }

        #endregion
    }
}
