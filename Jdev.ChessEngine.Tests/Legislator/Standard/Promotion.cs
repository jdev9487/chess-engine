namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using ChessEngine.Pieces;
using Enums;
using Legislation;

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
}