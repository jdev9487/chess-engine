namespace Jdev.ChessEngine.Tests.Worker;

using Board;
using Enums;
using ChessEngine.Pieces;

[TestFixture]
public class Spawn : WorkerBase
{
    [Test]
    public void ShouldCreateNewPiece()
    {
        var group = new List<IPiece>();
        var destination = Square.At(File.F, Rank.Five);
        PieceGroupMock.SetupGet(x => x.Pieces).Returns(group);
        var queen = new Queen { Colour = Colour.White };
        PieceFactoryMock.Setup(x => x.Create<Queen>(destination, Colour.White)).Returns(queen);
        Worker.SpawnPiece<Queen>(destination, Colour.White);
        Assert.That(group, Does.Contain(queen));
    }
}