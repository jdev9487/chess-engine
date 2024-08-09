namespace Jdev.ChessEngine.Tests.StandardLegislator.IntrinsicMoves;

using Enums;
using Models;

[TestFixture]
public class Pawn : Base
{
    [Test]
    public void WhitePawnShouldMoveForwardOneFromStart()
    {
        var pawnToMove = Legislator.PieceGroup.PieceAt(File.A, Rank.Two)!;
        Legislator.EnactMove(new MoveRequest
        {
            PieceToMove = pawnToMove,
            Destination = Square.At(File.A, Rank.Three)
        });
        
        Assert.That(pawnToMove.Position, Is.SameAs(Square.At(File.A, Rank.Three)));
    }
    
    [Test]
    public void WhitePawnShouldMoveForwardTwoFromStart()
    {
        var pawnToMove = Legislator.PieceGroup.PieceAt(File.A, Rank.Two)!;
        Legislator.EnactMove(new MoveRequest
        {
            PieceToMove = pawnToMove,
            Destination = Square.At(File.A, Rank.Four)
        });
        
        Assert.That(pawnToMove.Position, Is.SameAs(Square.At(File.A, Rank.Four)));
    }
    
    [Test]
    public void WhitePawnShouldNotMoveForwardThreeFromStart()
    {
        var pawnToMove = Legislator.PieceGroup.PieceAt(File.A, Rank.Two)!;
        Legislator.EnactMove(new MoveRequest
        {
            PieceToMove = pawnToMove,
            Destination = Square.At(File.A, Rank.Five)
        });
        
        Assert.That(pawnToMove.Position, Is.SameAs(Square.At(File.A, Rank.Two)));
    }
}