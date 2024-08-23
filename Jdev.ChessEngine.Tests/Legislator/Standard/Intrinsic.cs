namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using Board;
using ChessEngine.Pieces;
using Enums;
using Moq;

[TestFixture]
public class Intrinsic : StandardLegislatorBase
{
    [Test]
    public void ShouldRejectDueToNotIntrinsic()
    {
        QueryMock
            .Setup(x => x.IsDestinationIntrinsic(It.IsAny<ISquare>(), It.IsAny<IPiece>()))
            .Returns(false);
        EnactMove();
        Assert.Multiple(() =>
        {
            Assert.That(Response.Success, Is.False);
            Assert.That(Response.RejectionReason, Is.EqualTo(RejectionReason.MoveNotIntrinsic));
        });
    }

    [Test]
    public void ShouldAcceptDueToIntrinsic()
    {
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