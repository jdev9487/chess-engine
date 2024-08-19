namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using Moq;
using Board;
using Services;
using Legislation;

public class StandardLegislatorBase
{
    private protected Standard Standard = default!;
    private protected Mock<IQuery> QueryMock = default!;
    private protected Mock<IWorker> WorkerMock = default!;
    private protected MoveRequest Request = default!;
    private protected MoveResponse Response = default!;

    [SetUp]
    public void SetUp()
    {
        QueryMock = new Mock<IQuery>();
        WorkerMock = new Mock<IWorker>();
        Standard = new Standard(QueryMock.Object, WorkerMock.Object);
        Request = new MoveRequest
        {
            Destination = Square.At(File.A, Rank.One),
            PieceToMove = new ChessEngine.Pieces.King()
        };
    }

    private protected MoveResponse Act() => Response = Standard.EnactMove(Request);

    [TearDown]
    public void TearDown()
    {
        QueryMock = null!;
        WorkerMock = null!;
        Standard = null!;
    }
}