namespace Jdev.ChessEngine.Pieces;

using Enums;
using Interfaces;
using Models;

public class Rook : BasePiece, IPiece
{
    public IEnumerable<MoveProposition> GetIntrinsicRelocations()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<MoveProposition> GetIntrinsicCaptures()
    {
        throw new NotImplementedException();
    }

    public List<Square> GetPotentialBlocks(Square destination)
    {
        throw new NotImplementedException();
    }

    public Square CastlingLocation { get; init; } = default!;

    private bool HasMoved { get; set; }
}