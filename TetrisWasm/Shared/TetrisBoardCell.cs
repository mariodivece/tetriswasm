namespace TetrisWasm.Shared
{
    public class TetrisBoardCell
    {
        public TetrisBoardCell(int rowIndex, int colIndex)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;
            Fill = TetrisFillState.Empty;
        }

        public int RowIndex { get; }

        public int ColIndex { get; }

        public TetrisFillState Fill { get; private set; }

        public bool IsFixed { get; private set; }

        public bool IsEmpty => Fill == TetrisFillState.Empty;

        public void Reset()
        {
            Fill = TetrisFillState.Empty;
            IsFixed = false;
        }

        public void Fix()
        {
            IsFixed = true;
        }

        public void Set(TetrisFillState color)
        {
            if (!IsFixed)
                Fill = color;
        }

        public void Change(TetrisFillState state, bool isFixed)
        {
            Fill = state;
            IsFixed = isFixed;
        }
    }
}
