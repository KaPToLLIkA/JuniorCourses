namespace OOP.Task2
{
    internal class SceneDrawer
    {
        private List<IConsoleDrawable> _drawables;

        public SceneDrawer()
        {
            _drawables = new List<IConsoleDrawable>();
        }

        public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;

        public void AddDrawable(IConsoleDrawable drawable)
        {
            _drawables.Add(drawable);
        }

        public void DrawScene()
        {
            foreach (IConsoleDrawable drawable in _drawables)
            {
                Console.ForegroundColor = ForegroundColor;
                Console.BackgroundColor = BackgroundColor;

                drawable.Draw();
            }
        }
    }
}
