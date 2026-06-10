using System.Numerics;
using Raylib_cs;

namespace Tetris
{
    public static class MainMenu
    {
        private static readonly Rectangle PlayButton = new Rectangle(
            Program.width / 2f - 100f,
            Program.height / 2f - 20f,
            200f,
            50f);

        private static readonly Rectangle ExitButton = new Rectangle(
            Program.width / 2f - 100f,
            Program.height / 2f + 50f,
            200f,
            50f);

        public static void Update()
        {
            Vector2 mousePosition = Raylib.GetMousePosition();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                Program.currentState = GameState.Gameplay;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                Program.currentState = GameState.Exit;
            }

            if (!Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                return;
            }

            if (Raylib.CheckCollisionPointRec(mousePosition, PlayButton))
            {
                Program.currentState = GameState.Gameplay;
            }
            else if (Raylib.CheckCollisionPointRec(mousePosition, ExitButton))
            {
                Program.currentState = GameState.Exit;
            }
        }

        public static void Draw()
        {
            DrawBackground();
            DrawTitle();
            DrawButton(PlayButton, "PLAY");
            DrawButton(ExitButton, "EXIT");
        }

        private static void DrawBackground()
        {
            Texture2D background = MainMenuManager.MenuBackground;

            Raylib.DrawTexturePro(
                background,
                new Rectangle(0f, 0f, background.Width, background.Height),
                new Rectangle(0f, 0f, Program.width, Program.height),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }

        private static void DrawTitle()
        {
            const string title = "TETRIS GAME";
            const int fontSize = 45;

            int textWidth = Raylib.MeasureText(title, fontSize);
            Raylib.DrawText(title, Program.width / 2 - textWidth / 2, Program.height / 2 - 120, fontSize, Color.WHITE);
        }

        private static void DrawButton(Rectangle button, string label)
        {
            Vector2 mousePosition = Raylib.GetMousePosition();
            bool isHovered = Raylib.CheckCollisionPointRec(mousePosition, button);
            Color buttonColor = isHovered ? Color.LIGHTGRAY : Color.GRAY;

            Raylib.DrawRectangleRec(button, buttonColor);

            const int fontSize = 20;
            int textWidth = Raylib.MeasureText(label, fontSize);
            int textX = (int)(button.X + button.Width / 2f - textWidth / 2f);
            int textY = (int)(button.Y + button.Height / 2f - fontSize / 2f);

            Raylib.DrawText(label, textX, textY, fontSize, Color.BLACK);
        }
    }
}
