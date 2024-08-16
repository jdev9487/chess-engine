namespace Jdev.ChessEngine.Tests.Query;

using Board;
using Moq;

[TestFixture]
public class PieceAt : QueryBase
{
    [Test]
    public void ShouldCallPieceGroupWithFileAndRank()
    {
        var file = File.A;
        var rank = Rank.Four;
        Query.PieceAt(file, rank);
        PieceGroupMock
            .Verify(x => x.PieceAt(file, rank), Times.Once);
    }
    
    [Test]
    public void ShouldCallPieceGroupWithSquare()
    {
        var file = File.A;
        var rank = Rank.Four;
        Query.PieceAt(Square.At(file, rank));
        PieceGroupMock
            .Verify(x => x.PieceAt(file, rank), Times.Once);
    }
}