namespace OOP.Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Player player = new(x: 3, y: 10, marker: '@', color: ConsoleColor.DarkYellow);

            PlayerDrawer drawer = new(player);

            int stepWidth = 1;
            int stepHeight = 1;

            bool isGameRunning = true;

            while (isGameRunning)
            {
                drawer.Draw();

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                int offsetX = 0;
                int offsetY = 0;

                switch (pressedKey.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        offsetY = -stepHeight;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        offsetY = stepHeight;
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        offsetX = stepWidth;
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        offsetX = -stepWidth;
                        break;
                }

                int movingMinX = 0;
                int movingMaxX = Console.BufferWidth - 1;
                int movingMinY = 0;
                int movingMaxY = Console.BufferHeight - 1;

                player.ClampedMove(
                    offsetX,
                    offsetY,
                    movingMinX,
                    movingMaxX,
                    movingMinY,
                    movingMaxY);

                Console.Clear();
            }
        }
    }
}
