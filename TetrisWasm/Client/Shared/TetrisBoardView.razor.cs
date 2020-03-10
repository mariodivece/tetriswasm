namespace TetrisWasm.Client.Shared
{
    using System.Threading;
    using TetrisWasm.Shared;

    public partial class TetrisBoardView
    {
        private readonly Timer BoardTimer;

        public TetrisBoardView()
        {
            BoardTimer = new Timer((o) =>
            {
                Board.Tick();
                StateHasChanged();
            });
        }

        public TetrisBoard Board { get; } = new TetrisBoard();

        public void Start()
        {
            Board.Start();
            BoardTimer.Change(600, 600);
        }

        public void MoveLeft() => Board.MoveLeft();

        public void MoveRight() => Board.MoveRight();

        public void MoveDown() => Board.MoveDown();

        public void Rotate() => Board.Rotate();
    }
}
