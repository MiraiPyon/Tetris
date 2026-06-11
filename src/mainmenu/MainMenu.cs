using System.Numerics;
using Raylib_cs;

namespace Tetris
{
    public static class MainMenu
    {
        private static readonly Rectangle PlayButton = new Rectangle(
            Program.WindowWidth / 2f - 190f,
            Program.WindowHeight / 2f - 40f,
            380f,
            58f);

        private static readonly Rectangle SettingsButton = new Rectangle(
            Program.WindowWidth / 2f - 190f,
            Program.WindowHeight / 2f + 48f,
            380f,
            58f);

        private static readonly Rectangle ExitButton = new Rectangle(
            Program.WindowWidth / 2f - 190f,
            Program.WindowHeight / 2f + 136f,
            380f,
            58f);

        public static void Update()
        {
            Vector2 mousePosition = Raylib.GetMousePosition();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                AudioManager.PlayClick();
                StartGame();
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                AudioManager.PlayClick();
                GameStateManager.ChangeState(GameState.Exit);
            }

            if (!Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                return;
            }

            if (Raylib.CheckCollisionPointRec(mousePosition, PlayButton))
            {
                AudioManager.PlayClick();
                StartGame();
            }
            else if (Raylib.CheckCollisionPointRec(mousePosition, SettingsButton))
            {
                AudioManager.PlayClick();
            }
            else if (Raylib.CheckCollisionPointRec(mousePosition, ExitButton))
            {
                AudioManager.PlayClick();
                GameStateManager.ChangeState(GameState.Exit);
            }
        }

        private static void StartGame()
        {
            GamePlay.StartNewGame();
            GameStateManager.ChangeState(GameState.Gameplay);
        }

        public static void Draw()
        {
            DrawBackground();
            UiRenderer.DrawOverlay(70);
            UiRenderer.DrawTitle("TETRIS", 120, 118);
            UiRenderer.DrawTextButton(PlayButton, "PLAY", 40);
            UiRenderer.DrawTextButton(SettingsButton, "SETTINGS", 40);
            UiRenderer.DrawTextButton(ExitButton, "EXIT", 40);
        }

        private static void DrawBackground()
        {
            Texture2D background = MainMenuManager.MenuBackground;

            Raylib.DrawTexturePro(
                background,
                new Rectangle(0f, 0f, background.Width, background.Height),
                new Rectangle(0f, 0f, Program.WindowWidth, Program.WindowHeight),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }
    }
}
