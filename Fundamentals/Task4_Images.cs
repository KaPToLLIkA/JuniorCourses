namespace Fundamentals_Task4
{
    internal class Images
    {
        public static void Main(string[] args)
        {
            int imagesInRow = 3;
            int albumSize = 52;

            int filledRowsCount = albumSize / imagesInRow;
            int remainingImagesCount = albumSize % imagesInRow;

            Console.WriteLine($"Filled rows count: {filledRowsCount}, remaining images: {remainingImagesCount}");
        }
    }
}
