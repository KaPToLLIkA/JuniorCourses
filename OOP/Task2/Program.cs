namespace OOP.Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SceneDrawer sceneDrawer = new();

            Player player = new(x: 3, y: 10, marker: '@', color: ConsoleColor.DarkYellow);

            sceneDrawer.AddDrawable(player);

            int stepWidth = 1;
            int stepHeight = 1;

            while (true)
            {
                sceneDrawer.DrawScene();

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        player.Y -= stepHeight;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        player.Y += stepHeight;
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        player.X += stepWidth;
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        player.X -= stepWidth;
                        break;
                }

                player.X += Console.BufferWidth;
                player.X %= Console.BufferWidth;

                player.Y += Console.BufferHeight;
                player.Y %= Console.BufferHeight;

                Console.Clear();
            }
        }
    }
}
