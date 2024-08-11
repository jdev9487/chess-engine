namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Cases;

using Board;

public static class Queen
{
    public static readonly IntrinsicTestModel NotOnBorder = new()
        {
            StartingLocation = Square.At(File.D, Rank.Four),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.A, Rank.Four),
                Square.At(File.B, Rank.Four),
                Square.At(File.C, Rank.Four),
                Square.At(File.E, Rank.Four),
                Square.At(File.F, Rank.Four),
                Square.At(File.G, Rank.Four),
                Square.At(File.H, Rank.Four),
                Square.At(File.D, Rank.One),
                Square.At(File.D, Rank.Two),
                Square.At(File.D, Rank.Three),
                Square.At(File.D, Rank.Five),
                Square.At(File.D, Rank.Six),
                Square.At(File.D, Rank.Seven),
                Square.At(File.D, Rank.Eight),
                Square.At(File.A, Rank.One),
                Square.At(File.B, Rank.Two),
                Square.At(File.C, Rank.Three),
                Square.At(File.E, Rank.Five),
                Square.At(File.F, Rank.Six),
                Square.At(File.G, Rank.Seven),
                Square.At(File.H, Rank.Eight),
                Square.At(File.A, Rank.Seven),
                Square.At(File.B, Rank.Six),
                Square.At(File.C, Rank.Five),
                Square.At(File.E, Rank.Three),
                Square.At(File.F, Rank.Two),
                Square.At(File.G, Rank.One)
            ]
        };
}