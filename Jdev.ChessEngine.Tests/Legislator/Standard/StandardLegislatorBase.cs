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
    private protected Mock<IState> StateMock = default!;
    private protected Mock<IPieceGroup> PieceGroupMock = default!;
    private protected MoveRequest Request = default!;
    private protected PromotionRequest PromotionRequest = default!;
    private protected MoveResponse Response = default!;
    private protected IPiece PieceToMove = default!;

    [SetUp]
    public void SetUp()
    {
        QueryMock = new Mock<IQuery>();
        WorkerMock = new Mock<IWorker>();
        StateMock = new Mock<IState>();
        PieceGroupMock = new Mock<IPieceGroup>();
        _standard = new Standard(QueryMock.Object, WorkerMock.Object, StateMock.Object);
        Request = new MoveRequest
        {
            Destination = Square.At(File.A, Rank.One),
            Origin = Square.At(File.B, Rank.Three)
        };
        PieceToMove = new King();
        PieceGroupMock
            .Setup(x => x.PieceAt(Request.Origin))
            .Returns(PieceToMove);
        QueryMock
            .SetupGet(x => x.PieceGroup)
            .Returns(PieceGroupMock.Object);
        QueryMock
            .Setup(x => x.PieceAt(Request.Origin))
            .Returns(PieceToMove);
    }

    private protected void EnactMove() => Response = _standard.EnactMove(Request);

    private protected void Promote<TPiece>() where TPiece : IPiece, new() =>
        Response = _standard.Promote<TPiece>(PromotionRequest);

    [TearDown]
    public void TearDown()
    {
        QueryMock = null!;
        WorkerMock = null!;
        StateMock = null!;
        _standard = null!;
    }
}