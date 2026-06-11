using Raylib_cs;

namespace Tetris
{
    internal static class Program
    {
        public const int width = 1280;
        public const int height = 720;
        public static GameState currentState = GameState.MainMenu;

        private static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, "Tetris");
            Raylib.SetTargetFPS(60);

            LoadEngine.LoadAll();

            while (!Raylib.WindowShouldClose() && currentState != GameState.Exit)
            {
                Game.Update();
                Game.Draw();
            }

            LoadEngine.UnloadAll();
            Raylib.CloseWindow();
        }
    }
}