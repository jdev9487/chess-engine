namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using Board;
using Enums;
using ChessEngine.Pieces;
using Legislation;
using Moq;

[TestFixture]
public class Promotion : StandardLegislatorBase
{
    [Test]
    public void ShouldNotEnactMoveWhenExpectingPromotion()
    {
        StateMock.SetupGet(x => x.ExpectingPromotion).Returns(true);

        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.False);
            Assert.That(Response.RejectionReason, Is.EqualTo(RejectionReason.PromotionExpected));
        });
    }

    [Test]
    public void ShouldNotPromoteWhenNotExpectingPromotion()
    {
        StateMock.SetupGet(x => x.ExpectingPromotion).Returns(false);

        Promote<Queen>();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.False);
            Assert.That(Response.RejectionReason, Is.EqualTo(RejectionReason.PromotionNotExpected));
        });
    }

    [Test]
    public void ShouldNotKillPieceAtDestinationWhenRelocate()
    {
        StateMock.SetupGet(x => x.ExpectingPromotion).Returns(true);

        PromotionRequest = new PromotionRequest
        {
            Destination = Square.At(File.F, Rank.Eight),
            Origin = Square.At(File.F, Rank.Seven),
            Relocation = true
        };
        PieceGroupMock
            .Setup(x => x.PieceAt(PromotionRequest.Destination))
            .Returns((IPiece)null!);
        var pieceToMove = new Pawn();
        PieceGroupMock
            .Setup(x => x.PieceAt(PromotionRequest.Origin))
            .Returns(pieceToMove);
        
        Promote<Rook>();
        
        WorkerMock.Verify(x => x.KillPiece(null!), Times.Never);
    }

    [Test]
    public void ShouldKillPieceAtDestinationWhenNotRelocate()
    {
        StateMock.SetupGet(x => x.ExpectingPromotion).Returns(true);

        PromotionRequest = new PromotionRequest
        {
            Destination = Square.At(File.F, Rank.Eight),
            Origin = Square.At(File.F, Rank.Seven),
            Relocation = false
        };
        var pieceToKill = new King();
        PieceGroupMock
            .Setup(x => x.PieceAt(PromotionRequest.Destination))
            .Returns(pieceToKill);
        var pieceToMove = new Pawn();
        PieceGroupMock
            .Setup(x => x.PieceAt(PromotionRequest.Origin))
            .Returns(pieceToMove);
        
        Promote<Rook>();
        
        WorkerMock.Verify(x => x.KillPiece(null!), Times.Once);
    }

    [Test]
    public void ShouldKillPieceAtOrigin()
    {
        StateMock.SetupGet(x => x.ExpectingPromotion).Returns(true);

        PromotionRequest = new PromotionRequest
        {
            Destination = Square.At(File.F, Rank.Eight), 
            Origin = Square.At(File.F, Rank.Seven)
        };
        var pieceToMove = new Pawn();
        PieceGroupMock
            .Setup(x => x.PieceAt(PromotionRequest.Origin))
            .Returns(pieceToMove);
        
        Promote<Rook>();
        
        WorkerMock.Verify(x => x.KillPiece(pieceToMove), Times.Once);
    }

    [Test]
    public void ShouldSpawnPieceAtDestination()
    {
        StateMock.SetupGet(x => x.ExpectingPromotion).Returns(true);

        PromotionRequest = new PromotionRequest
        {
            Destination = Square.At(File.F, Rank.Eight), 
            Origin = Square.At(File.F, Rank.Seven)
        };
        var pieceToMove = new Pawn();
        PieceGroupMock
            .Setup(x => x.PieceAt(PromotionRequest.Origin))
            .Returns(pieceToMove);
        
        Promote<Rook>();
        
        WorkerMock.Verify(x => x.SpawnPiece<Rook>(PromotionRequest.Destination, It.IsAny<Colour>()), Times.Once);
    }
}