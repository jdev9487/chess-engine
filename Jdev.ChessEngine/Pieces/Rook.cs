namespace Jdev.ChessEngine.Pieces;

using Interfaces;
using Models;

public class Rook : BasePiece, IPiece
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
}