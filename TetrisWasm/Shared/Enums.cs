namespace TetrisWasm.Shared
{
    public enum TetrisPieceKind
    {
        I,
        J,
        L,
        O,
        S,
        T,
        Z,
    }

    public enum TetrisPieceRotation
    {
        Left,
        Right,
        Top,
        Bottom
    }

    public enum TetrisFillState
    {
        Empty,
        Red,
        Green,
        Yellow,
        Blue
    }

    public enum TetrisBoardState
    {
        Paused,
        Running,
    }
}
