namespace Jdev.ChessEngine.Legislation;

using Pieces;
using Services;

public abstract class BaseLegislator()
{
    protected IQuery Query { get; } = default!;
    protected IWorker Worker { get; } = default!;
    public IPieceGroup PieceGroup => Query.PieceGroup;

    protected BaseLegislator(IQuery query, IWorker worker) : this()
    {
        Query = query;
        Worker = worker;
    }
    public abstract MoveResponse EnactMove(MoveRequest request);
    public abstract MoveResponse Promote<T>(PromotionRequest request) where T : IPiece, new();
}