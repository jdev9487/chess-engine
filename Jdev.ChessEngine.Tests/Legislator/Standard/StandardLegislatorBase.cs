namespace Jdev.ChessEngine.Tests.Legislator.Standard;

using Legislation;
using Moq;
using Services;

public class StandardLegislatorBase
{
    private protected Standard Standard = default!;
    private protected Mock<IQuery> QueryMock = default!;
    private protected Mock<IWorker> WorkerMock = default!;

    [SetUp]
    public void SetUp()
    {
        QueryMock = new Mock<IQuery>();
        WorkerMock = new Mock<IWorker>();
        Standard = new Standard(QueryMock.Object, WorkerMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        QueryMock = null!;
        WorkerMock = null!;
        Standard = null!;
    }
}