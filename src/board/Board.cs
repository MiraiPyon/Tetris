using System.Numerics;
using Raylib_cs;

namespace Tetris
{
    public static class Board
    {
        public const int Columns = 10;
        public const int Rows = 20;
        public const float GridSize = 32f;
        public const float MiniBoardSize = 224f;
        public const int NextGridColumns = 5;
        public const int NextGridRows = 5;
        public const float NextGridCellSize = MiniBoardSize / 6f;
        public const float BoardWidth = 352f;
        public const float BoardHeight = 672f;
        public static readonly float BoardX = (Program.WindowWidth - BoardWidth) / 2f;
        public static readonly float BoardY = (Program.WindowHeight - BoardHeight) / 2f;
        public static readonly float PlayfieldX = BoardX + GridSize / 2f;
        public static readonly float PlayfieldY = BoardY + GridSize / 2f;
        public static readonly float MiniBoardX = BoardX + BoardWidth + Program.WindowWidth / 32f;
        public static readonly float MiniBoardY = BoardY;
        public static readonly float NextGridX = MiniBoardX + MiniBoardSize / 12f;
        public static readonly float NextGridY = MiniBoardY + MiniBoardSize / 12f;
        public static Rectangle PauseButtonBounds => new Rectangle(
            Program.WindowWidth / 64f,
            Program.WindowHeight / 64f,
            BoardManager.PauseTexture.Width,
            BoardManager.PauseTexture.Height);

        public static void Draw()
        {
            DrawBackground();
            DrawMainBoard();
            DrawGrid();
            DrawPauseButton();
        }

        private static void DrawBackground()
        {
            Texture2D background = BoardManager.Background;

            Raylib.DrawTexturePro(
                background,
                new Rectangle(0f, 0f, background.Width, background.Height),
                new Rectangle(0f, 0f, Program.WindowWidth, Program.WindowHeight),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }

        private static void DrawMainBoard()
        {
            Texture2D mainBoard = BoardManager.MainBoardTexture;

            Raylib.DrawTexturePro(
                mainBoard,
                new Rectangle(0f, 0f, mainBoard.Width, mainBoard.Height),
                new Rectangle(BoardX, BoardY, BoardWidth, BoardHeight),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }

        private static void DrawGrid()
        {
            for (float i = 0; i < Rows; ++i)
            {
                for (float j = 0; j < Columns; ++j)
                {
                    DrawOneGrid(j * GridSize + PlayfieldX, i * GridSize + PlayfieldY);
                }
            }
        }

        private static void DrawOneGrid(float x, float y)
        {
            Texture2D grid = BoardManager.GridTexture;

            Raylib.DrawTexturePro(
                grid,
                new Rectangle(0f, 0f, grid.Width, grid.Height),
                new Rectangle(x, y, grid.Width, grid.Height),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }

        public static void DrawMiniBoardFrame()
        {
            Texture2D miniBoard = BoardManager.MiniBoardTexture;

            Raylib.DrawTexturePro(
                miniBoard,
                new Rectangle(0f, 0f, miniBoard.Width, miniBoard.Height),
                new Rectangle(MiniBoardX, MiniBoardY, MiniBoardSize, MiniBoardSize),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }

        private static void DrawPauseButton()
        {
            Texture2D pauseTexture = BoardManager.PauseTexture;

            Raylib.DrawTexturePro(
                pauseTexture,
                new Rectangle(0f, 0f, pauseTexture.Width, pauseTexture.Height),
                PauseButtonBounds,
                Vector2.Zero,
                0f,
                Color.WHITE);
        }
    }
}
