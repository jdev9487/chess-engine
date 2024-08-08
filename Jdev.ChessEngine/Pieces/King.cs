namespace Jdev.ChessEngine.Pieces;

using Interfaces;
using Models;

public class King : BasePiece, IPiece
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

    public Rook GetCastlingRook(Square destination)
    {
        return KingsideRook;
    }

    private bool HasMoved { get; set; }
    private Rook KingsideRook { get; init; } = default!;
    private Rook QueensideRook { get; init; } = default!;
}