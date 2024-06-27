namespace OOP.Task2
{
    internal class Player
    {
        public Player(int x, int y, char marker, ConsoleColor color)
        {
            PositionX = x;
            PositionY = y;
            Marker = marker;
            Color = color;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public char Marker { get; private set; }
        public ConsoleColor Color { get; private set; }

        public void Move(int xOffset, int yOffset)
        {
            PositionX += xOffset;
            PositionY += yOffset;
        }

        public void ClampedMove(int xOffset, int yOffset, int minX, int maxX, int minY, int maxY)
        {
            Move(xOffset, yOffset);

            PositionX = ClampCoordinate(PositionX, minX, maxX);
            PositionY = ClampCoordinate(PositionY, minY, maxY);
        }

        private int ClampCoordinate(int value, int min, int max)
        {
            if (value < min)
            {
                return min;
            }

            if (value > max)
            {
                return max;
            }

            return value;
        }
    }
}
