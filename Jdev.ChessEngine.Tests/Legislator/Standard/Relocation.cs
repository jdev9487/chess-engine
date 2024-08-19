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
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, Request.PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, Request.PieceToMove))
            .Returns(true);
        Act();
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
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, Request.PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, Request.PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, Request.PieceToMove))
            .Returns(MoveType.Standard);
        Act();
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
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, Request.PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, Request.PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, Request.PieceToMove))
            .Returns(MoveType.Standard);
        Act();
        WorkerMock
            .Verify(x => x.RelocatePiece(Request.PieceToMove, Request.Destination), Times.Once);
    }
    
    [Test]
    public void ShouldAcceptWithPromotion()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, Request.PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, Request.PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, Request.PieceToMove))
            .Returns(MoveType.Promotion);
        Act();
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
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, Request.PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, Request.PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, Request.PieceToMove))
            .Returns(MoveType.Castle);
        QueryMock
            .Setup(x => x.CanKingCastle((IKing)Request.PieceToMove, Request.Destination))
            .Returns(false);
        Act();
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
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, Request.PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsPieceBlockedForRelocation(Request.Destination, Request.PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, Request.PieceToMove))
            .Returns(MoveType.Castle);
        QueryMock
            .Setup(x => x.CanKingCastle((IKing)Request.PieceToMove, Request.Destination))
            .Returns(true);
        Act();
        WorkerMock
            .Verify(x => x.Castle((IKing)Request.PieceToMove, Request.Destination), Times.Once);
    }
}