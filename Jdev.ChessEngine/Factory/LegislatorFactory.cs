namespace Jdev.ChessEngine.Factory;

using ChessEngine.Legislation;
using Pieces;

public abstract class LegislatorFactory : ILegislatorFactory
{
    public Legislation Create() => new() { Legislator = Create(CreatePieces()) };
    protected abstract ILegislator Create(PieceGroup pieceGroup);
    protected abstract PieceGroup CreatePieces();
}