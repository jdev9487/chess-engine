namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Cases;

using Board;

public static class Bishop
{
    public static readonly IntrinsicTestModel NotOnBorder = new()
        {
            StartingLocation = Square.At(File.D, Rank.Four),
            ExpectedIntrinsicRelocations =
            [
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
    public static readonly IntrinsicTestModel OnBottomBorder = new()
        {
            StartingLocation = Square.At(File.D, Rank.One),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.A, Rank.Four),
                Square.At(File.B, Rank.Three),
                Square.At(File.C, Rank.Two),
                Square.At(File.E, Rank.Two),
                Square.At(File.F, Rank.Three),
                Square.At(File.G, Rank.Four),
                Square.At(File.H, Rank.Five)
            ]
        };
    public static readonly IntrinsicTestModel OnRightBorder = new()
        {
            StartingLocation = Square.At(File.H, Rank.Three),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.F, Rank.One),
                Square.At(File.G, Rank.Two),
                Square.At(File.G, Rank.Four),
                Square.At(File.F, Rank.Five),
                Square.At(File.E, Rank.Six),
                Square.At(File.D, Rank.Seven),
                Square.At(File.C, Rank.Eight)
            ]
        };
    public static readonly IntrinsicTestModel OnTopBorder = new()
        {
            StartingLocation = Square.At(File.D, Rank.Eight),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.A, Rank.Five),
                Square.At(File.B, Rank.Six),
                Square.At(File.C, Rank.Seven),
                Square.At(File.E, Rank.Seven),
                Square.At(File.F, Rank.Six),
                Square.At(File.G, Rank.Five),
                Square.At(File.H, Rank.Four)
            ]
        };
    public static readonly IntrinsicTestModel OnLeftBorder = new()
        {
            StartingLocation = Square.At(File.A, Rank.Three),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.C, Rank.One),
                Square.At(File.B, Rank.Two),
                Square.At(File.B, Rank.Four),
                Square.At(File.C, Rank.Five),
                Square.At(File.D, Rank.Six),
                Square.At(File.E, Rank.Seven),
                Square.At(File.F, Rank.Eight)
            ]
        };
    public static readonly IntrinsicTestModel OnA1 = new()
        {
            StartingLocation = Square.At(File.A, Rank.One),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.B, Rank.Two),
                Square.At(File.C, Rank.Three),
                Square.At(File.D, Rank.Four),
                Square.At(File.E, Rank.Five),
                Square.At(File.F, Rank.Six),
                Square.At(File.G, Rank.Seven),
                Square.At(File.H, Rank.Eight)
            ]
        };
    public static readonly IntrinsicTestModel OnA8 = new()
        {
            StartingLocation = Square.At(File.A, Rank.Eight),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.B, Rank.Seven),
                Square.At(File.C, Rank.Six),
                Square.At(File.D, Rank.Five),
                Square.At(File.E, Rank.Four),
                Square.At(File.F, Rank.Three),
                Square.At(File.G, Rank.Two),
                Square.At(File.H, Rank.One)
            ]
        };
    public static readonly IntrinsicTestModel OnH8 = new()
        {
            StartingLocation = Square.At(File.H, Rank.Eight),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.G, Rank.Seven),
                Square.At(File.F, Rank.Six),
                Square.At(File.E, Rank.Five),
                Square.At(File.D, Rank.Four),
                Square.At(File.C, Rank.Three),
                Square.At(File.B, Rank.Two),
                Square.At(File.A, Rank.One)
            ]
        };
    public static readonly IntrinsicTestModel OnH1 = new()
        {
            StartingLocation = Square.At(File.H, Rank.One),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.G, Rank.Two),
                Square.At(File.F, Rank.Three),
                Square.At(File.E, Rank.Four),
                Square.At(File.D, Rank.Five),
                Square.At(File.C, Rank.Six),
                Square.At(File.B, Rank.Seven),
                Square.At(File.A, Rank.Eight)
            ]
        };
}