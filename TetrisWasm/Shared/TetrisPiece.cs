namespace TetrisWasm.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TetrisPiece
    {
        private static readonly Random Number = new Random();
        private readonly TetrisBoard Board;
        private bool[,] Sprite;

        private TetrisPiece(TetrisBoard board)
        {
            var maxPieceKind = Enum.GetValues(typeof(TetrisPieceKind)).Cast<int>().Max();
            var maxColor = Enum.GetValues(typeof(TetrisFillState)).Cast<int>().Max();

            Kind = (TetrisPieceKind)Number.Next(0, maxPieceKind + 1);
            Color = (TetrisFillState)Number.Next(1, maxColor + 1);
            Board = board;
            Sprite = new bool[4, 4];

            switch (Kind)
            {
                case TetrisPieceKind.I:
                    {
                        Sprite[0, 0] = true;
                        Sprite[0, 1] = true;
                        Sprite[0, 2] = true;
                        Sprite[0, 3] = true;
                        break;
                    }
                case TetrisPieceKind.J:
                    {
                        Sprite[0, 0] = true;
                        Sprite[0, 1] = true;
                        Sprite[1, 1] = true;
                        Sprite[2, 1] = true;
                        break;
                    }
                case TetrisPieceKind.L:
                    {
                        Sprite[0, 1] = true;
                        Sprite[1, 1] = true;
                        Sprite[2, 1] = true;
                        Sprite[2, 0] = true;
                        break;
                    }
                case TetrisPieceKind.O:
                    {
                        Sprite[0, 0] = true;
                        Sprite[0, 1] = true;
                        Sprite[1, 0] = true;
                        Sprite[1, 1] = true;
                        break;
                    }
                case TetrisPieceKind.S:
                    {
                        Sprite[0, 1] = true;
                        Sprite[1, 0] = true;
                        Sprite[1, 1] = true;
                        Sprite[2, 0] = true;
                        break;
                    }
                case TetrisPieceKind.T:
                    {
                        Sprite[0, 0] = true;
                        Sprite[1, 0] = true;
                        Sprite[1, 1] = true;
                        Sprite[2, 0] = true;
                        break;
                    }
                case TetrisPieceKind.Z:
                    {
                        Sprite[0, 0] = true;
                        Sprite[1, 1] = true;
                        Sprite[1, 0] = true;
                        Sprite[2, 1] = true;
                        break;
                    }
            }
        }

        public TetrisPieceKind Kind { get; private set; }

        public TetrisFillState Color { get; set; } = TetrisFillState.Red;

        public int X { get; private set; }

        public int Y { get; private set; }

        public static TetrisPiece Spawn(TetrisBoard board)
        {
            var piece = new TetrisPiece(board);
            var possibleX = new List<int>(board.Width);

            for (var x = 0; x < board.Width; x++)
            {
                if (TestBounds(board, piece.Sprite, x, 0))
                    possibleX.Add(x);
            }

            // No more space to place items!
            if (possibleX.Count <= 0) return null;

            var selectedX = Number.Next(0, possibleX.Count);
            piece.Move(possibleX[selectedX], 0);
            return piece;
        }

        public bool Move(int deltaX, int deltaY)
        {
            var wantedX = X + deltaX;
            var wantedY = Y + deltaY;

            if (TestBounds(Board, Sprite, wantedX, wantedY))
            {
                X = wantedX;
                Y = wantedY;
                return true;
            }

            return false;
        }

        public bool Rotate()
        {
            var sourceWidth = Sprite.GetLength(0);
            var sourceHeight = Sprite.GetLength(1);
            var targetSprite = new bool[sourceHeight, sourceWidth];

            for (var x = 0; x < sourceWidth; x++)
            {
                for (var y = 0; y < sourceHeight; y++)
                {
                    targetSprite[y, x] = Sprite[x, y];
                }
            }

            if (TestBounds(Board, targetSprite, X, Y))
            {
                Sprite = targetSprite;
                return true;
            }

            return false;
        }

        public void Draw()
        {
            Board.ForEachCell(c =>
            {
                if (!c.IsFixed)
                    c.Set(TetrisFillState.Empty);
            });

            for (var x = 0; x < Sprite.GetLength(0); x++)
            {
                for (var y = 0; y < Sprite.GetLength(1); y++)
                {
                    var boardX = X + x;
                    var boardY = Y + y;

                    if (boardX < 0 || boardX >= Board.Width || boardY < 0 || boardY >= Board.Height)
                        continue;

                    var cell = Board[boardX, boardY];
                    if (Sprite[x, y])
                        cell.Set(Color);
                }
            }
        }

        private static bool TestBounds(TetrisBoard board, bool[,] sprite, int wantedX, int wantedY)
        {
            for (var x = 0; x < sprite.GetLength(0); x++)
            {
                for (var y = 0; y < sprite.GetLength(1); y++)
                {
                    if (!sprite[x, y])
                        continue;

                    var boardX = x + wantedX;
                    var boardY = y + wantedY;

                    if (boardX < 0 || boardX >= board.Width || boardY < 0 || boardY >= board.Height)
                        return false;

                    if (board[boardX, boardY].IsFixed)
                        return false;
                }
            }

            return true;
        }
    }
}
