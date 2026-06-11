namespace Tetris
{
    public sealed class Tetromino
    {
        private readonly CellOffset[][] rotations;

        public Tetromino(BlockColor color, CellOffset[][] rotations)
        {
            Color = color;
            this.rotations = rotations;
            ResetSpawnPosition();
        }

        public BlockColor Color { get; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int Rotation { get; set; }
        public CellOffset[] Cells => GetCells(Rotation);

        public void ResetSpawnPosition()
        {
            Column = 3;
            Row = -1;
            Rotation = 0;
        }

        public CellOffset[] GetCells(int rotation)
        {
            return rotations[rotation];
        }
    }
}
