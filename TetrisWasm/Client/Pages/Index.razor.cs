namespace TetrisWasm.Client.Pages
{
    using TetrisWasm.Client.Shared;
    using TetrisWasm.Shared;

    public partial class Index
    {
        private readonly TetrisBoard Board = new TetrisBoard();
        private TetrisBoardView BoardView;

        private void OnKeyboardInput() => BoardView?.Refresh();
    }
}
