namespace Jdev.ChessEngine.Tests.Worker;

using Moq;
using Factory;
using Services;
using Jdev.ChessEngine.Pieces;

public class WorkerBase
{
    private protected Worker Worker = default!;
    private protected Mock<IPieceGroup> PieceGroupMock = default!;
    private protected Mock<IPieceFactory> PieceFactoryMock = default!;

    [SetUp]
    public void SetUp()
    {
        PieceGroupMock = new Mock<IPieceGroup>();
        PieceFactoryMock = new Mock<IPieceFactory>();
        Worker = new Worker(PieceGroupMock.Object, PieceFactoryMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        PieceGroupMock = null!;
        PieceFactoryMock = null!;
        Worker = null!;
    }
}