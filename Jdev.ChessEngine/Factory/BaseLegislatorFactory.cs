namespace Jdev.ChessEngine.Factory;

using Pieces;
using Services;
using ChessEngine.Legislation;

public abstract class BaseLegislatorFactory
{
    public BaseLegislator Create()
    {
        var pieceGroup = CreatePieces();
        var query = CreateQuery(pieceGroup);
        var worker = CreateWorker(pieceGroup);
        var state = new State(pieceGroup);
        return CreateLegislator(query, worker, state);
    }
    protected abstract PieceGroup CreatePieces();
    protected abstract BaseLegislator CreateLegislator(IQuery query, IWorker worker, IState state);
    protected abstract IQuery CreateQuery(PieceGroup pieceGroup);
    protected abstract IWorker CreateWorker(PieceGroup pieceGroup);
}