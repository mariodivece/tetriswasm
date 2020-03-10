using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisWasm.Shared
{
    public static class Sprites
    {
        private static readonly Dictionary<TetrisPieceKind, Dictionary<PieceRotation, int[]>> Lookup;

        static Sprites()
        {
            Lookup = new Dictionary<TetrisPieceKind, Dictionary<PieceRotation, int[]>>
            {
                [TetrisPieceKind.I] = new Dictionary<PieceRotation, int[]>(4)
                {
                    { PieceRotation.Left, new[] {
                        1,0,0,0,
                        1,0,0,0,
                        1,0,0,0,
                        1,0,0,0,
                    } },
                    { PieceRotation.Top, new[] {
                        1,1,1,1,
                        0,0,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Right, new[] {
                        1,0,0,0,
                        1,0,0,0,
                        1,0,0,0,
                        1,0,0,0,
                    } },
                    { PieceRotation.Bottom, new[] {
                        1,1,1,1,
                        0,0,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                },
                [TetrisPieceKind.J] = new Dictionary<PieceRotation, int[]>(4)
                {
                    { PieceRotation.Left, new[] {
                        1,0,0,0,
                        1,1,1,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Top, new[] {
                        0,1,0,0,
                        0,1,0,0,
                        1,1,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Right, new[] {
                        1,1,1,0,
                        0,0,1,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Bottom, new[] {
                        1,1,0,0,
                        1,0,0,0,
                        1,0,0,0,
                        0,0,0,0,
                    } },
                },
                [TetrisPieceKind.L] = new Dictionary<PieceRotation, int[]>(4)
                {
                    { PieceRotation.Left, new[] {
                        1,0,0,0,
                        1,0,0,0,
                        1,1,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Top, new[] {
                        0,0,1,0,
                        1,1,1,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Right, new[] {
                        1,1,0,0,
                        0,1,0,0,
                        0,1,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Bottom, new[] {
                        1,1,1,0,
                        1,0,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                },
                [TetrisPieceKind.O] = new Dictionary<PieceRotation, int[]>(4)
                {
                    { PieceRotation.Left, new[] {
                        1,1,0,0,
                        1,1,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Top, new[] {
                        1,1,0,0,
                        1,1,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Right, new[] {
                        1,1,0,0,
                        1,1,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Bottom, new[] {
                        1,1,0,0,
                        1,1,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                },
                [TetrisPieceKind.S] = new Dictionary<PieceRotation, int[]>(4)
                {
                    { PieceRotation.Left, new[] {
                        0,1,1,0,
                        1,1,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Top, new[] {
                        1,0,0,0,
                        1,1,0,0,
                        0,1,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Right, new[] {
                        0,1,1,0,
                        1,1,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Bottom, new[] {
                        1,0,0,0,
                        1,1,0,0,
                        0,1,0,0,
                        0,0,0,0,
                    } },
                },
                [TetrisPieceKind.T] = new Dictionary<PieceRotation, int[]>(4)
                {
                    { PieceRotation.Left, new[] {
                        1,1,1,0,
                        0,1,0,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Top, new[] {
                        0,1,0,0,
                        1,1,0,0,
                        0,1,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Right, new[] {
                        1,0,0,0,
                        1,1,0,0,
                        1,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Bottom, new[] {
                        0,1,0,0,
                        1,1,1,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                },
                [TetrisPieceKind.Z] = new Dictionary<PieceRotation, int[]>(4)
                {
                    { PieceRotation.Left, new[] {
                        1,1,0,0,
                        0,1,1,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Top, new[] {
                        0,1,0,0,
                        1,1,0,0,
                        1,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Right, new[] {
                        1,1,0,0,
                        0,1,1,0,
                        0,0,0,0,
                        0,0,0,0,
                    } },
                    { PieceRotation.Bottom, new[] {
                        0,1,0,0,
                        1,1,0,0,
                        1,0,0,0,
                        0,0,0,0,
                    } },
                }
            };
        }

        private static bool[,] GetSprite(int[] spriteDefinition)
        {
            const int width = 4;
            const int height = 4;

            var result = new bool[width, height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    result[x, y] = spriteDefinition[(y * height) + x] != 0;
                }
            }

            return result;
        }

        public static bool[,] GetSprite(TetrisPieceKind kind, PieceRotation rotation) =>
            GetSprite(Lookup[kind][rotation]);
    }
}
