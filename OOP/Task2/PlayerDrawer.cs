namespace OOP.Task2
{
    internal class PlayerDrawer
    {
        private Player _player;

        public PlayerDrawer(Player player)
        {
            _player = player;
        }

        public void Draw()
        {
            ConsoleColor currentForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = _player.Color;

            Console.CursorLeft = _player.PositionX;
            Console.CursorTop = _player.PositionY;

            Console.Write(_player.Marker);

            Console.ForegroundColor = currentForegroundColor;
        }
    }
}
