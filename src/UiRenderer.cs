using Raylib_cs;

namespace Tetris
{
    public static class UiRenderer
    {
        public static void DrawOverlay(byte alpha)
        {
            Raylib.DrawRectangle(0, 0, Program.WindowWidth, Program.WindowHeight, new Color((byte)0, (byte)0, (byte)0, alpha));
        }

        public static void DrawCenteredText(string text, int y, int fontSize, Color color)
        {
            int width = Raylib.MeasureText(text, fontSize);
            Raylib.DrawText(text, Program.WindowWidth / 2 - width / 2, y, fontSize, color);
        }

        public static void DrawTitle(string text, int y, int fontSize)
        {
            int width = Raylib.MeasureText(text, fontSize);
            int x = Program.WindowWidth / 2 - width / 2;

            Raylib.DrawText(text, x + 6, y + 8, fontSize, new Color(0, 0, 0, 90));
            Raylib.DrawText(text, x, y, fontSize, new Color(220, 220, 220, 255));
        }

        public static void DrawTextButton(Rectangle button, string label, int fontSize)
        {
            bool isHovered = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button);
            Color color = isHovered ? Color.WHITE : new Color(230, 230, 230, 220);
            int textWidth = Raylib.MeasureText(label, fontSize);
            int textX = (int)(button.X + button.Width / 2f - textWidth / 2f);
            int textY = (int)(button.Y + button.Height / 2f - fontSize / 2f);

            if (isHovered)
            {
                Raylib.DrawRectangleRounded(button, 0.12f, 8, new Color(255, 255, 255, 35));
            }

            Raylib.DrawText(label, textX + 3, textY + 3, fontSize, new Color(0, 0, 0, 85));
            Raylib.DrawText(label, textX, textY, fontSize, color);
        }
    }
}
