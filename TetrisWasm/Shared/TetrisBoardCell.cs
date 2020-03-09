namespace TetrisWasm.Shared
{
    public class TetrisBoardCell
    {
        public TetrisBoardCell(int rowIndex, int colIndex)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;
            State = TetrisFillState.Empty;
        }

        public int RowIndex { get; }

        public int ColIndex { get; }

        public TetrisFillState State { get; set; }
    }
}
