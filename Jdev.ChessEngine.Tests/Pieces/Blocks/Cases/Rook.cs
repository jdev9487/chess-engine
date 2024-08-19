namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;
using Models;

public static class Rook
{
    public static readonly BlockTestModelRook North = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Six),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Five),
                Square.At(File.D, Rank.Six)
            ]
        };
    public static readonly BlockTestModelRook East = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.G, Rank.Four),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Four),
                Square.At(File.F, Rank.Four),
                Square.At(File.G, Rank.Four)
            ]
        };
    public static readonly BlockTestModelRook South = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Three)
            ]
        };
    public static readonly BlockTestModelRook West = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.A, Rank.Four),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Four),
                Square.At(File.B, Rank.Four),
                Square.At(File.A, Rank.Four)
            ]
        };
    public static readonly BlockTestModelRook Off = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.A, Rank.Six),
            ExpectedRelocationBlocks = []
        };
}