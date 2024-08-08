namespace Jdev.ChessEngine.Tests;

using Enums;
using Factory;
using Interfaces;
using Models;

public class StandardLegislatorTests
{
    private ILegislator _legislator = default!;
    private IPiece _pieceToMove = default!;
    
    [SetUp]
    public void SetUp()
    {
        var legFac = new StandardLegislatorFactory(new PieceFactory());
        var legislation = legFac.Create();
        
        _legislator = legislation.Legislator;
        _pieceToMove = _legislator.PieceGroup.PieceAt(File.E, Rank.Two)!;
        _legislator.EnactMove(new MoveRequest
        {
            PieceToMove = _pieceToMove,
            Destination = Square.At(File.E, Rank.Four)
        });
    }
    
    [Test]
    public void E2ShouldBeFree()
    {
        Assert.That(_legislator.PieceGroup.PieceAt(File.E, Rank.Two), Is.Null);
    }
    
    [Test]
    public void E4ShouldBeOccupiedByPieceThatWasMoved()
    {
        Assert.That(_legislator.PieceGroup.PieceAt(File.E, Rank.Four), Is.SameAs(_pieceToMove));
    }
}