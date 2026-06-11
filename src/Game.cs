using Raylib_cs;

namespace Tetris
{
    public static class Game
    {
        public static void Update()
        {
            switch (Program.currentState)
            {
                case GameState.MainMenu:
                    MainMenu.Update();
                    break;

                case GameState.Gameplay:
                    break;

                case GameState.GameOver:
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        Program.currentState = GameState.MainMenu;
                    }
                    break;
            }
        }

        public static void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            switch (Program.currentState)
            {
                case GameState.MainMenu:
                    MainMenu.Draw();
                    break;

                case GameState.Gameplay:
                    Board.Draw();
                    break;

                case GameState.GameOver:
                    Raylib.DrawText("GAME OVER!", Program.width / 2 - 120, Program.height / 2 - 50, 50, Color.RED);
                    Raylib.DrawText("PRESS ENTER TO RETURN TO MAIN MENU", Program.width / 2 - 220, Program.height / 2 + 20, 20, Color.WHITE);
                    break;
            }
            Raylib.EndDrawing();
        }
    }
}
