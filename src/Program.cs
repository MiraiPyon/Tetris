using System;
using Raylib_cs;

namespace Tetris
{
    class Program
    {
        public const int width = 1280;
        public const int height = 720;

        static Block[] LoadRotations(string colorName, string blockLetter)
        {
            Block[] blocks = new Block[4];
            for (int i = 1; i <= 4; i++)
            {
                string path = $"assets/blocks/{colorName}_block/{colorName}_{blockLetter}{i}.png";
                Texture2D tmp = Raylib.LoadTexture(path);

                switch (colorName)
                {
                    case "blue":
                        blocks[i-1] = new BlueBlock(width/2-tmp.Width/2, 0, tmp);
                        break;
                    case "cyan":
                        blocks[i-1] = new CyanBlock(width/2-tmp.Width/2, 0, tmp);
                        break;
                    case "green":
                        blocks[i-1] = new GreenBlock(width/2-tmp.Width/2, 0, tmp);
                        break;
                    case "yellow":
                        blocks[i-1] = new YellowBlock(width/2-tmp.Width/2, 0, tmp);
                        break;
                    case "pink":
                        blocks[i-1] = new PinkBlock(width/2-tmp.Width/2, 0, tmp);
                        break;
                    case "purple":
                        blocks[i-1] = new PurpleBlock(width/2-tmp.Width/2, 0, tmp);
                        break;
                    case "red":
                        blocks[i-1] = new RedBlock(width/2-tmp.Width/2, 0, tmp);
                        break;
                }
            }
            return blocks;
        }

        static void Main(string[] args)
        {
            Raylib.InitWindow(width, height, "Tetris");
            Raylib.SetTargetFPS(60);

            Block[] blueBlocks = new Block[4];
            Block[] cyanBlocks = new Block[4];
            Block[] greenBlocks = new Block[4];
            Block[] yellowBlocks = new Block[4];
            Block[] pinkBlocks = new Block[4];
            Block[] purpleBlocks = new Block[4];
            Block[] redBlocks = new Block[4];

            blueBlocks = LoadRotations("blue", "T");
            cyanBlocks = LoadRotations("cyan", "Z");
            greenBlocks = LoadRotations("green", "l");
            yellowBlocks = LoadRotations("yellow", "S");
            pinkBlocks = LoadRotations("pink", "J");
            purpleBlocks = LoadRotations("purple", "I");
            redBlocks = LoadRotations("red", "O");

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