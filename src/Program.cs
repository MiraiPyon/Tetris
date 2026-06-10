using System;
using Raylib_cs;

namespace Tetris
{
    class Program
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

        public const int width = 1280;
        public const int height = 720;

        static Block[] LoadRotations(BlockColor color, string blockLetter)
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

                switch (color)
                {
                    case BlockColor.Blue:
                        blocks[i-1] = new BlueBlock(width/2 - tmp.Width/2, 0, tmp);
                        break;
                    case BlockColor.Cyan:
                        blocks[i-1] = new CyanBlock(width/2 - tmp.Width/2, 0, tmp);
                        break;
                    case BlockColor.Green:
                        blocks[i-1] = new GreenBlock(width/2 - tmp.Width/2, 0, tmp);
                        break;
                    case BlockColor.Yellow:
                        blocks[i-1] = new YellowBlock(width/2 - tmp.Width/2, 0, tmp);
                        break;
                    case BlockColor.Pink:
                        blocks[i-1] = new PinkBlock(width/2 - tmp.Width/2, 0, tmp);
                        break;
                    case BlockColor.Purple:
                        blocks[i-1] = new PurpleBlock(width/2 - tmp.Width/2, 0, tmp);
                        break;
                    case BlockColor.Red:
                        blocks[i-1] = new RedBlock(width/2 - tmp.Width/2, 0, tmp);
                        break;
                }
            }
            return blocks;
        }   

        static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, "Tetris");
            Raylib.SetTargetFPS(60);

            Block[] blueBlocks, cyanBlocks, greenBlocks, yellowBlocks, pinkBlocks, purpleBlocks, redBlocks;

            blueBlocks   = LoadRotations(BlockColor.Blue, "T");
            cyanBlocks   = LoadRotations(BlockColor.Cyan, "Z");
            greenBlocks  = LoadRotations(BlockColor.Green, "l");
            yellowBlocks = LoadRotations(BlockColor.Yellow, "S");
            pinkBlocks   = LoadRotations(BlockColor.Pink, "J");
            purpleBlocks = LoadRotations(BlockColor.Purple, "I");
            redBlocks    = LoadRotations(BlockColor.Red, "O");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}