namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;

public static class Bishop
{
    public static readonly BlockTestModel PositiveDiagonal = new()
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
    public static readonly BlockTestModel NegativeDiagonal = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.F, Rank.Two),
            ExpectedRelocationBlocks =
            [
                Square.At(File.E, Rank.Three),
                Square.At(File.F, Rank.Two)
            ]
        };
    public static readonly BlockTestModel OffDiagonal = new()
        {
            Origin = Square.At(File.D, Rank.Four),
            Destination = Square.At(File.D, Rank.Two),
            ExpectedRelocationBlocks = []
        };
}