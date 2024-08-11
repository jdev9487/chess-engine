namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Cases;

using Models;

public static class King
{
    public static readonly IntrinsicTestModel NotOnBorder = new()
        {
            StartingLocation = Square.At(File.D, Rank.Four),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.C, Rank.Three),
                Square.At(File.C, Rank.Four),
                Square.At(File.C, Rank.Five),
                Square.At(File.D, Rank.Three),
                Square.At(File.D, Rank.Five),
                Square.At(File.E, Rank.Three),
                Square.At(File.E, Rank.Four),
                Square.At(File.E, Rank.Five)
            ]
        };
}