namespace Collections_Task4
{
    internal class PersonnelAccounting
    {
        public static void Main(string[] args)
        {
            const string AddAccountCommand = "1";
            const string DeleteAccountCommand = "2";
            const string PrintAllAccountsCommand = "3";

            string exitCommand = "0";

            string[] availableCommands = new string[]
            {
                AddAccountCommand,
                DeleteAccountCommand,
                PrintAllAccountsCommand,
                exitCommand,
            };

            string[] commandsDescriptions = new string[]
            {
                "Add new account",
                "Delete account by id",
                "Print all accounts",
                "Exit"
            };

            List<string> personnelFullNames = new()
            {
                "Ivanov Ivan Ivanovich",
                "Petrov Vasya Pupkin",
                "Petrov Vitya Who",
                "Kolopuev Igor Nikolaevich"
            };

            List<string> personnelPositions = new()
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
                        AddAccount(personnelFullNames, personnelPositions);
                        break;

                    case DeleteAccountCommand:
                        DeleteAccount(personnelFullNames, personnelPositions);
                        break;

                    case PrintAllAccountsCommand:
                        PrintAllAccounts(personnelFullNames, personnelPositions);
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

        private static void AddAccount(List<string> personnelFullNames, List<string> personnelPositions)
        {
            Console.WriteLine("Print user: Last Name, First Name, Patronymic");

            string fullName = Console.ReadLine();

            Console.WriteLine("Print personnel position:");

            string position = Console.ReadLine();

            personnelFullNames.Add(fullName);
            personnelPositions.Add(position);
        }

        private static void DeleteAccount(List<string> personnelFullNames, List<string> personnelPositions)
        {
            Console.Clear();

            PrintAllAccounts(personnelFullNames, personnelPositions);

            string startMessage = "Print ID of personnel to remove:";
            string onErrorMessage = "Error. Try again.";

            int id = GetIntFromConsoleInput(startMessage, onErrorMessage);

            if (id >= 0 && id < personnelFullNames.Count)
            {
                personnelFullNames.RemoveAt(id);
                personnelPositions.RemoveAt(id);

                PrintAllAccounts(personnelFullNames, personnelPositions);
            }
            else
            {
                PrintErrorMessage("Requested ID does not exist");
            }
        }

        private static void PrintAllAccounts(List<string> personnelFullNames, List<string> personnelPositions)
        {
            Console.Clear();

            string idTitle = "ID";
            string fullNameTitle = "Full name";
            string positionTitle = "Position";

            char separatorFiller = '=';
            string headerSeparator = new(separatorFiller, Console.BufferWidth);

            Console.WriteLine($"{idTitle,4} : {fullNameTitle} - {positionTitle}");
            Console.WriteLine(headerSeparator);

            for (int i = 0; i < personnelFullNames.Count; ++i)
            {
                Console.WriteLine($"{i,4} : {personnelFullNames[i]} - {personnelPositions[i]}");
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
    }
}
