namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using ChessEngine.Pieces;
using Enums;
using Legislation;
using Moq;

[TestFixture]
public class Capture : StandardLegislatorBase
{
    [Test]
    public void ShouldRejectDueToBlock()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsPieceBlockedForCapture(Request.Destination, PieceToMove))
            .Returns(true);
        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.False);
            Assert.That(Response.RejectionReason, Is.EqualTo(RejectionReason.MoveBlocked));
        });
    }
    
    [Test]
    public void ShouldAcceptAsStandardCapture()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsPieceBlockedForCapture(Request.Destination, PieceToMove))
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
            .Returns(true);
        QueryMock
            .Setup(x => x.IsPieceBlockedForCapture(Request.Destination, PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, PieceToMove))
            .Returns(MoveType.Standard);
        EnactMove();
        WorkerMock
            .Verify(x => x.RelocatePiece(PieceToMove, Request.Destination), Times.Once);
    }
    
    [Test]
    public void ShouldKillPiece()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsPieceBlockedForCapture(Request.Destination, PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, PieceToMove))
            .Returns(MoveType.Standard);
        var pieceToKill = new Pawn();
        QueryMock
            .Setup(x => x.PieceAt(Request.Destination))
            .Returns(pieceToKill);
        EnactMove();
        WorkerMock
            .Verify(x => x.KillPiece(pieceToKill), Times.Once);
    }
    
    [Test]
    public void ShouldAcceptWithPromotion()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsPieceBlockedForCapture(Request.Destination, PieceToMove))
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
        StateMock.VerifySet(state => state.ExpectingPromotion = true);
    }
    
    [Test]
    public void ShouldRejectDueToIllegalCastle()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationOccupied(Request.Destination))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsPieceBlockedForCapture(Request.Destination, PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.GetMoveType(Request.Destination, PieceToMove))
            .Returns(MoveType.Castle);
        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.False);
            Assert.That(Response.RejectionReason, Is.EqualTo(RejectionReason.IllegalCastleAttempt));
        });
    }
}