namespace Jdev.ChessEngine.Pieces;

using Models;

public class Knight : BasePiece
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