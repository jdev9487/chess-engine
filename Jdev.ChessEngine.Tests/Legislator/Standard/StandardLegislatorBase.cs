namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using Moq;
using Board;
using ChessEngine.Pieces;
using Services;
using Legislation;

public class StandardLegislatorBase
{
    private Standard _standard = default!;
    private protected Mock<IQuery> QueryMock = default!;
    private protected Mock<IWorker> WorkerMock = default!;
    private protected MoveRequest Request = default!;
    private protected MoveResponse Response = default!;
    private protected IPiece PieceToMove = default!;

    [SetUp]
    public void SetUp()
    {
        QueryMock = new Mock<IQuery>();
        WorkerMock = new Mock<IWorker>();
        _standard = new Standard(QueryMock.Object, WorkerMock.Object);
        Request = new MoveRequest
        {
            Destination = Square.At(File.A, Rank.One),
            Origin = Square.At(File.B, Rank.Three)
        };
        PieceToMove = new King();
        var pieceGroupMock = new Mock<IPieceGroup>();
        pieceGroupMock
            .Setup(x => x.PieceAt(Request.Origin))
            .Returns(PieceToMove);
        QueryMock
            .SetupGet(x => x.PieceGroup)
            .Returns(pieceGroupMock.Object);
        QueryMock
            .Setup(x => x.PieceAt(Request.Origin))
            .Returns(PieceToMove);
    }

    private protected void Act() => Response = _standard.EnactMove(Request);

    [TearDown]
    public void TearDown()
    {
        QueryMock = null!;
        WorkerMock = null!;
        _standard = null!;
    }
}