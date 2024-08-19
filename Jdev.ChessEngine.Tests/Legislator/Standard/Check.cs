namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using Moq;
using Board;
using Enums;
using ChessEngine.Pieces;

[TestFixture]
public class Check : StandardLegislatorBase
{
    [Test]
    public void ShouldRejectDueToMovingIntoCheck()
    {
        QueryMock
            .Setup(x => x.WouldRequestResultInCheck(Request.Destination, PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(It.IsAny<ISquare>(), It.IsAny<IPiece>()))
            .Returns(true);
        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.False);
            Assert.That(Response.RejectionReason, Is.EqualTo(RejectionReason.MoveResultsInCheck));
        });
    }

    [Test]
    public void ShouldAcceptDueToResolvedCheck()
    {
        QueryMock
            .Setup(x => x.IsInCheck(PieceToMove.Colour))
            .Returns(true);
        QueryMock
            .Setup(x => x.WouldRequestResultInCheck(Request.Destination, PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(It.IsAny<ISquare>(), It.IsAny<IPiece>()))
            .Returns(true);
        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.True);
            Assert.That(Response.RejectionReason, Is.Null);
        });
    }
}