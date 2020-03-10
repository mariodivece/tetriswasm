namespace TetrisWasm.Client.Shared
{
    using Microsoft.AspNetCore.Components;
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

        [CascadingParameter(Name = nameof(Board))]
        public TetrisBoard Board { get; set; }

        public void Start()
        {
            Board.Start();
            BoardTimer.Change(600, 600);
        }

        public void Refresh() => StateHasChanged();
    }
}
