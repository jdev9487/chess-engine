namespace Jdev.ChessEngine.Pieces;

using Board;
using Models;

public class Bishop : BasePiece
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<MoveProposition> GetIntrinsicCaptures()
    {
        throw new NotImplementedException();
    }

    public override List<Square> GetPotentialBlocks(Square destination)
    {
        throw new NotImplementedException();
    }
}