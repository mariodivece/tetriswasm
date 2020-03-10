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
