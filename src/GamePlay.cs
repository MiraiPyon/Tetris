using System;
using System.Numerics;
using Raylib_cs;

namespace Tetris
{
    public static class GamePlay
    {
        private static readonly BlockColor?[,] Grid = new BlockColor?[Board.Rows, Board.Columns];
        private static readonly ShuffleBag BlockBag = new ShuffleBag();
        private static Tetromino currentPiece = null!;
        private static Tetromino nextPiece = null!;
        private static float fallTimer;
        private static int score;
        private static int lines;
        private static bool isStarted;

        public static int Score => score;
        private static int DifficultyLevel => lines / 10;

        public static void StartNewGame()
        {
            Array.Clear(Grid);
            BlockBag.Reset();
            score = 0;
            lines = 0;
            fallTimer = 0f;
            currentPiece = CreatePiece(GetNextBlockColor());
            nextPiece = CreatePiece(GetNextBlockColor());
            isStarted = true;
        }

        private static BlockColor GetNextBlockColor()
        {
            return BlockBag.Next();
        }

        public static void Update()
        {
            if (!isStarted)
            {
                StartNewGame();
            }

            HandleInput();

            if (!IsGameplayActive())
            {
                return;
            }

            fallTimer += Raylib.GetFrameTime();

            if (fallTimer >= GetFallInterval())
            {
                fallTimer = 0f;
                StepDown();
            }
        }

        public static void Draw()
        {
            DrawLockedBlocks();
            DrawPiece(currentPiece);
            DrawNextPiece();
            DrawScore();
        }

        private static void HandleInput()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                PauseGame();
                return;
            }

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) &&
                Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), Board.PauseButtonBounds))
            {
                PauseGame();
                return;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
            {
                TryMove(-1, 0);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT))
            {
                TryMove(1, 0);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
            {
                StepDown();

                if (!IsGameplayActive())
                {
                    return;
                }
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                fallTimer += Raylib.GetFrameTime() * 12f;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP) || Raylib.IsKeyPressed(KeyboardKey.KEY_X))
            {
                TryRotate(1);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_Z))
            {
                TryRotate(-1);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                HardDrop();
            }
        }

        private static bool IsGameplayActive()
        {
            return GameStateManager.CurrentState == GameState.Gameplay;
        }

        private static void PauseGame()
        {
            AudioManager.PlayClick();
            GameStateManager.ChangeState(GameState.Paused);
        }

        private static float GetFallInterval()
        {
            return MathF.Max(0.1f, 0.65f - DifficultyLevel * 0.05f);
        }

        private static void StepDown()
        {
            if (!TryMove(0, 1))
            {
                LockPiece();
            }
        }

        private static bool TryMove(int deltaColumn, int deltaRow)
        {
            int nextColumn = currentPiece.Column + deltaColumn;
            int nextRow = currentPiece.Row + deltaRow;

            if (!IsValidPosition(currentPiece, nextColumn, nextRow, currentPiece.Rotation))
            {
                return false;
            }

            currentPiece.Column = nextColumn;
            currentPiece.Row = nextRow;
            return true;
        }

        private static void TryRotate(int direction)
        {
            int nextRotation = (currentPiece.Rotation + direction + 4) % 4;
            int[] kicks = { 0, -1, 1, -2, 2 };

            foreach (int kick in kicks)
            {
                if (!IsValidPosition(currentPiece, currentPiece.Column + kick, currentPiece.Row, nextRotation))
                {
                    continue;
                }

                currentPiece.Column += kick;
                currentPiece.Rotation = nextRotation;
                AudioManager.PlayRotation();
                return;
            }
        }

        private static void HardDrop()
        {
            int droppedRows = 0;

            while (TryMove(0, 1))
            {
                droppedRows++;
            }

            score += droppedRows * 2;
            LockPiece();
        }

        private static void LockPiece()
        {
            foreach (CellOffset cell in currentPiece.Cells)
            {
                int column = currentPiece.Column + cell.X;
                int row = currentPiece.Row + cell.Y;

                if (row < 0)
                {
                    EndGame();
                    return;
                }

                Grid[row, column] = currentPiece.Color;
            }

            AudioManager.PlayDrop();
            ClearFullLines();
            SpawnNextPiece();
        }

        private static void SpawnNextPiece()
        {
            currentPiece = nextPiece;
            currentPiece.ResetSpawnPosition();
            nextPiece = CreatePiece(GetNextBlockColor());
            fallTimer = 0f;

            if (!IsValidPosition(currentPiece, currentPiece.Column, currentPiece.Row, currentPiece.Rotation))
            {
                EndGame();
            }
        }

        private static void EndGame()
        {
            GameStateManager.ChangeState(GameState.GameOver);
        }

        private static void ClearFullLines()
        {
            int cleared = 0;

            for (int row = Board.Rows - 1; row >= 0; row--)
            {
                if (!IsRowFull(row))
                {
                    continue;
                }

                ClearRow(row);
                ShiftRowsDown(row);
                cleared++;
                row++;
            }

            if (cleared == 0)
            {
                return;
            }

            lines += cleared;
            score += GetLineClearScore(cleared);
            AudioManager.PlayLineClear(cleared);
        }

        private static int GetLineClearScore(int clearedLines)
        {
            int baseScore = clearedLines switch
            {
                1 => 100,
                2 => 300,
                3 => 500,
                4 => 800,
                _ => clearedLines * 200
            };

            return baseScore * (DifficultyLevel + 1);
        }

        private static bool IsRowFull(int row)
        {
            for (int column = 0; column < Board.Columns; column++)
            {
                if (Grid[row, column] == null)
                {
                    return false;
                }
            }

            return true;
        }

        private static void ClearRow(int row)
        {
            for (int column = 0; column < Board.Columns; column++)
            {
                Grid[row, column] = null;
            }
        }

        private static void ShiftRowsDown(int clearedRow)
        {
            for (int row = clearedRow; row > 0; row--)
            {
                for (int column = 0; column < Board.Columns; column++)
                {
                    Grid[row, column] = Grid[row - 1, column];
                }
            }

            ClearRow(0);
        }

        private static bool IsValidPosition(Tetromino piece, int pieceColumn, int pieceRow, int rotation)
        {
            foreach (CellOffset cell in piece.GetCells(rotation))
            {
                int column = pieceColumn + cell.X;
                int row = pieceRow + cell.Y;

                if (column < 0 || column >= Board.Columns || row >= Board.Rows)
                {
                    return false;
                }

                if (row >= 0 && Grid[row, column] != null)
                {
                    return false;
                }
            }

            return true;
        }

        private static Tetromino CreatePiece(BlockColor color)
        {
            return new Tetromino(color, TetrominoShapeLibrary.GetRotations(color));
        }

        private static void DrawLockedBlocks()
        {
            for (int row = 0; row < Board.Rows; row++)
            {
                for (int column = 0; column < Board.Columns; column++)
                {
                    BlockColor? color = Grid[row, column];

                    if (color != null)
                    {
                        DrawTile(color.Value, column, row);
                    }
                }
            }
        }

        private static void DrawPiece(Tetromino piece)
        {
            foreach (CellOffset cell in piece.Cells)
            {
                int column = piece.Column + cell.X;
                int row = piece.Row + cell.Y;

                if (row >= 0)
                {
                    DrawTile(piece.Color, column, row);
                }
            }
        }

        private static void DrawTile(BlockColor color, int column, int row)
        {
            Texture2D texture = BlockManager.GetTileTexture(color);
            float x = Board.PlayfieldX + column * Board.GridSize;
            float y = Board.PlayfieldY + row * Board.GridSize;

            Raylib.DrawTexturePro(
                texture,
                new Rectangle(0f, 0f, texture.Width, texture.Height),
                new Rectangle(x, y, Board.GridSize, Board.GridSize),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }

        private static void DrawNextPiece()
        {
            DrawNextBoardGrid();

            CellOffset[] cells = nextPiece.GetCells(0);
            GetBounds(cells, out int minX, out int minY, out int maxX, out int maxY);

            int pieceColumns = maxX - minX + 1;
            int pieceRows = maxY - minY + 1;
            int startColumn = (int)MathF.Ceiling((Board.NextGridColumns - pieceColumns) / 2f);
            int startRow = 1 + (int)MathF.Ceiling((Board.NextGridRows - 1 - pieceRows) / 2f);

            foreach (CellOffset cell in cells)
            {
                DrawTileAt(
                    nextPiece.Color,
                    Board.NextGridX + (startColumn + cell.X - minX) * Board.NextGridCellSize,
                    Board.NextGridY + (startRow + cell.Y - minY) * Board.NextGridCellSize,
                    Board.NextGridCellSize);
            }

            Board.DrawMiniBoardFrame();
        }

        private static void DrawNextBoardGrid()
        {
            Texture2D texture = BoardManager.GridTexture;

            for (int row = 0; row < Board.NextGridRows; row++)
            {
                for (int column = 0; column < Board.NextGridColumns; column++)
                {
                    float x = Board.NextGridX + column * Board.NextGridCellSize;
                    float y = Board.NextGridY + row * Board.NextGridCellSize;

                    Raylib.DrawTexturePro(
                        texture,
                        new Rectangle(0f, 0f, texture.Width, texture.Height),
                        new Rectangle(x, y, Board.NextGridCellSize, Board.NextGridCellSize),
                        Vector2.Zero,
                        0f,
                        Color.WHITE);
                }
            }
        }

        private static void DrawTileAt(BlockColor color, float x, float y, float size)
        {
            Texture2D texture = BlockManager.GetTileTexture(color);

            Raylib.DrawTexturePro(
                texture,
                new Rectangle(0f, 0f, texture.Width, texture.Height),
                new Rectangle(x, y, size, size),
                Vector2.Zero,
                0f,
                Color.WHITE);
        }

        private static void DrawScore()
        {
            int centerX = (int)(Board.BoardX / 2f);

            DrawHudTextCentered("SCORE", centerX, (int)(Board.BoardY + 118f), 56);
            DrawHudTextCentered(score.ToString(), centerX, (int)(Board.BoardY + 184f), 80);
        }

        private static void DrawHudTextCentered(string text, int centerX, int y, int fontSize)
        {
            int x = centerX - Raylib.MeasureText(text, fontSize) / 2;

            Raylib.DrawText(text, x + 4, y + 4, fontSize, new Color(0, 0, 0, 95));
            Raylib.DrawText(text, x, y, fontSize, Color.WHITE);
        }

        private static void GetBounds(CellOffset[] cells, out int minX, out int minY, out int maxX, out int maxY)
        {
            minX = cells[0].X;
            minY = cells[0].Y;
            maxX = cells[0].X;
            maxY = cells[0].Y;

            foreach (CellOffset cell in cells)
            {
                minX = Math.Min(minX, cell.X);
                minY = Math.Min(minY, cell.Y);
                maxX = Math.Max(maxX, cell.X);
                maxY = Math.Max(maxY, cell.Y);
            }
        }
    }
}
