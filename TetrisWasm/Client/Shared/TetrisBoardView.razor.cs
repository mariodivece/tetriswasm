namespace TetrisWasm.Client.Shared
{
    using TetrisWasm.Shared;

    public partial class TetrisBoardView
    {
        public TetrisBoard Board { get; } = new TetrisBoard();

        public void NextState()
        {
            Board[1, 1].State = TetrisFillState.Blue;
        }
    }
}
