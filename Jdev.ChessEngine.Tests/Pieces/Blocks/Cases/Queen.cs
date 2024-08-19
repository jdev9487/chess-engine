namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;
using Models;

public static class Queen
{
    public static readonly BlockTestModelQueen North = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Six),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Five),
                Square.At(File.D, Rank.Six)
            ]
        };
    public static readonly BlockTestModelQueen NorthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.G, Rank.Seven),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Five),
                Square.At(File.F, Rank.Six),
                Square.At(File.G, Rank.Seven)
            ]
        };
    public static readonly BlockTestModelQueen East = new()
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
    public static readonly BlockTestModelQueen SouthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Two),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Three),
                Square.At(File.F, Rank.Two)
            ]
        };
    public static readonly BlockTestModelQueen South = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Three)
            ]
        };
    public static readonly BlockTestModelQueen SouthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.A, Rank.One),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Three),
                Square.At(File.B, Rank.Two),
                Square.At(File.A, Rank.One)
            ]
        };
    public static readonly BlockTestModelQueen West = new()
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
    public static readonly BlockTestModelQueen NorthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Five)
            ]
        };
    public static readonly BlockTestModelQueen Off = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.A, Rank.Six),
            ExpectedRelocationBlocks = []
        };
}