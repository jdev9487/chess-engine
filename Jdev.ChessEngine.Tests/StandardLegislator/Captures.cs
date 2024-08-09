namespace Jdev.ChessEngine.Tests.StandardLegislator;

using Enums;
using Interfaces;
using Models;

public class Captures : Base
{
    private IPiece _pieceToCapture;
    private IPiece _pieceToBeCaptured;
    
    [SetUp]
    public void CapturesSetUp()
    {
        Legislator.PieceGroup.PieceAt(File.E, Rank.Two)!.Position = Square.At(File.E, Rank.Three);
        _pieceToCapture = Legislator.PieceGroup.PieceAt(File.D, Rank.One)!;
        _pieceToBeCaptured = Legislator.PieceGroup.PieceAt(File.H, Rank.Seven)!;
        _pieceToBeCaptured.Position = Square.At(File.H, Rank.Five);
        
        Legislator.EnactMove(new MoveRequest
        {
            Destination = Square.At(File.H, Rank.Five),
            PieceToMove = _pieceToCapture
        });
    }

    [Test]
    public void D1ShouldBeFree()
    {
        Assert.That(Legislator.PieceGroup.PieceAt(File.D, Rank.One), Is.Null);
    }

    [Test]
    public void H5ShouldNotBeRook()
    {
        Assert.That(Legislator.PieceGroup.PieceAt(File.H, Rank.Five), Is.Not.SameAs(_pieceToBeCaptured));
    }

    [Test]
    public void H5ShouldBeQueen()
    {
        Assert.That(Legislator.PieceGroup.PieceAt(File.H, Rank.Five), Is.SameAs(_pieceToCapture));
    }
}