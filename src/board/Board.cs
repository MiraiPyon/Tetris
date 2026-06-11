using System.Numerics;
using Raylib_cs;

namespace Tetris
{
    public static class Board
    {
        const float gridSize = 32f;
        const float miniBoardSize = 192f;
        const float boardWidth = 352f;
        const float boardHeight = 672f;
        public static float boardX = (Program.width - boardWidth) / 2f;
        public static float boardY = (Program.height - boardHeight) / 2f;

        public static void Draw()
        {
            DrawBackground();
            DrawMainBoard();
            DrawGrid();
            DrawMiniBoard();
            DrawPauseButton();
        }

        private static void DrawBackground()
        {
            Texture2D background = BoardManager.Background;

            Raylib.DrawTexturePro(
                background,
                new Rectangle(0f, 0f, background.Width, background.Height),
                new Rectangle(0f, 0f, Program.width, Program.height),
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
                new Rectangle(boardX, boardY, boardWidth, boardHeight),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }

        private static void DrawGrid()
        {
            for (float i = 0; i < 20; ++i)
            {
                for (float j = 0; j < 10; ++j)
                {
                    DrawOneGrid(j * gridSize + boardX + gridSize / 2f, i * gridSize + boardY + gridSize / 2f);
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

        private static void DrawMiniBoard()
        {
            Texture2D miniBoard = BoardManager.MiniBoardTexture;

            Raylib.DrawTexturePro(
                miniBoard,
                new Rectangle(0f, 0f, miniBoard.Width, miniBoard.Height),
                new Rectangle(boardX + boardWidth + Program.width / 32, boardY, miniBoardSize, miniBoardSize),
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
                new Rectangle(Program.width / 64, Program.height / 64, pauseTexture.Width, pauseTexture.Height),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }
    }
}