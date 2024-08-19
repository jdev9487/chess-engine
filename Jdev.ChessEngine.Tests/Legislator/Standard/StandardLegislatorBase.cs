namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using Moq;
using Board;
using Services;
using Legislation;

public class StandardLegislatorBase
{
    private Standard _standard = default!;
    private protected Mock<IQuery> QueryMock = default!;
    private protected Mock<IWorker> WorkerMock = default!;
    private protected MoveRequest Request = default!;
    private protected MoveResponse Response = default!;

    [SetUp]
    public void SetUp()
    {
        QueryMock = new Mock<IQuery>();
        WorkerMock = new Mock<IWorker>();
        _standard = new Standard(QueryMock.Object, WorkerMock.Object);
        Request = new MoveRequest
        {
            Destination = Square.At(File.A, Rank.One),
            PieceToMove = new ChessEngine.Pieces.King()
        };
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