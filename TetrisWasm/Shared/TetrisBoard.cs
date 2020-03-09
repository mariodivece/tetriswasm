namespace TetrisWasm.Shared
{
    public class TetrisBoard
    {
        private readonly TetrisBoardCell[,] m_Cells;

        public TetrisBoard()
        {
            m_Cells = new TetrisBoardCell[Width, Height];
            for (var rowIndex = 0; rowIndex < Height; rowIndex++)
            {
                for (var colIndex = 0; colIndex < Width; colIndex++)
                {
                    m_Cells[colIndex, rowIndex] = new TetrisBoardCell(rowIndex, colIndex);
                }
            }
        }

        public TetrisBoardCell this[int x, int y] => m_Cells[x, y];

        public int Width { get; } = 10;

        public int Height { get; } = 20;

        public TetrisBoardState State { get; private set; }

        public TetrisPiece CurrentPiece { get; private set; }

        public TetrisPiece NextPiece { get; private set; }

        public int Score { get; private set; }

        public void Reset()
        {
            State = TetrisBoardState.Paused;
            CurrentPiece = null;
            NextPiece = null;
            Score = 0;

            for (var rowIndex = 0; rowIndex < Height; rowIndex++)
            {
                for (var colIndex = 0; colIndex < Width; colIndex++)
                {
                    m_Cells[colIndex, rowIndex].State = TetrisFillState.Empty;
                }
            }
        }

        public void Tick()
        {
        }
    }
}
