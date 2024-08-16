namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;

public static class King
{
    public static readonly BlockTestModel North = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Five)
            ]
        };
    public static readonly BlockTestModel NorthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Five)
            ]
        };
    public static readonly BlockTestModel East = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Four),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Four)
            ]
        };
    public static readonly BlockTestModel SouthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Three)
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
            Destination = Square.At(File.C, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Three)
            ]
        };
    public static readonly BlockTestModel West = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Four),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Four)
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
    public static readonly BlockTestModel LongerThanOne = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Six),
            ExpectedRelocationBlocks =
            [
            ]
        };
}