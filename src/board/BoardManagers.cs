using Raylib_cs;

namespace Tetris
{
    public static class BoardManager
    {
        public static Texture2D Background { get; private set; }
        public static Texture2D MainBoardTexture { get; private set; }
        public static Texture2D MiniBoardTexture { get; private set; }
        public static Texture2D PauseTexture { get; private set; }
        public static Texture2D GridTexture { get; private set; }

        public static void LoadAll()
        {
            Background = Raylib.LoadTexture("assets/background/color.png");
            MainBoardTexture = Raylib.LoadTexture("assets/UI/border/border.png");
            MiniBoardTexture = Raylib.LoadTexture("assets/UI/next/next.png");
            PauseTexture = Raylib.LoadTexture("assets/UI/controls/pause.png");
            GridTexture = Raylib.LoadTexture("assets/UI/grid/grid.png");
        }

        public static void UnloadAll()
        {
            Raylib.UnloadTexture(MainBoardTexture);
            Raylib.UnloadTexture(MiniBoardTexture);
            Raylib.UnloadTexture(PauseTexture);
            Raylib.UnloadTexture(GridTexture);
            Raylib.UnloadTexture(Background);
        }
    }
}