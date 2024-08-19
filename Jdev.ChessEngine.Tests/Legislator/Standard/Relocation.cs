namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using ChessEngine.Pieces;
using Enums;
using Legislation;
using Moq;

[TestFixture]
public class Relocation : StandardLegislatorBase
{
    [Test]
    public void ShouldRejectDueToBlock()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, PieceToMove))
            .Returns(true);
        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.False);
            Assert.That(Response.RejectionReason, Is.EqualTo(RejectionReason.MoveBlocked));
        });
    }
    
    [Test]
    public void ShouldAcceptAsStandardRelocation()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, PieceToMove))
            .Returns(MoveType.Standard);
        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.True);
            Assert.That(Response.RejectionReason, Is.Null);
            Assert.That(Response, Is.Not.TypeOf<PromotionResponse>());
        });
    }
    
    [Test]
    public void ShouldRelocatePiece()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, PieceToMove))
            .Returns(MoveType.Standard);
        EnactMove();
        WorkerMock
            .Verify(x => x.RelocatePiece(PieceToMove, Request.Destination), Times.Once);
    }
    
    [Test]
    public void ShouldAcceptWithPromotion()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, PieceToMove))
            .Returns(MoveType.Promotion);
        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.True);
            Assert.That(Response.RejectionReason, Is.Null);
            Assert.That(Response, Is.TypeOf<PromotionResponse>());
        });
    }
    
    [Test]
    public void ShouldRejectDueToIllegalCastle()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, PieceToMove))
            .Returns(MoveType.Castle);
        QueryMock
            .Setup(x => x.CanKingCastle((IKing)PieceToMove, Request.Destination))
            .Returns(false);
        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.False);
            Assert.That(Response.RejectionReason, Is.EqualTo(RejectionReason.IllegalCastleAttempt));
        });
    }
    
    [Test]
    public void ShouldCastle()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, PieceToMove))
            .Returns(MoveType.Castle);
        QueryMock
            .Setup(x => x.CanKingCastle((IKing)PieceToMove, Request.Destination))
            .Returns(true);
        EnactMove();
        WorkerMock
            .Verify(x => x.Castle((IKing)PieceToMove, Request.Destination), Times.Once);
    }
}