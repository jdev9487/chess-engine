namespace Jdev.ChessEngine.Pieces;

using Interfaces;
using Models;

public class King : BasePiece, IPiece
{
    public IEnumerable<MoveProposition> GetIntrinsicMoves()
    {
        throw new NotImplementedException();
    }

    public List<Square> GetPotentialBlocks(Square destination)
    {
        throw new NotImplementedException();
    }

    private bool HasMoved { get; set; }
    private Rook KingsideRook { get; init; } = default!;
    private Rook QueensideRook { get; init; } = default!;
}