namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Cases;

using Board;
using Enums;
using Models;

public static class Pawn
{
    public static IntrinsicTestModelPawn OnStartingRankOnAFile(Colour colour) => new()
        {
            StartingLocation = Square.At(File.A, colour == Colour.White ? Rank.Two : Rank.Seven),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.A, colour == Colour.White? Rank.Three : Rank.Six),
                Square.At(File.A, colour == Colour.White? Rank.Four : Rank.Five)
            ],
            ExpectedIntrinsicCaptures =
            [
                Square.At(File.B, colour == Colour.White? Rank.Three : Rank.Six)
            ],
            Colour = colour,
            HasMoved = false
        };
    public static IntrinsicTestModelPawn OnStartingRankOnHFile(Colour colour) => new()
        {
            StartingLocation = Square.At(File.H, colour == Colour.White ? Rank.Two : Rank.Seven),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.H, colour == Colour.White? Rank.Three : Rank.Six),
                Square.At(File.H, colour == Colour.White? Rank.Four : Rank.Five)
            ],
            ExpectedIntrinsicCaptures =
            [
                Square.At(File.G, colour == Colour.White? Rank.Three : Rank.Six)
            ],
            Colour = colour,
            HasMoved = false
        };
    public static IntrinsicTestModelPawn OnStartingRankNotOnEdge(Colour colour) => new()
        {
            StartingLocation = Square.At(File.D, colour == Colour.White ? Rank.Two : Rank.Seven),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.D, colour == Colour.White? Rank.Three : Rank.Six),
                Square.At(File.D, colour == Colour.White? Rank.Four : Rank.Five)
            ],
            ExpectedIntrinsicCaptures =
            [
                Square.At(File.C, colour == Colour.White? Rank.Three : Rank.Six),
                Square.At(File.E, colour == Colour.White? Rank.Three : Rank.Six)
            ],
            Colour = colour,
            HasMoved = false
        };
    public static IntrinsicTestModelPawn NotOnStartingRankOnAFile(Colour colour) => new()
        {
            StartingLocation = Square.At(File.A, Rank.Four),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.A, colour == Colour.White ? Rank.Five : Rank.Three)
            ],
            ExpectedIntrinsicCaptures = 
            [
                Square.At(File.B, colour == Colour.White ? Rank.Five : Rank.Three)
            ],
            Colour = colour
        };
    public static IntrinsicTestModelPawn NotOnStartingRankOnHFile(Colour colour) => new()
        {
            StartingLocation = Square.At(File.H, Rank.Four),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.H, colour == Colour.White ? Rank.Five : Rank.Three)
            ],
            ExpectedIntrinsicCaptures = 
            [
                Square.At(File.G, colour == Colour.White ? Rank.Five : Rank.Three)
            ],
            Colour = colour
        };
    public static IntrinsicTestModelPawn NotOnStartingRankNotOnEdge(Colour colour) => new()
        {
            StartingLocation = Square.At(File.D, Rank.Four),
            ExpectedIntrinsicRelocations =
            [
                Square.At(File.D, colour == Colour.White ? Rank.Five : Rank.Three)
            ],
            ExpectedIntrinsicCaptures = 
            [
                Square.At(File.C, colour == Colour.White ? Rank.Five : Rank.Three),
                Square.At(File.E, colour == Colour.White ? Rank.Five : Rank.Three)
            ],
            Colour = colour
        };
}