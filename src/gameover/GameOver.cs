using System.Numerics;
using Raylib_cs;

namespace Tetris
{
    public static class GameOver
    {
        private static readonly Rectangle RestartButton = new Rectangle(
            Program.WindowWidth / 2f - 420f,
            Program.WindowHeight - 115f,
            300f,
            64f);

        private static readonly Rectangle MainMenuButton = new Rectangle(
            Program.WindowWidth / 2f + 120f,
            Program.WindowHeight - 115f,
            360f,
            64f);

        public static void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                AudioManager.PlayClick();
                Restart();
                return;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                AudioManager.PlayClick();
                GameStateManager.ChangeState(GameState.MainMenu);
                return;
            }

            if (!Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                return;
            }

            Vector2 mousePosition = Raylib.GetMousePosition();

            if (Raylib.CheckCollisionPointRec(mousePosition, RestartButton))
            {
                AudioManager.PlayClick();
                Restart();
            }
            else if (Raylib.CheckCollisionPointRec(mousePosition, MainMenuButton))
            {
                AudioManager.PlayClick();
                GameStateManager.ChangeState(GameState.MainMenu);
            }
        }

        public static void Draw()
        {
            Board.Draw();
            GamePlay.Draw();
            UiRenderer.DrawOverlay(185);
            UiRenderer.DrawTitle("GAME OVER", 70, 86);
            UiRenderer.DrawCenteredText($"{GamePlay.Score} POINTS", Program.WindowHeight / 2 - 20, 58, Color.WHITE);
            UiRenderer.DrawTextButton(RestartButton, "RESTART", 40);
            UiRenderer.DrawTextButton(MainMenuButton, "MAIN MENU", 40);
        }

        private static void Restart()
        {
            GamePlay.StartNewGame();
            GameStateManager.ChangeState(GameState.Gameplay);
        }
    }
}
