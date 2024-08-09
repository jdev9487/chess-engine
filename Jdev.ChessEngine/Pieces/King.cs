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
    public Rook KingsideRook { private get; init; } = default!;
    public Rook QueensideRook { private get; init; } = default!;
}