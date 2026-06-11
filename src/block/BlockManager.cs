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
        public static Texture2D BlueTile { get; private set; }
        public static Texture2D CyanTile { get; private set; }
        public static Texture2D GreenTile { get; private set; }
        public static Texture2D YellowTile { get; private set; }
        public static Texture2D PinkTile { get; private set; }
        public static Texture2D PurpleTile { get; private set; }
        public static Texture2D RedTile { get; private set; }

        public static void LoadAll()
        {
            BlueTile = Raylib.LoadTexture("assets/blocks/blue_block/blue_block.png");
            CyanTile = Raylib.LoadTexture("assets/blocks/cyan_block/cyan_block.png");
            GreenTile = Raylib.LoadTexture("assets/blocks/green_block/green_block.png");
            YellowTile = Raylib.LoadTexture("assets/blocks/yellow_block/yellow_block.png");
            PinkTile = Raylib.LoadTexture("assets/blocks/pink_block/pink_block.png");
            PurpleTile = Raylib.LoadTexture("assets/blocks/purple_block/purple_block.png");
            RedTile = Raylib.LoadTexture("assets/blocks/red_block/red_block.png");
        }

        public static void UnloadAll()
        {
            Raylib.UnloadTexture(BlueTile);
            Raylib.UnloadTexture(CyanTile);
            Raylib.UnloadTexture(GreenTile);
            Raylib.UnloadTexture(YellowTile);
            Raylib.UnloadTexture(PinkTile);
            Raylib.UnloadTexture(PurpleTile);
            Raylib.UnloadTexture(RedTile);
        }

        public static Texture2D GetTileTexture(BlockColor color)
        {
            return color switch
            {
                BlockColor.Blue => BlueTile,
                BlockColor.Cyan => CyanTile,
                BlockColor.Green => GreenTile,
                BlockColor.Yellow => YellowTile,
                BlockColor.Pink => PinkTile,
                BlockColor.Purple => PurpleTile,
                BlockColor.Red => RedTile,
                _ => throw new System.ArgumentOutOfRangeException(nameof(color), "Invalid tile color.")
            };
        }
    }
}
