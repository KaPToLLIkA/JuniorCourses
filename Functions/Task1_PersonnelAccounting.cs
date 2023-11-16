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
        private const string AddAccountCommand = "1";
        private const string DeleteAccountCommand = "2";
        private const string PrintAllAccountsCommand = "3";
        private const string FindAccountByUserNameCommand = "4";

        private const string YesCommand = "yes";
        private const string NoCommand = "no";

        public static void Main(string[] args)
        {
            var exitCommand = "0";

            var availableCommands = new string[]
            {
                AddAccountCommand,
                DeleteAccountCommand,
                PrintAllAccountsCommand,
                FindAccountByUserNameCommand,
                exitCommand,
            };

            var commandsDescriptions = new string[]
            {
                "Add new account",
                "Delete account by id",
                "Print all accounts",
                "Find account by user name",
                "Exit"
            };

            var personnelFullNames = new string[] 
            { 
                "Ivanov Ivan Ivanovich",
                "Petrov Vasya Pupkin",
                "Kolopuev Igor Nikolaevich"
            };
            var personnelPositions = new string[]
            {
                "Team lead",
                "CEO",
                "Lead ingeneer"
            };

            var isRunning = true;

            while (isRunning)
            {
                PrintMenu(availableCommands, commandsDescriptions);
                
                string recognizedCommand = ProcessCommandsInput(availableCommands);

                ProcessMenuCommand(recognizedCommand, ref personnelFullNames, ref personnelPositions);

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
            var isCommandInvalid = true;
            var recognizedCommand = string.Empty;

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

        private static void ProcessMenuCommand(string command, ref string[] personnelFullNames, ref string[] personnelPositions)
        {
            switch (command)
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
                    FindCommandProcess(ref personnelFullNames, ref personnelPositions);
                    break;
            }
        }

        private static void AddAccountCommandProcess(ref string[] personnelFullNames, ref string[] personnelPositions)
        {
            Console.WriteLine("Print user: First Name, Last Name, Patronymic");

            string fullName = Console.ReadLine();

            Console.WriteLine("Print personnel position:");

            string position = Console.ReadLine();

            personnelFullNames = ResizeArray(personnelFullNames, personnelFullNames.Length + 1);
            personnelPositions = ResizeArray(personnelPositions, personnelPositions.Length + 1);

            personnelFullNames[personnelFullNames.Length - 1] = fullName;
            personnelPositions[personnelPositions.Length - 1] = position;
        }

        private static void DeleteAccountCommandProcess(ref string[] personnelFullNames, ref string[] personnelPositions)
        {
            Console.Clear();

            PrintAllAccounts(personnelFullNames, personnelPositions);

            var startMessage = "Print ID of personnel to remove:";
            var onErrorMessage = "Error. Try again.";

            int id = GetIntFromConsoleInput(startMessage, onErrorMessage);

            DeleteAccountById(id, ref personnelFullNames, ref personnelPositions);
        }

        private static void PrintAllAccounts(string[] personnelFullNames, string[] personnelPositions)
        {
            Console.Clear();

            var idTitle = "ID";
            var fullNameTitle = "Full name";
            var positionTitle = "Position";

            var separatorFiller = '=';
            var headerSeparator = new string(separatorFiller, Console.BufferWidth);

            Console.WriteLine($"{idTitle,4} : {fullNameTitle} - {positionTitle}");
            Console.WriteLine(headerSeparator);

            for (int i = 0; i < personnelFullNames.Length; ++i)
            {
                Console.WriteLine($"{i,4} : {personnelFullNames[i]} - {personnelPositions[i]}");
            }
        }

        public static void FindCommandProcess(ref string[] personnelFullNames, ref string[] personnelPositions)
        {
            Console.Clear();

            var yesOrNoCommands = new string[]
            {
                YesCommand,
                NoCommand,
            };

            var yesOrNoCommandsDescriptions = new string[]
            {
                "Delete this account",
                "Do nothing"
            };

            int errorValue = -1;
            int foundId = FindAccountIdByFullName(personnelFullNames, personnelPositions);

            if (foundId == errorValue)
            {
                PrintErrorMessage("Account with this FULL NAME does not exist");
            }
            else
            {
                Console.WriteLine("Found account:");
                Console.WriteLine($"{personnelFullNames[foundId]} - {personnelPositions[foundId]}");

                Console.WriteLine("Do you want to delete this account?");

                PrintMenu(yesOrNoCommands, yesOrNoCommandsDescriptions);

                string recognizedCommand = ProcessCommandsInput(yesOrNoCommands);

                if (recognizedCommand == YesCommand)
                {
                    DeleteAccountById(foundId, ref personnelFullNames, ref personnelPositions);
                }
            }
        }

        public static int FindAccountIdByFullName(string[] personnelFullNames, string[] personnelPositions)
        {
            int errorValue = -1;
            int requestedAccountId = errorValue;

            Console.WriteLine("Search request building...");
            Console.WriteLine("Print user: First Name, Last Name, Patronymic");

            string fullName = Console.ReadLine();

            for (int i = 0; i < personnelFullNames.Length; ++i)
            {
                if (personnelFullNames[i].Contains(fullName))
                {
                    requestedAccountId = i;
                    break;
                }
            }

            return requestedAccountId;
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

        private static T[] ResizeArray<T>(T[] array, int newSize)
        {
            Array.Resize(ref array, newSize);
            return array;
        }

        private static T[] RemoveItemFromArray<T>(T[] array, int itemIndex)
        {
            var tmpArray = new T[array.Length - 1];

            int leftPartLength = itemIndex;
            int rightPartLength = array.Length - leftPartLength - 1;

            Array.Copy(array, 0, tmpArray, 0, leftPartLength);
            Array.Copy(array, itemIndex + 1, tmpArray, itemIndex, rightPartLength);

            return tmpArray;
        }

        private static int GetIntFromConsoleInput(string startMessage, string onErrorMessage)
        {
            var isInputInvalid = true;

            int parsedValue = 0;

            while (isInputInvalid)
            {
                Console.WriteLine(startMessage);

                string input = Console.ReadLine();

                if (Int32.TryParse(input, out parsedValue))
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
    }
}
