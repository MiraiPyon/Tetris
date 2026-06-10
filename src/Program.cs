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

            BlockManager.LoadAll();
            MainMenuManager.LoadAll();

            while (!Raylib.WindowShouldClose() && currentState != GameState.Exit)
            {
                Update();
                Draw();
            }

            MainMenuManager.UnloadAll();
            BlockManager.UnloadAll();
            Raylib.CloseWindow();
        }

        private static void Update()
        {
            switch (currentState)
            {
                case GameState.MainMenu:
                    MainMenu.Update();
                    break;

                case GameState.Gameplay:
                    break;

                case GameState.GameOver:
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        currentState = GameState.MainMenu;
                    }
                    break;
            }
        }

        private static void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            switch (currentState)
            {
                case GameState.MainMenu:
                    MainMenu.Draw();
                    break;

                case GameState.Gameplay:
                    Raylib.DrawText("GAMEPLAY", 20, 20, 20, Color.GREEN);
                    break;

                case GameState.GameOver:
                    Raylib.DrawText("GAME OVER", width / 2 - 120, height / 2 - 50, 50, Color.RED);
                    Raylib.DrawText("PRESS ENTER TO RETURN TO MAIN MENU", width / 2 - 220, height / 2 + 20, 20, Color.WHITE);
                    break;
            }
            Raylib.EndDrawing();
        }
    }
}
