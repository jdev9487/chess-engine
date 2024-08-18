namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;
using Models;

public static class King
{
    public static readonly BlockTestModelKing North = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Five)
            ]
        };
    public static readonly BlockTestModelKing NorthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Five)
            ]
        };
    public static readonly BlockTestModelKing East = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Four),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Four)
            ]
        };
    public static readonly BlockTestModelKing SouthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.E, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Three)
            ]
        };
    public static readonly BlockTestModelKing South = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Three)
            ]
        };
    public static readonly BlockTestModelKing SouthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Three)
            ]
        };
    public static readonly BlockTestModelKing West = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Four),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Four)
            ]
        };
    public static readonly BlockTestModelKing NorthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Five)
            ]
        };
    public static readonly BlockTestModelKing LongerThanOne = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Six),
            ExpectedRelocationBlocks =
            [
            ]
        };
}