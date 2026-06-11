using System;
using Raylib_cs;

namespace Tetris
{
    public enum BlockColor
    {
        Blue,
        Cyan,
        Green,
        Yellow,
        Pink,
        Purple,
        Red
    }

    public static class BlockManager
    {
        public static Block[] BlueBlocks { get; private set; } = null!;
        public static Block[] CyanBlocks { get; private set; } = null!;
        public static Block[] GreenBlocks { get; private set; } = null!;
        public static Block[] YellowBlocks { get; private set; } = null!;
        public static Block[] PinkBlocks { get; private set; } = null!;
        public static Block[] PurpleBlocks { get; private set; } = null!;
        public static Block[] RedBlocks { get; private set; } = null!;

        public static void LoadAll()
        {
            BlueBlocks   = LoadRotations(BlockColor.Blue, "T");
            CyanBlocks   = LoadRotations(BlockColor.Cyan, "Z");
            GreenBlocks  = LoadRotations(BlockColor.Green, "l");
            YellowBlocks = LoadRotations(BlockColor.Yellow, "S");
            PinkBlocks   = LoadRotations(BlockColor.Pink, "J");
            PurpleBlocks = LoadRotations(BlockColor.Purple, "I");
            RedBlocks    = LoadRotations(BlockColor.Red, "O");
        }

        public static void UnloadAll()
        {
            UnloadRotations(BlueBlocks);
            UnloadRotations(CyanBlocks);
            UnloadRotations(GreenBlocks);
            UnloadRotations(YellowBlocks);
            UnloadRotations(PinkBlocks);
            UnloadRotations(PurpleBlocks);
            UnloadRotations(RedBlocks);
        }

        private static Block[] LoadRotations(BlockColor color, string blockLetter)
        {
            Block[] blocks = new Block[4];

            string colorStr = color switch
            {
                BlockColor.Blue   => "blue",
                BlockColor.Cyan   => "cyan",
                BlockColor.Green  => "green",
                BlockColor.Yellow => "yellow",
                BlockColor.Pink   => "pink",
                BlockColor.Purple => "purple",
                BlockColor.Red    => "red",
                _ => throw new ArgumentException("Invalid tile color!")
            };

            for (int i = 1; i <= 4; ++i)
            {
                string path = $"assets/blocks/{colorStr}_block/{colorStr}_{blockLetter}{i}.png";
                Texture2D tmp = Raylib.LoadTexture(path);

                int startX = Program.width / 2 - tmp.Width / 2;

                switch (color)
                {
                    case BlockColor.Blue:
                        blocks[i-1] = new BlueBlock(startX, 0, tmp);
                        break;
                    case BlockColor.Cyan:   
                        blocks[i-1] = new CyanBlock(startX, 0, tmp);
                        break;
                    case BlockColor.Green:
                        blocks[i-1] = new GreenBlock(startX, 0, tmp);
                        break;
                    case BlockColor.Yellow:
                        blocks[i-1] = new YellowBlock(startX, 0, tmp);
                        break;
                    case BlockColor.Pink:
                        blocks[i-1] = new PinkBlock(startX, 0, tmp);
                        break;
                    case BlockColor.Purple:
                        blocks[i-1] = new PurpleBlock(startX, 0, tmp);
                        break;
                    case BlockColor.Red:
                        blocks[i-1] = new RedBlock(startX, 0, tmp);
                        break;
                }
            }
            return blocks;
        }

        private static void UnloadRotations(Block[]? blocks)
        {
            if (blocks == null) return;

            foreach (Block block in blocks)
            {
                Raylib.UnloadTexture(block.texture);
            }
        }
    }
}