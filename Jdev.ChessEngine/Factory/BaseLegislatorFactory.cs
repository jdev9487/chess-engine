namespace Jdev.ChessEngine.Factory;

using Pieces;
using Services;
using ChessEngine.Legislation;

public abstract class BaseLegislatorFactory<T> where T : BaseLegislator
{
    public T Create()
    {
        var pieceGroup = CreatePieces();
        var query = CreateQuery(pieceGroup);
        var worker = CreateWorker(pieceGroup);
        return CreateLegislator(query, worker);
    }
    protected abstract PieceGroup CreatePieces();
    protected abstract T CreateLegislator(IQuery query, IWorker worker);
    protected abstract IQuery CreateQuery(PieceGroup pieceGroup);
    protected abstract IWorker CreateWorker(PieceGroup pieceGroup);
}