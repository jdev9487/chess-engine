namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;

public static class Knight
{
    public static readonly BlockTestModel NorthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Six),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Six)
            ]
        };
    public static readonly BlockTestModel EastNorth = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.F, Rank.Five)
            ]
        };
    public static readonly BlockTestModel EastSouth = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.F, Rank.Three)
            ]
        };
    public static readonly BlockTestModel SouthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Two),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Two)
            ]
        };
    public static readonly BlockTestModel SouthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Two),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Two)
            ]
        };
    public static readonly BlockTestModel WestSouth = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.B, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.B, Rank.Three)
            ]
        };
    public static readonly BlockTestModel WestNorth = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.B, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.B, Rank.Five)
            ]
        };
    public static readonly BlockTestModel NorthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Six),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Six)
            ]
        };
    public static readonly BlockTestModel NotAMove = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.G, Rank.Six),
            ExpectedRelocationBlocks =
            [
            ]
        };
}