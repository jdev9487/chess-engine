namespace Jdev.ChessEngine.Tests.Worker;

using Board;
using ChessEngine.Pieces;
using Moq;

[TestFixture]
public class Castle : WorkerBase
{
    private Mock<IKing> _kingMock;
    private Mock<IRook> _castlingRookMock;
    private ISquare _destination;
    private ISquare _rookDestination;
    
    [SetUp]
    public void CastleSetUp()
    {
        _castlingRookMock = new Mock<IRook> { Object = { Position = Square.At(File.H, Rank.One) } };
        _rookDestination = Square.At(File.F, Rank.One);
        _castlingRookMock.SetupGet(x => x.CastlingLocation).Returns(_rookDestination);
        var origin = Square.At(File.E, Rank.One);
        _destination = Square.At(File.G, Rank.One);
        _kingMock = new Mock<IKing> { Object = { Position = origin } };
        _kingMock.Setup(x => x.GetCastlingRook(It.IsAny<Square>())).Returns(_castlingRookMock.Object);
        Worker.Castle(_kingMock.Object, _destination);
    }
    
    [Test]
    public void ShouldUpdatePositionOfKing() => _kingMock.VerifySet(x => x.Position = _destination);

    [Test]
    public void ShouldUpdatePositionOfCastle() => _castlingRookMock.VerifySet(x => x.Position = _rookDestination);

    [Test]
    public void ShouldUpdateHasMovedStatusOfKing() => _kingMock.VerifySet(x => x.HasMoved = true);

    [Test]
    public void ShouldUpdateHasMovedStatusOfRook() => _castlingRookMock.VerifySet(x => x.HasMoved = true);
}