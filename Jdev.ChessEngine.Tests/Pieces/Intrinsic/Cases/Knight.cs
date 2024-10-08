namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Cases;

using Board;
using Models;

public static class Knight
{
    public static readonly IntrinsicTestModelKnight InCenter = new()
        {
            StartingLocation = Square.At(File.D, Rank.Four),
            ExpectedIntrinsicRelocations =
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
    public static readonly IntrinsicTestModelKnight OnG4 = new()
        {
            StartingLocation = Square.At(File.G, Rank.Four),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.H, Rank.Six),
                Square.At(File.H, Rank.Two),
                Square.At(File.F, Rank.Two),
                Square.At(File.E, Rank.Three),
                Square.At(File.E, Rank.Five),
                Square.At(File.F, Rank.Six)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnD7 = new()
        {
            StartingLocation = Square.At(File.D, Rank.Seven),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.F, Rank.Eight),
                Square.At(File.F, Rank.Six),
                Square.At(File.E, Rank.Five),
                Square.At(File.C, Rank.Five),
                Square.At(File.B, Rank.Six),
                Square.At(File.B, Rank.Eight)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnB4 = new()
        {
            StartingLocation = Square.At(File.B, Rank.Four),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.A, Rank.Six),
                Square.At(File.A, Rank.Two),
                Square.At(File.C, Rank.Two),
                Square.At(File.D, Rank.Three),
                Square.At(File.D, Rank.Five),
                Square.At(File.C, Rank.Six)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnD2 = new()
        {
            StartingLocation = Square.At(File.D, Rank.Two),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.F, Rank.One),
                Square.At(File.F, Rank.Three),
                Square.At(File.E, Rank.Four),
                Square.At(File.C, Rank.Four),
                Square.At(File.B, Rank.Three),
                Square.At(File.B, Rank.One)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnG2 = new()
        {
            StartingLocation = Square.At(File.G, Rank.Two),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.H, Rank.Four),
                Square.At(File.E, Rank.One),
                Square.At(File.E, Rank.Three),
                Square.At(File.F, Rank.Four)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnG7 = new()
        {
            StartingLocation = Square.At(File.G, Rank.Seven),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.H, Rank.Five),
                Square.At(File.E, Rank.Eight),
                Square.At(File.E, Rank.Six),
                Square.At(File.F, Rank.Five)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnB7 = new()
        {
            StartingLocation = Square.At(File.B, Rank.Seven),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.A, Rank.Five),
                Square.At(File.D, Rank.Eight),
                Square.At(File.D, Rank.Six),
                Square.At(File.C, Rank.Five)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnB2 = new()
        {
            StartingLocation = Square.At(File.B, Rank.Two),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.A, Rank.Four),
                Square.At(File.D, Rank.One),
                Square.At(File.D, Rank.Three),
                Square.At(File.C, Rank.Four)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnH4 = new()
        {
            StartingLocation = Square.At(File.H, Rank.Four),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.G, Rank.Two),
                Square.At(File.F, Rank.Three),
                Square.At(File.F, Rank.Five),
                Square.At(File.G, Rank.Six)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnA4 = new()
        {
            StartingLocation = Square.At(File.A, Rank.Four),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.B, Rank.Two),
                Square.At(File.C, Rank.Three),
                Square.At(File.C, Rank.Five),
                Square.At(File.B, Rank.Six)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnD1 = new()
        {
            StartingLocation = Square.At(File.D, Rank.One),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.B, Rank.Two),
                Square.At(File.C, Rank.Three),
                Square.At(File.E, Rank.Three),
                Square.At(File.F, Rank.Two)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnD8 = new()
        {
            StartingLocation = Square.At(File.D, Rank.Eight),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.B, Rank.Seven),
                Square.At(File.C, Rank.Six),
                Square.At(File.E, Rank.Six),
                Square.At(File.F, Rank.Seven)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnA1 = new()
        {
            StartingLocation = Square.At(File.A, Rank.One),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.B, Rank.Three),
                Square.At(File.C, Rank.Two)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnA8 = new()
        {
            StartingLocation = Square.At(File.A, Rank.Eight),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.B, Rank.Six),
                Square.At(File.C, Rank.Seven)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnH8 = new()
        {
            StartingLocation = Square.At(File.H, Rank.Eight),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.G, Rank.Six),
                Square.At(File.F, Rank.Seven)
            ]
        };
    public static readonly IntrinsicTestModelKnight OnH1 = new()
        {
            StartingLocation = Square.At(File.H, Rank.One),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.G, Rank.Three),
                Square.At(File.F, Rank.Two)
            ]
        };
}