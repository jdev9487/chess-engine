// See https://aka.ms/new-console-template for more information

using Jdev.ChessEngine.Board;
using Jdev.ChessEngine.Enums;
using Jdev.ChessEngine.Factory;
using Jdev.ChessEngine.Legislation;
using Jdev.ChessEngine.Pieces;
using File = Jdev.ChessEngine.Board.File;

Console.WriteLine("Hello, World!");

var slf = new StandardLegislatorFactory(new PieceFactory());
var standard = slf.Create();

var pieces = standard.PieceGroup;

standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.E, Rank.Two)!,
    Destination = Square.At(File.E, Rank.Four)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.C, Rank.Seven)!,
    Destination = Square.At(File.C, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.F, Rank.One)!,
    Destination = Square.At(File.C, Rank.Four)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.D, Rank.Seven)!,
    Destination = Square.At(File.D, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.E, Rank.Four)!,
    Destination = Square.At(File.D, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.D, Rank.Eight)!,
    Destination = Square.At(File.D, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.C, Rank.Four)!,
    Destination = Square.At(File.B, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.C, Rank.Eight)!,
    Destination = Square.At(File.D, Rank.Seven)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.G, Rank.One)!,
    Destination = Square.At(File.F, Rank.Three)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.B, Rank.Eight)!,
    Destination = Square.At(File.C, Rank.Six)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.E, Rank.One)!,
    Destination = Square.At(File.G, Rank.One)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.E, Rank.Eight)!,
    Destination = Square.At(File.C, Rank.Eight)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.B, Rank.Five)!,
    Destination = Square.At(File.C, Rank.Six)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.B, Rank.Seven)!,
    Destination = Square.At(File.C, Rank.Six)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.B, Rank.Two)!,
    Destination = Square.At(File.B, Rank.Four)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.C, Rank.Five)!,
    Destination = Square.At(File.C, Rank.Four)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.B, Rank.Four)!,
    Destination = Square.At(File.B, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.C, Rank.Six)!,
    Destination = Square.At(File.C, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.B, Rank.Five)!,
    Destination = Square.At(File.B, Rank.Six)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.D, Rank.Seven)!,
    Destination = Square.At(File.H, Rank.Three)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.B, Rank.Six)!,
    Destination = Square.At(File.B, Rank.Seven)
});
standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.C, Rank.Eight)!,
    Destination = Square.At(File.C, Rank.Seven)
});
var res = (PromotionResponse)standard.EnactMove(new MoveRequest
{
    PieceToMove = standard.PieceGroup.PieceAt(File.B, Rank.Seven)!,
    Destination = Square.At(File.B, Rank.Eight)
});
standard.Promote(res.CreateSubsequentRequest<Queen>(PieceType.Queen));

var x = 1;