namespace OOP.Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Player player = new(id: 1, visibleName: "hr", login: "eee@mail.ru", passwordHash: "ABCCD012");

            player.PrintToStream(Console.Out);

            Console.ReadKey();
        }
    }
}
