namespace TetrisWasm.Shared
{
    using System;

    public class TetrisBoard
    {
        private readonly TetrisBoardCell[,] m_Cells;

        public event EventHandler ScoredPoints;
        public event EventHandler GameLost;

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

        public int Score { get; private set; }

        public void Start()
        {
            State = TetrisBoardState.Running;
            CurrentPiece = null;
            Score = 0;
            Clear();
            Tick();
        }

        public void Tick()
        {
            if (State != TetrisBoardState.Running)
                return;

            if (CurrentPiece == null)
            {
                SpawnPiece();
                return;
            }

            MoveDown();
        }

        public void MoveLeft() => Move(-1, 0);

        public void MoveRight() => Move(1, 0);

        public void MoveDown() => Move(0, 1);

        public void Rotate()
        {
            if (State != TetrisBoardState.Running)
                return;

            if (CurrentPiece == null || !CurrentPiece.Rotate())
                return;

            CurrentPiece.Draw();
        }

        private void SpawnPiece()
        {
            CurrentPiece = TetrisPiece.Spawn(this);

            if (CurrentPiece == null)
            {
                State = TetrisBoardState.Stopped;
                GameLost?.Invoke(this, EventArgs.Empty);
                return;
            }

            CurrentPiece.Draw();
        }

        private void Move(int deltaX, int deltaY)
        {
            if (State != TetrisBoardState.Running)
                return;

            if (CurrentPiece == null)
                return;

            var didMove = CurrentPiece.Move(deltaX, deltaY);
            if (didMove)
                CurrentPiece.Draw();

            if (!didMove && deltaY > 0)
            {
                // Make the cells filed and apwn a new piece
                ForEachCell(c => { if (!c.IsEmpty) c.Fix(); });

                // Score as many times as possible
                var hasScored = false;
                while (true)
                {
                    var addedScore = TryScore();
                    if (addedScore <= 0)
                        break;

                    hasScored = true;
                    Score += addedScore;
                }

                if (hasScored)
                    ScoredPoints?.Invoke(this, EventArgs.Empty);

                SpawnPiece();
            }
        }

        private int TryScore()
        {
            var score = 0;
            for (var rowIndex = Height - 1; rowIndex >= 0; rowIndex--)
            {
                var isRowFixed = true;
                for (var colIndex = 0; colIndex < Width; colIndex++)
                {
                    var cell = m_Cells[colIndex, rowIndex];
                    if (!cell.IsFixed)
                    {
                        isRowFixed = false;
                        break;
                    }
                }

                if (!isRowFixed)
                    continue;

                score += Width * 15;

                // shift cells down
                for (var targetRowIndex = rowIndex; targetRowIndex >= 0; targetRowIndex--)
                {
                    var sourceRowIndex = targetRowIndex - 1;
                    for (var colIndex = 0; colIndex < Width; colIndex++)
                    {
                        var targetCell = m_Cells[colIndex, targetRowIndex];
                        if (sourceRowIndex < 0)
                        {
                            targetCell.Change(TetrisFillState.Empty, false);
                        }
                        else
                        {
                            var sourceCell = m_Cells[colIndex, sourceRowIndex];
                            targetCell.Change(sourceCell.Fill, sourceCell.IsFixed);
                        }
                    }
                }

                return score;
            }

            return score;
        }

        private void Clear() => ForEachCell(c => c.Reset());

        public void ForEachCell(Action<TetrisBoardCell> cellAction)
        {
            for (var rowIndex = 0; rowIndex < Height; rowIndex++)
            {
                for (var colIndex = 0; colIndex < Width; colIndex++)
                {
                    cellAction(m_Cells[colIndex, rowIndex]);
                }
            }
        }
    }
}
