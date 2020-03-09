namespace TetrisWasm.Shared
{
    public class TetrisPiece
    {
        public TetrisPieceKind Kind { get; private set; }

        public TetrisPieceRotation Rotation { get; private set; }

        public TetrisFillState Color { get; private set; }
    }
}
