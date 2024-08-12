namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Cases;

using Board;

public static class Knight
{
    public static readonly IntrinsicTestModel InCenter = new()
        {
            StartingLocation = Square.At(File.D, Rank.Four),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.E, Rank.Six),
                Square.At(File.F, Rank.Five),
                Square.At(File.F, Rank.Three),
                Square.At(File.E, Rank.Two),
                Square.At(File.C, Rank.Two),
                Square.At(File.B, Rank.Three),
                Square.At(File.B, Rank.Five),
                Square.At(File.C, Rank.Six)
            ]
        };
    public static readonly IntrinsicTestModel OnG4 = new()
        {
            StartingLocation = Square.At(File.G, Rank.Four),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.H, Rank.Six),
                Square.At(File.H, Rank.Two),
                Square.At(File.F, Rank.Two),
                Square.At(File.E, Rank.Three),
                Square.At(File.E, Rank.Five),
                Square.At(File.F, Rank.Six)
            ]
        };
    public static readonly IntrinsicTestModel OnD7 = new()
        {
            StartingLocation = Square.At(File.D, Rank.Seven),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.F, Rank.Eight),
                Square.At(File.F, Rank.Six),
                Square.At(File.E, Rank.Five),
                Square.At(File.C, Rank.Five),
                Square.At(File.B, Rank.Six),
                Square.At(File.B, Rank.Eight)
            ]
        };
    public static readonly IntrinsicTestModel OnB4 = new()
        {
            StartingLocation = Square.At(File.B, Rank.Four),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.A, Rank.Six),
                Square.At(File.A, Rank.Two),
                Square.At(File.C, Rank.Two),
                Square.At(File.D, Rank.Three),
                Square.At(File.D, Rank.Five),
                Square.At(File.C, Rank.Six)
            ]
        };
    public static readonly IntrinsicTestModel OnD2 = new()
        {
            StartingLocation = Square.At(File.D, Rank.Two),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.F, Rank.One),
                Square.At(File.F, Rank.Three),
                Square.At(File.E, Rank.Four),
                Square.At(File.C, Rank.Four),
                Square.At(File.B, Rank.Three),
                Square.At(File.B, Rank.One)
            ]
        };
    public static readonly IntrinsicTestModel OnG2 = new()
        {
            StartingLocation = Square.At(File.G, Rank.Two),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.H, Rank.Four),
                Square.At(File.E, Rank.One),
                Square.At(File.E, Rank.Three),
                Square.At(File.F, Rank.Four)
            ]
        };
    public static readonly IntrinsicTestModel OnG7 = new()
        {
            StartingLocation = Square.At(File.G, Rank.Seven),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.H, Rank.Five),
                Square.At(File.E, Rank.Eight),
                Square.At(File.E, Rank.Six),
                Square.At(File.F, Rank.Five)
            ]
        };
    public static readonly IntrinsicTestModel OnB7 = new()
        {
            StartingLocation = Square.At(File.B, Rank.Seven),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.A, Rank.Five),
                Square.At(File.D, Rank.Eight),
                Square.At(File.D, Rank.Six),
                Square.At(File.C, Rank.Five)
            ]
        };
    public static readonly IntrinsicTestModel OnB2 = new()
        {
            StartingLocation = Square.At(File.B, Rank.Two),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.A, Rank.Four),
                Square.At(File.D, Rank.One),
                Square.At(File.D, Rank.Three),
                Square.At(File.C, Rank.Four)
            ]
        };
    public static readonly IntrinsicTestModel OnH4 = new()
        {
            StartingLocation = Square.At(File.H, Rank.Four),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.G, Rank.Two),
                Square.At(File.F, Rank.Three),
                Square.At(File.F, Rank.Five),
                Square.At(File.G, Rank.Six)
            ]
        };
    public static readonly IntrinsicTestModel OnA4 = new()
        {
            StartingLocation = Square.At(File.A, Rank.Four),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.B, Rank.Two),
                Square.At(File.C, Rank.Three),
                Square.At(File.C, Rank.Five),
                Square.At(File.B, Rank.Six)
            ]
        };
    public static readonly IntrinsicTestModel OnD1 = new()
        {
            StartingLocation = Square.At(File.D, Rank.One),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.B, Rank.Two),
                Square.At(File.C, Rank.Three),
                Square.At(File.E, Rank.Three),
                Square.At(File.F, Rank.Two)
            ]
        };
    public static readonly IntrinsicTestModel OnD8 = new()
        {
            StartingLocation = Square.At(File.D, Rank.Eight),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.B, Rank.Seven),
                Square.At(File.C, Rank.Six),
                Square.At(File.E, Rank.Six),
                Square.At(File.F, Rank.Seven)
            ]
        };
    public static readonly IntrinsicTestModel OnA1 = new()
        {
            StartingLocation = Square.At(File.A, Rank.One),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.B, Rank.Three),
                Square.At(File.C, Rank.Two)
            ]
        };
    public static readonly IntrinsicTestModel OnA8 = new()
        {
            StartingLocation = Square.At(File.A, Rank.Eight),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.B, Rank.Six),
                Square.At(File.C, Rank.Seven)
            ]
        };
    public static readonly IntrinsicTestModel OnH8 = new()
        {
            StartingLocation = Square.At(File.H, Rank.Eight),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.G, Rank.Six),
                Square.At(File.F, Rank.Seven)
            ]
        };
    public static readonly IntrinsicTestModel OnH1 = new()
        {
            StartingLocation = Square.At(File.H, Rank.One),
            ExpectedIntrinsicLocations =
            [
                Square.At(File.G, Rank.Three),
                Square.At(File.F, Rank.Two)
            ]
        };
}