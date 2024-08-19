namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;
using Models;

public static class Bishop
{
    public static readonly BlockTestModelBishop NorthEast = new()
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
    public static readonly BlockTestModelBishop SouthEast = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Two),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Three),
                Square.At(File.F, Rank.Two)
            ]
        };
    public static readonly BlockTestModelBishop SouthWest = new()
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
    public static readonly BlockTestModelBishop NorthWest = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.C, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.C, Rank.Five)
            ]
        };
    public static readonly BlockTestModelBishop OffDiagonal = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Two),
            ExpectedRelocationBlocks = []
        };
}