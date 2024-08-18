namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;
using Enums;
using Models;

public static class Pawn
{
    // White
    public static readonly BlockTestModelPawn WhiteInitialOne = new()
        {
            Origin = Square.At(File.D, Rank.Two),
            Colour = Colour.White,
            Destination = Square.At(File.D, Rank.Three),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Three)
            ],
            ExpectedCaptureBlocks = [],
            HasMoved = false
        };
    public static readonly BlockTestModelPawn WhiteInitialTwo = new()
        {
            Origin = Square.At(File.D, Rank.Two),
            Colour = Colour.White,
            Destination = Square.At(File.D, Rank.Four),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Three),
                Square.At(File.D, Rank.Four)
            ],
            ExpectedCaptureBlocks = [],
            HasMoved = false
        };
    public static readonly BlockTestModelPawn WhiteOne = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.D, Rank.Six),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Six)
            ],
            ExpectedCaptureBlocks = []
        };
    public static readonly BlockTestModelPawn WhiteTwo = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.D, Rank.Seven),
            ExpectedRelocationBlocks = []
        };
    public static readonly BlockTestModelPawn WhiteStandardCaptureLeft = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.C, Rank.Six),
            ExpectedRelocationBlocks = [],
            ExpectedCaptureBlocks = [Square.At(File.C, Rank.Six)]
        };
    public static readonly BlockTestModelPawn WhiteStandardCaptureRight = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.E, Rank.Six),
            ExpectedRelocationBlocks = [],
            ExpectedCaptureBlocks = [Square.At(File.E, Rank.Six)]
        };
    public static readonly BlockTestModelPawn WhiteOff = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.E, Rank.Seven),
            ExpectedRelocationBlocks = []
        };
    // Black
    public static readonly BlockTestModelPawn BlackInitialOne = new()
        {
            Origin = Square.At(File.D, Rank.Seven),
            Colour = Colour.Black,
            Destination = Square.At(File.D, Rank.Six),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Six)
            ],
            ExpectedCaptureBlocks = [],
            HasMoved = false
        };
    public static readonly BlockTestModelPawn BlackInitialTwo = new()
        {
            Origin = Square.At(File.D, Rank.Seven),
            Colour = Colour.Black,
            Destination = Square.At(File.D, Rank.Five),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Six),
                Square.At(File.D, Rank.Five)
            ],
            ExpectedCaptureBlocks = [],
            HasMoved = false
        };
    public static readonly BlockTestModelPawn BlackOne = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.D, Rank.Four),
            ExpectedRelocationBlocks =
            [
                Square.At(File.D, Rank.Four)
            ],
            ExpectedCaptureBlocks = []
        };
    public static readonly BlockTestModelPawn BlackTwo = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.Black,
            Destination = Square.At(File.D, Rank.Three),
            HasMoved = true,
            ExpectedRelocationBlocks = []
        };
    public static readonly BlockTestModelPawn BlackStandardCaptureLeft = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.Black,
            Destination = Square.At(File.C, Rank.Four),
            ExpectedRelocationBlocks = [],
            ExpectedCaptureBlocks = [Square.At(File.C, Rank.Four)]
        };
    public static readonly BlockTestModelPawn BlackStandardCaptureRight = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.Black,
            Destination = Square.At(File.E, Rank.Four),
            ExpectedRelocationBlocks = [],
            ExpectedCaptureBlocks = [Square.At(File.E, Rank.Four)]
        };
    public static readonly BlockTestModelPawn BlackOff = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.Black,
            Destination = Square.At(File.E, Rank.Two),
            ExpectedRelocationBlocks = []
        };
}