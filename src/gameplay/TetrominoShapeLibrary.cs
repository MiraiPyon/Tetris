using System;
using System.Collections.Generic;

namespace Tetris
{
    public static class TetrominoShapeLibrary
    {
        private static readonly Dictionary<BlockColor, CellOffset[][]> Shapes = new Dictionary<BlockColor, CellOffset[][]>
        {
            {
                BlockColor.Blue,
                new[]
                {
                    new[] { new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(2, 1), new CellOffset(1, 0) },
                    new[] { new CellOffset(1, 0), new CellOffset(1, 1), new CellOffset(1, 2), new CellOffset(2, 1) },
                    new[] { new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(2, 1), new CellOffset(1, 2) },
                    new[] { new CellOffset(1, 0), new CellOffset(1, 1), new CellOffset(1, 2), new CellOffset(0, 1) }
                }
            },
            {
                BlockColor.Cyan,
                new[]
                {
                    new[] { new CellOffset(0, 0), new CellOffset(1, 0), new CellOffset(1, 1), new CellOffset(2, 1) },
                    new[] { new CellOffset(2, 0), new CellOffset(1, 1), new CellOffset(2, 1), new CellOffset(1, 2) },
                    new[] { new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(1, 2), new CellOffset(2, 2) },
                    new[] { new CellOffset(1, 0), new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(0, 2) }
                }
            },
            {
                BlockColor.Green,
                new[]
                {
                    new[] { new CellOffset(2, 0), new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(2, 1) },
                    new[] { new CellOffset(1, 0), new CellOffset(1, 1), new CellOffset(1, 2), new CellOffset(2, 2) },
                    new[] { new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(2, 1), new CellOffset(0, 2) },
                    new[] { new CellOffset(0, 0), new CellOffset(1, 0), new CellOffset(1, 1), new CellOffset(1, 2) }
                }
            },
            {
                BlockColor.Yellow,
                new[]
                {
                    new[] { new CellOffset(1, 0), new CellOffset(2, 0), new CellOffset(0, 1), new CellOffset(1, 1) },
                    new[] { new CellOffset(1, 0), new CellOffset(1, 1), new CellOffset(2, 1), new CellOffset(2, 2) },
                    new[] { new CellOffset(1, 1), new CellOffset(2, 1), new CellOffset(0, 2), new CellOffset(1, 2) },
                    new[] { new CellOffset(0, 0), new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(1, 2) }
                }
            },
            {
                BlockColor.Pink,
                new[]
                {
                    new[] { new CellOffset(0, 0), new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(2, 1) },
                    new[] { new CellOffset(1, 0), new CellOffset(2, 0), new CellOffset(1, 1), new CellOffset(1, 2) },
                    new[] { new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(2, 1), new CellOffset(2, 2) },
                    new[] { new CellOffset(1, 0), new CellOffset(1, 1), new CellOffset(0, 2), new CellOffset(1, 2) }
                }
            },
            {
                BlockColor.Purple,
                new[]
                {
                    new[] { new CellOffset(0, 1), new CellOffset(1, 1), new CellOffset(2, 1), new CellOffset(3, 1) },
                    new[] { new CellOffset(2, 0), new CellOffset(2, 1), new CellOffset(2, 2), new CellOffset(2, 3) },
                    new[] { new CellOffset(0, 2), new CellOffset(1, 2), new CellOffset(2, 2), new CellOffset(3, 2) },
                    new[] { new CellOffset(1, 0), new CellOffset(1, 1), new CellOffset(1, 2), new CellOffset(1, 3) }
                }
            },
            {
                BlockColor.Red,
                new[]
                {
                    new[] { new CellOffset(1, 0), new CellOffset(2, 0), new CellOffset(1, 1), new CellOffset(2, 1) },
                    new[] { new CellOffset(1, 0), new CellOffset(2, 0), new CellOffset(1, 1), new CellOffset(2, 1) },
                    new[] { new CellOffset(1, 0), new CellOffset(2, 0), new CellOffset(1, 1), new CellOffset(2, 1) },
                    new[] { new CellOffset(1, 0), new CellOffset(2, 0), new CellOffset(1, 1), new CellOffset(2, 1) }
                }
            }
        };

        public static CellOffset[][] GetRotations(BlockColor color)
        {
            if (!Shapes.TryGetValue(color, out CellOffset[][]? rotations))
            {
                throw new ArgumentException("Invalid tetromino color.");
            }

            return rotations;
        }
    }
}
