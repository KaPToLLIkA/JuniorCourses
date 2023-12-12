using System;

namespace Functions_Task4
{
    internal class BraveNewWorld
    {
        public static void Main(string[] args)
        {
            char emptyCell = ' ';
            char wallCell = '\u2588';
            char player = '@';

            int height = Console.BufferHeight;
            int width = Console.BufferWidth;

            ConsoleColor mapColor = ConsoleColor.DarkBlue;
            ConsoleColor playerColor = ConsoleColor.Red;

            ConsoleColor backgroundColor = ConsoleColor.Black;

            char[,] map = GenerateRandomMap(height, width, emptyCell, wallCell);
            Tuple<int, int> playerPosition = GetRandomValidPlayerPosition(map, wallCell);

            int playerX = playerPosition.Item1;
            int playerY = playerPosition.Item2;

            bool isGameRunning = true;

            while (isGameRunning)
            {
                Console.Clear();

                DrawMap(map, mapColor, backgroundColor);
                DrawPlayer(playerX, playerY, player, playerColor, backgroundColor);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                int newPlayerX = playerX;
                int newPlayerY = playerY;

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        newPlayerY -= 1;
                        break;

                    case ConsoleKey.DownArrow:
                        newPlayerY += 1;
                        break;

                    case ConsoleKey.RightArrow:
                        newPlayerX += 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        newPlayerX -= 1;
                        break;

                    default:
                        break;
                }

                if (map[newPlayerY, newPlayerX] != wallCell)
                {
                    playerX = newPlayerX;
                    playerY = newPlayerY;
                }
            }
        }

        private static void DrawMap(
            char[,] map,
            ConsoleColor foregroundColor,
            ConsoleColor backgroundColor)
        {
            ConsoleColor curForegroundColor = Console.ForegroundColor;
            ConsoleColor curBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map.GetLength(1); ++j)
                {
                    Console.Write(map[i, j]);
                }
            }

            Console.ForegroundColor = curForegroundColor;
            Console.BackgroundColor = curBackgroundColor;
        }

        private static void DrawPlayer(
            int x,
            int y,
            char player,
            ConsoleColor foregroundColor,
            ConsoleColor backgroundColor)
        {
            ConsoleColor curForegroundColor = Console.ForegroundColor;
            ConsoleColor curBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.SetCursorPosition(x, y);
            Console.Write(player);

            Console.ForegroundColor = curForegroundColor;
            Console.BackgroundColor = curBackgroundColor;
        }

        private static Tuple<int, int> GetRandomValidPlayerPosition(char[,] map, char wallCell)
        {
            Random random = new();

            int minX = 0;
            int maxX = map.GetLength(1);

            int minY = 0;
            int maxY = map.GetLength(0);

            int x = 0;
            int y = 0;

            bool isPositionInvalid = true;

            while (isPositionInvalid)
            {
                x = random.Next(minX, maxX);
                y = random.Next(minY, maxY);

                if (map[y, x] != wallCell)
                {
                    isPositionInvalid = false;
                }
            }

            return new Tuple<int, int>(x, y);
        }

        #region map

        private static char[,] GenerateRandomMap(
            int height,
            int width,
            char emptyCell,
            char wallCell,
            float wallsFillingK = 0.15f)
        {
            char[,] map = new char[height, width];

            FillMapWithEmptiness(map, emptyCell);

            SpawnBorderWalls(map, wallCell);

            SpawnRandomWalls(map, wallCell, wallsFillingK);

            return map;
        }

        private static void FillMapWithEmptiness(char[,] map, char emptyCell)
        {
            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map.GetLength(1); ++j)
                {
                    map[i, j] = emptyCell;
                }
            }
        }

        private static void SpawnBorderWalls(char[,] map, char wallCell)
        {
            int topBorderIndex = 0;
            int bottomBorderIndex = map.GetLength(0) - 1;

            int leftBorderIndex = 0;
            int rightBorderIndex = map.GetLength(1) - 1;

            for (int i = 0; i < map.GetLength(1); ++i)
            {
                map[topBorderIndex, i] = wallCell;
                map[bottomBorderIndex, i] = wallCell;
            }

            int heightExceptTop = 1;
            int heightExceptBottom = map.GetLength(0) - 1;

            for (int i = heightExceptTop; i < heightExceptBottom; ++i)
            {
                map[i, leftBorderIndex] = wallCell;
                map[i, rightBorderIndex] = wallCell;
            }
        }

        private static void SpawnRandomWalls(char[,] map, char wallCell, float wallsFillingK)
        {
            int cellsCount = map.Length;
            int wallCellsCount = (int)Math.Round(cellsCount * wallsFillingK, MidpointRounding.AwayFromZero);

            Random random = new();

            int borderWidth = 1;

            int randomMinX = borderWidth;
            int randomMaxX = map.GetLength(1) - borderWidth;

            int randomMinY = borderWidth;
            int randomMaxY = map.GetLength(0) - borderWidth;

            for (int i = 0; i < wallCellsCount; i++)
            {
                bool isTrySpawning = true;

                while (isTrySpawning)
                {
                    int randomX = random.Next(randomMinX, randomMaxX);
                    int randomY = random.Next(randomMinY, randomMaxY);

                    if (map[randomY, randomX] != wallCell)
                    {
                        map[randomY, randomX] = wallCell;
                        isTrySpawning = false;
                    }
                }
            }
        }

        #endregion
    }
}
