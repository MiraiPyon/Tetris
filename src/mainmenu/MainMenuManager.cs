using Raylib_cs;

namespace Tetris
{
    public static class MainMenuManager
    {
        public static Texture2D MenuBackground { get; private set; }

        public static void LoadAll()
        {
            MenuBackground = Raylib.LoadTexture("assets/background/color.png");
        }

        public static void UnloadAll()
        {
            Raylib.UnloadTexture(MenuBackground);
        }
    }
}
