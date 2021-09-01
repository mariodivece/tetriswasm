namespace TetrisWasm.Client.Pages
{
    using System;
    using TetrisWasm.Client.Shared;
    using TetrisWasm.Shared;

    public partial class Index
    {
        private readonly TetrisBoard Board = new TetrisBoard();
        private bool HasLostGame;

        public Index()
        {
            // Example of handling regular CLR events.
            // Since state changes occur in a background thread,
            // make sure this component gets notified that properties might
            // need updating.
            Board.ScoredPoints += (s, e) => StateHasChanged();
            Board.GameLost += (s, e) => HasLostGame = true;
        }

        /// <summary>
        /// Gets or sets the board view reference.
        /// This gets automatically injected from the markup.
        /// </summary>
        private TetrisBoardView BoardView { get; set; }

        /// <summary>
        /// Called when keyboard input is received.
        /// We need to refresh the board view because the timer runs on a different,
        /// thread pool thread.
        /// </summary>
        private void OnKeyboardInput() => BoardView?.Refresh();

        private void StartGame()
        {
            HasLostGame = false;
            BoardView?.Start();
            Console.WriteLine("Started Game.");
        }
    }
}
