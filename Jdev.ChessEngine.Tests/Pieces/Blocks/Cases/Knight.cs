namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;
using Models;

public static class Knight
{
    public static readonly BlockTestModelKnight NorthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Six),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Six)
            ]
        };
    public static readonly BlockTestModelKnight EastNorth = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.F, Rank.Five)
            ]
        };
    public static readonly BlockTestModelKnight EastSouth = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.F, Rank.Three)
            ]
        };
    public static readonly BlockTestModelKnight SouthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Two),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Two)
            ]
        };
    public static readonly BlockTestModelKnight SouthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Two),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Two)
            ]
        };
    public static readonly BlockTestModelKnight WestSouth = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.B, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.B, Rank.Three)
            ]
        };
    public static readonly BlockTestModelKnight WestNorth = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.B, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.B, Rank.Five)
            ]
        };
    public static readonly BlockTestModelKnight NorthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Six),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Six)
            ]
        };
    public static readonly BlockTestModelKnight NotAMove = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.G, Rank.Six),
            ExpectedRelocationBlocks =
            [
            ]
        };
}