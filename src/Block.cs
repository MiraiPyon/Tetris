using Raylib_cs;

namespace Tetris
{
    public class Block 
    {
        public Texture2D texture;
        public int x, y;
        public Block(int x, int y, Texture2D texture) 
        {
            this.x = x;
            this.y = y;
            this.texture = texture;
        }
        public void Move(int delta)
        {
            x += delta;
        }
    }

    public class BlueBlock : Block
    {
        public BlueBlock(int x, int y, Texture2D texture) : base(x, y, texture) {}
    }

    public class CyanBlock : Block
    {
        public CyanBlock(int x, int y, Texture2D texture) : base(x, y, texture) {}
    }

    public class GreenBlock : Block
    {
        public GreenBlock(int x, int y, Texture2D texture) : base(x, y, texture) {}
    }

    public class YellowBlock : Block
    {
        public YellowBlock(int x, int y, Texture2D texture) : base(x, y, texture) {}
    }

    public class PinkBlock : Block
    {
        public PinkBlock(int x, int y, Texture2D texture) : base(x, y, texture) {}
    }

    public class PurpleBlock : Block
    {
        public PurpleBlock(int x, int y, Texture2D texture) : base(x, y, texture) {}
    }

    public class RedBlock : Block
    {
        public RedBlock(int x, int y, Texture2D texture) : base(x, y, texture) {}
    }
}
