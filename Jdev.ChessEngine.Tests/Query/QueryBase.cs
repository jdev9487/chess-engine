namespace Jdev.ChessEngine.Tests.Query;

using Moq;
using Services;
using ChessEngine.Pieces;

public class QueryBase
{
    private protected Query Query = default!;
    private protected Mock<IPieceGroup> PieceGroupMock = default!;

    [SetUp]
    public void SetUp()
    {
        PieceGroupMock = new Mock<IPieceGroup>();
        Query = new Query(PieceGroupMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        PieceGroupMock = null!;
        Query = null!;
    }
}