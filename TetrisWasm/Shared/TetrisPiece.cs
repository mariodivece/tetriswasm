namespace TetrisWasm.Shared
{
    public class TetrisPiece
    {
        public TetrisPiece(TetrisPieceKind kind)
        {
            Kind = kind;
        }

        public TetrisPieceKind Kind { get; private set; }

        public TetrisPieceRotation Rotation { get; set; }

        public TetrisFillState Color { get; set; } = TetrisFillState.Red;

        public int X { get; set; } = 1;

        public int Y { get; set; } = 1;

        public void Draw(TetrisBoard board)
        {
            board[X, Y].State = Color;
            board[X, Y + 1].State = Color;

            board[X + 1, Y].State = Color;
            board[X + 1, Y + 1].State = Color;
        }
    }
}
