namespace OOP.Task2
{
    internal class Player : IConsoleDrawable
    {
        private char _marker;
        private ConsoleColor _color;

        public Player(int x, int y, char marker, ConsoleColor color)
        {
            X = x;
            Y = y;
            _marker = marker;
            _color = color;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void Draw()
        {
            Console.ForegroundColor = _color;
            Console.CursorLeft = X;
            Console.CursorTop = Y;

            Console.Write(_marker);
        }
    }
}
