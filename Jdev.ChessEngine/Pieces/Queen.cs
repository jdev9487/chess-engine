namespace Jdev.ChessEngine.Pieces;

using Enums;
using Models;

public class Queen : BasePiece
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations() =>
        GetMoves().Select(s => new MoveProposition { Target = s, SubsequentMove = MoveType.Standard });

    public override IEnumerable<MoveProposition> GetIntrinsicCaptures() => GetIntrinsicRelocations();

    public override IEnumerable<Square> GetPotentialBlocks(Square destination) => GetMoves();

    private IEnumerable<Square> GetMoves() => Position.GetEnclosingRank()
        .Concat(Position.GetEnclosingFile())
        .Concat(Position.GetEnclosingPositiveDiagonal())
        .Concat(Position.GetEnclosingNegativeDiagonal())
        .Where(s => s != Position);
}