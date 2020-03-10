namespace TetrisWasm.Client.Shared
{
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Threading;
    using TetrisWasm.Shared;

    public partial class TetrisBoardView : IDisposable
    {
        private bool IsDisposed;
        private Timer BoardTimer;
        private int m_interval = 600;

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

        [Parameter]
        public int Interval
        {
            get => m_interval;
            set
            {
                m_interval = value <= 100 ? 100 : value >= 1000 ? 1000 : value;
                BoardTimer?.Change(m_interval, m_interval);
            }
        }

        public void Start()
        {
            Board.Start();
            BoardTimer?.Change(Interval, Interval);
        }

        public void Refresh() => StateHasChanged();

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool alsoManaged)
        {
            if (IsDisposed)
                return;

            if (alsoManaged)
            {
                BoardTimer?.Dispose();
                BoardTimer = null;
            }

            IsDisposed = true;
        }
    }
}
