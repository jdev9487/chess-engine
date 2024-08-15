namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;

public static class Queen
{
    public static readonly BlockTestModel North = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Six),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Five),
                Square.At(File.D, Rank.Six)
            ]
        };
    public static readonly BlockTestModel NorthEast = new()
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
    public static readonly BlockTestModel East = new()
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
    public static readonly BlockTestModel SouthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Two),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Three),
                Square.At(File.F, Rank.Two)
            ]
        };
    public static readonly BlockTestModel South = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Three)
            ]
        };
    public static readonly BlockTestModel SouthWest = new()
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
    public static readonly BlockTestModel West = new()
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
    public static readonly BlockTestModel NorthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Five)
            ]
        };
    public static readonly BlockTestModel Off = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.A, Rank.Six),
            ExpectedRelocationBlocks = []
        };
}