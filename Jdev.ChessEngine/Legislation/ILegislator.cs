namespace Jdev.ChessEngine.Legislation;

using Pieces;
using Services;

public abstract class BaseLegislator()
{
    public IQuery Query { get; }
    public IWorker Worker { get; }
    public BaseLegislator(IQuery query, IWorker worker) : this()
    {
        Query = query;
        Worker = worker;
    }
    public abstract MoveResponse EnactMove(MoveRequest request);
    public abstract MoveResponse Promote<T>(PromotionRequest<T> request) where T : IPiece, new();
}