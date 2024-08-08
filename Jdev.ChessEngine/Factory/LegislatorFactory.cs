namespace Jdev.ChessEngine.Factory;

using Models;
using Interfaces;

public abstract class LegislatorFactory : ILegislatorFactory
{
    public Legislation Create() => new() { Legislator = Create(CreatePieces()) };
    protected abstract ILegislator Create(PieceGroup pieceGroup);
    protected abstract PieceGroup CreatePieces();
}