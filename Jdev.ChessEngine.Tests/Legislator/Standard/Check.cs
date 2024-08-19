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
            .Setup(x => x.WouldRequestResultInCheck(Request.Destination, Request.PieceToMove))
            .Returns(true);
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(It.IsAny<ISquare>(), It.IsAny<IPiece>()))
            .Returns(true);
        Act();
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
            .Setup(x => x.IsInCheck(Request.PieceToMove.Colour))
            .Returns(true);
        QueryMock
            .Setup(x => x.WouldRequestResultInCheck(Request.Destination, Request.PieceToMove))
            .Returns(false);
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(It.IsAny<ISquare>(), It.IsAny<IPiece>()))
            .Returns(true);
        Act();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.True);
            Assert.That(Response.RejectionReason, Is.Null);
        });
    }
}