namespace OOP.Task3
{
    internal class Program
    {
        private const string ExitCommand = "Exit";
        private const string AddPlayerCommand = "A";
        private const string RemovePlayerCommand = "R";
        private const string BanPlayerCommand = "B";
        private const string PardonPlayerCommand = "P";
        private const string ShowAllPlayersCommand = "S";

        public static void Main(string[] args)
        {
            DataBase dataBase = new();

            Menu menu = new(
                headerText: "Main menu:",
                headerColor: ConsoleColor.Magenta,
                actionsColor: ConsoleColor.Yellow);

            var exitAction = new ExitAction(menu, ExitCommand, description: "Exit main menu");
            var addPlayerAction = new AddPlayerAction(dataBase, AddPlayerCommand, description: "Add a new player");

            var removePlayerAction = new PlayerActionByUid(
                dataBase,
                RemovePlayerCommand,
                description: "Remove player",
                action: dataBase.RemovePlayerByUid);

           var banPlayerAction = new PlayerActionByUid(
                dataBase,
                BanPlayerCommand,
                description: "Ban player",
                action: dataBase.BanPlayerByUid);

            var pardonPlayerAction = new PlayerActionByUid(
                dataBase,
                PardonPlayerCommand,
                description: "Pardon player",
                action: dataBase.PardonPlayerByUid);

            var showPlayersAction = new PrintAllPlayersAction(dataBase, ShowAllPlayersCommand, "Show all players");

            menu.AddAction(addPlayerAction);
            menu.AddAction(removePlayerAction);
            menu.AddAction(banPlayerAction);
            menu.AddAction(pardonPlayerAction);
            menu.AddAction(showPlayersAction);
            menu.AddAction(exitAction);

            menu.Enter();
        }
    }

    internal class RuntimeUid
    {
        private static int _lastProvidedUid = 0;

        public static int NewUid()
        {
            return _lastProvidedUid++;
        }
    }

    internal class Player
    {
        public Player(string nickName, int level)
        {
            Uid = RuntimeUid.NewUid();
            IsBanned = false;
            NickName = nickName;
            Level = level;
        }

        public override string ToString()
        {
            return $"\"{nameof(Uid)}\" : {Uid}, ";
        }

        public int Uid { get; private set; }

        public bool IsBanned { get; private set; }

        public string NickName { get; private set; }

        public int Level { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Pardon()
        {
            IsBanned = false;
        }
    }

    internal class DataBase
    {
        private Dictionary<int, Player> _storage;

        public DataBase()
        {
            _storage = new Dictionary<int, Player>();
        }

        public IReadOnlyCollection<Player> AllPlayers => _storage.Values;

        public bool ContainsPlayer(int uid)
        {
            return _storage.ContainsKey(uid);
        }

        public void AddPlayer(Player newPlayer)
        {
            _storage.Add(newPlayer.Uid, newPlayer);
        }

        public void RemovePlayerByUid(int uid)
        {
            _storage.Remove(uid);
        }

        public void BanPlayerByUid(int uid)
        {
            if (_storage.ContainsKey(uid))
            {
                _storage[uid].Ban();
            }
        }

        public void PardonPlayerByUid(int uid)
        {
            if (_storage.ContainsKey(uid))
            {
                _storage[uid].Pardon();
            }
        }
    }

    internal class Menu
    {
        private Dictionary<string, AMenuAction> _menuActions;

        public Menu(string headerText, ConsoleColor headerColor, ConsoleColor actionsColor)
        {
            HeaderText = headerText;

            HeaderColor = headerColor;
            ActionsColor = actionsColor;

            _menuActions = new Dictionary<string, AMenuAction>();
        }

        public string HeaderText { get; private set; }

        public ConsoleColor HeaderColor { get; private set; }
        public ConsoleColor ActionsColor { get; private set; }

        public bool IsRunning { get; private set; }

        public void AddAction(AMenuAction action)
        {
            string formattedCommand = FormatCommand(action.Command);

            _menuActions.Add(formattedCommand, action);
        }

        public void Enter()
        {
            IsRunning = true;

            while(IsRunning)
            {
                Draw();
                ProcessInput();
            }
        }

        public void Exit()
        {
            IsRunning = false;
        }

        private void Draw()
        {
            ConsoleColor previousTextColor = Console.ForegroundColor;

            Console.ForegroundColor = HeaderColor;

            Console.WriteLine(HeaderText);

            Console.ForegroundColor = ActionsColor;

            foreach(AMenuAction action in _menuActions.Values)
            {
                Console.WriteLine($"{action.Command} : {action.Description}");
            }

            Console.ForegroundColor = previousTextColor;
        }

        private void ProcessInput()
        {
            string command = Console.ReadLine() ?? string.Empty;

            string formattedCommand = FormatCommand(command);

            if (_menuActions.ContainsKey(formattedCommand))
            {
                ExecutionStatus status = _menuActions[formattedCommand].Execute();

                switch (status)
                {
                    case ExecutionStatus.Success:
                        WriteSuccessMessage("SUCCESS");
                        break;
                    case ExecutionStatus.Fail:
                        WriteErrorMessage("FAILED");
                        break;
                    default:
                        WriteErrorMessage($"Unprocessed execution status: {status}");
                        break;
                }
            }
            else
            {
                WriteErrorMessage($"There is no action for the command: {command}");
            }
        }

        private string FormatCommand(string command)
        {
            return command
                .ToLower()
                .TrimStart()
                .TrimEnd();
        }

        private void WriteColoredMessage(ConsoleColor color, string message)
        {
            ConsoleColor previousColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ForegroundColor = previousColor;
        }

        private void WriteErrorMessage(string message)
        {
            WriteColoredMessage(ConsoleColor.Red, message);
        }

        private void WriteSuccessMessage(string message)
        {
            WriteColoredMessage(ConsoleColor.Green, message);
        }
    }

    internal enum ExecutionStatus
    {
        Success,
        Fail
    }

    internal abstract class AMenuAction
    {
        public AMenuAction(string command, string description)
        {
            Command = command;

            Description = description;
        }
        public abstract ExecutionStatus Execute();

        public string Command { get; private set; }

        public string Description { get; private set; }
    }

    internal class AddPlayerAction : AMenuAction
    {
        protected DataBase _dataBase;

        public AddPlayerAction(DataBase dataBase, string command, string description)
            : base(command, description)
        {
            _dataBase = dataBase;
        }

        public override ExecutionStatus Execute()
        {
            Console.WriteLine("Fill Player info.");
            Console.WriteLine("Print NickName:");
            string nickName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Print Level:");
            string levelInput = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(levelInput, out int level))
            {
                Player newPlayer = new(nickName, level);

                _dataBase.AddPlayer(newPlayer);

                return ExecutionStatus.Success;
            }
            else
            {
                return ExecutionStatus.Fail;
            }
        }
    }

    internal class PrintAllPlayersAction : AMenuAction
    {
        protected DataBase _dataBase;

        public PrintAllPlayersAction(DataBase dataBase, string command, string description)
            : base(command, description)
        {
            _dataBase = dataBase;
        }

        public override ExecutionStatus Execute()
        {
            Console.WriteLine("UID == Nickname == Level == IsBanned");
            foreach (Player player in _dataBase.AllPlayers)
            {
                Console.WriteLine($"{player.Uid,4} == {player.NickName} == {player.Level} == {player.IsBanned}");
            }

            return ExecutionStatus.Success;
        }
    }

    internal class ExitAction : AMenuAction
    {
        protected Menu _menu;

        public ExitAction(Menu menu, string command, string description) : base(command, description)
        {
            _menu = menu;
        }

        public override ExecutionStatus Execute()
        {
            _menu.Exit();
            return ExecutionStatus.Success;
        }
    }

    internal class PlayerActionByUid : AMenuAction
    {
        protected DataBase _dataBase;
        protected Action<int> _action;

        public PlayerActionByUid(DataBase dataBase, string command, string description, Action<int> action)
            : base(command, description)
        {
            _dataBase = dataBase;
            _action = action;
        }

        public override ExecutionStatus Execute()
        {
            Console.WriteLine("Print player UID:");
            string uidInput = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(uidInput, out int uid))
            {
                if (_dataBase.ContainsPlayer(uid))
                {
                    _action(uid);
                    return ExecutionStatus.Success;
                }

                return ExecutionStatus.Fail;
            }
            else
            {
                return ExecutionStatus.Fail;
            }
        }
    }
}
