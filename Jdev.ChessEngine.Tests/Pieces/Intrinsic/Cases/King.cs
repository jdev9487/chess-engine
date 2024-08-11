namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Cases;

using Board;

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
    public static readonly IntrinsicTestModel OnRightBorder = new()
        {
            StartingLocation = Square.At(File.H, Rank.Four),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.G, Rank.Three),
                Square.At(File.G, Rank.Four),
                Square.At(File.G, Rank.Five),
                Square.At(File.H, Rank.Three),
                Square.At(File.H, Rank.Five)
            ]
        };
    public static readonly IntrinsicTestModel OnLeftBorder = new()
        {
            StartingLocation = Square.At(File.A, Rank.Four),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.B, Rank.Three),
                Square.At(File.B, Rank.Four),
                Square.At(File.B, Rank.Five),
                Square.At(File.A, Rank.Three),
                Square.At(File.A, Rank.Five)
            ]
        };
    public static readonly IntrinsicTestModel OnTopBorder = new()
        {
            StartingLocation = Square.At(File.D, Rank.Eight),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.C, Rank.Eight),
                Square.At(File.C, Rank.Seven),
                Square.At(File.D, Rank.Seven),
                Square.At(File.E, Rank.Seven),
                Square.At(File.E, Rank.Eight)
            ]
        };
    public static readonly IntrinsicTestModel OnBottomBorder = new()
        {
            StartingLocation = Square.At(File.D, Rank.One),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.C, Rank.One),
                Square.At(File.C, Rank.Two),
                Square.At(File.D, Rank.Two),
                Square.At(File.E, Rank.Two),
                Square.At(File.E, Rank.One)
            ]
        };
    public static readonly IntrinsicTestModel OnA1 = new()
        {
            StartingLocation = Square.At(File.A, Rank.One),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.A, Rank.Two),
                Square.At(File.B, Rank.Two),
                Square.At(File.B, Rank.One)
            ]
        };
    public static readonly IntrinsicTestModel OnH1 = new()
        {
            StartingLocation = Square.At(File.H, Rank.One),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.H, Rank.Two),
                Square.At(File.G, Rank.Two),
                Square.At(File.G, Rank.One)
            ]
        };
    public static readonly IntrinsicTestModel OnH8 = new()
        {
            StartingLocation = Square.At(File.H, Rank.Eight),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.H, Rank.Seven),
                Square.At(File.G, Rank.Seven),
                Square.At(File.G, Rank.Eight)
            ]
        };
    public static readonly IntrinsicTestModel OnA8 = new()
        {
            StartingLocation = Square.At(File.A, Rank.Eight),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.A, Rank.Seven),
                Square.At(File.B, Rank.Seven),
                Square.At(File.B, Rank.Eight)
            ]
        };
}