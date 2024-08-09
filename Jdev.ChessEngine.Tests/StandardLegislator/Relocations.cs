namespace Jdev.ChessEngine.Tests.StandardLegislator;

using Enums;
using Models;
using Interfaces;

[TestFixture]
public class Relocations : Base
{
    private IPiece _pieceToMove;
    
    [SetUp]
    public void RelocationsSetUp()
    {
        _pieceToMove = Legislator.PieceGroup.PieceAt(File.E, Rank.Two)!;
        Legislator.EnactMove(new MoveRequest
        {
            PieceToMove = _pieceToMove,
            Destination = Square.At(File.E, Rank.Four)
        });
    }
    
    [Test]
    public void E2ShouldBeFree()
    {
        Assert.That(Legislator.PieceGroup.PieceAt(File.E, Rank.Two), Is.Null);
    }
    
    [Test]
    public void E4ShouldBeOccupiedByPieceThatWasMoved()
    {
        Assert.That(Legislator.PieceGroup.PieceAt(File.E, Rank.Four), Is.SameAs(_pieceToMove));
    }
}