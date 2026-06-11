using System;
using System.Collections.Generic;

namespace Tetris
{
    public sealed class ShuffleBag
    {
        private static readonly Random Random = new Random();
        private readonly List<BlockColor> blocks = new List<BlockColor>();

        public BlockColor Next()
        {
            if (blocks.Count == 0)
            {
                Refill();
            }

            int lastIndex = blocks.Count - 1;
            BlockColor nextColor = blocks[lastIndex];
            blocks.RemoveAt(lastIndex);
            return nextColor;
        }

        public void Reset()
        {
            blocks.Clear();
        }

        private void Refill()
        {
            blocks.Clear();
            blocks.Add(BlockColor.Blue);
            blocks.Add(BlockColor.Cyan);
            blocks.Add(BlockColor.Green);
            blocks.Add(BlockColor.Yellow);
            blocks.Add(BlockColor.Pink);
            blocks.Add(BlockColor.Purple);
            blocks.Add(BlockColor.Red);
            Shuffle(blocks);
        }

        private static void Shuffle<T>(List<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                T temp = list[n];
                list[n] = list[k];
                list[k] = temp;
            }
        }
    }
}
