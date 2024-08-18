namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Cases;

using Board;
using Enums;

public static class Pawn
{
    // White
    public static readonly BlockTestModel WhiteInitialOne = new()
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
    public static readonly BlockTestModel WhiteInitialTwo = new()
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
    public static readonly BlockTestModel WhiteOne = new()
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
    public static readonly BlockTestModel WhiteTwo = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.D, Rank.Seven),
            ExpectedRelocationBlocks = []
        };
    public static readonly BlockTestModel WhiteStandardCaptureLeft = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.C, Rank.Six),
            ExpectedRelocationBlocks = [],
            ExpectedCaptureBlocks = [Square.At(File.C, Rank.Six)]
        };
    public static readonly BlockTestModel WhiteStandardCaptureRight = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.E, Rank.Six),
            ExpectedRelocationBlocks = [],
            ExpectedCaptureBlocks = [Square.At(File.E, Rank.Six)]
        };
    public static readonly BlockTestModel WhiteOff = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.White,
            Destination = Square.At(File.E, Rank.Seven),
            ExpectedRelocationBlocks = []
        };
    // Black
    public static readonly BlockTestModel BlackInitialOne = new()
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
    public static readonly BlockTestModel BlackInitialTwo = new()
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
    public static readonly BlockTestModel BlackOne = new()
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
    public static readonly BlockTestModel BlackTwo = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.Black,
            Destination = Square.At(File.D, Rank.Three),
            HasMoved = true,
            ExpectedRelocationBlocks = []
        };
    public static readonly BlockTestModel BlackStandardCaptureLeft = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.Black,
            Destination = Square.At(File.C, Rank.Four),
            ExpectedRelocationBlocks = [],
            ExpectedCaptureBlocks = [Square.At(File.C, Rank.Four)]
        };
    public static readonly BlockTestModel BlackStandardCaptureRight = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.Black,
            Destination = Square.At(File.E, Rank.Four),
            ExpectedRelocationBlocks = [],
            ExpectedCaptureBlocks = [Square.At(File.E, Rank.Four)]
        };
    public static readonly BlockTestModel BlackOff = new()
        {
            Origin = Square.At(File.D, Rank.Five),
            Colour = Colour.Black,
            Destination = Square.At(File.E, Rank.Two),
            ExpectedRelocationBlocks = []
        };
}