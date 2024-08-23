namespace Jdev.ChessEngine.Tests.Worker;

using ChessEngine.Pieces;

[TestFixture]
public class Kill : WorkerBase
{
    [Test]
    public void ShouldRemovePieceFromGroup()
    {
        var king = new King();
        var group = new List<IPiece>
        {
            king,
            new Queen()
        };
        PieceGroupMock.SetupGet(x => x.Pieces).Returns(group);
        Worker.KillPiece(king);
        Assert.That(group, Does.Not.Contain(king));
    }
}