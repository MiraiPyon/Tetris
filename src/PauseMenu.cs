using System.Numerics;
using Raylib_cs;

namespace Tetris
{
    public static class PauseMenu
    {
        private static readonly Rectangle ContinueButton = new Rectangle(
            Program.WindowWidth / 2f - 190f,
            Program.WindowHeight / 2f - 20f,
            380f,
            58f);

        private static readonly Rectangle MainMenuButton = new Rectangle(
            Program.WindowWidth / 2f - 190f,
            Program.WindowHeight / 2f + 70f,
            380f,
            58f);

        public static void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE) || Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                AudioManager.PlayClick();
                GameStateManager.ChangeState(GameState.Gameplay);
                return;
            }

            if (!Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                return;
            }

            Vector2 mousePosition = Raylib.GetMousePosition();

            if (Raylib.CheckCollisionPointRec(mousePosition, ContinueButton))
            {
                AudioManager.PlayClick();
                GameStateManager.ChangeState(GameState.Gameplay);
            }
            else if (Raylib.CheckCollisionPointRec(mousePosition, MainMenuButton))
            {
                AudioManager.PlayClick();
                GameStateManager.ChangeState(GameState.MainMenu);
            }
        }

        public static void Draw()
        {
            UiRenderer.DrawOverlay(175);
            UiRenderer.DrawTitle("PAUSED", Program.WindowHeight / 2 - 170, 64);
            UiRenderer.DrawTextButton(ContinueButton, "CONTINUE", 34);
            UiRenderer.DrawTextButton(MainMenuButton, "MAIN MENU", 34);
        }
    }
}
