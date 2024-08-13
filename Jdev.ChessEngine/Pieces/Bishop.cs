namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class Bishop : BasePiece
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations() =>
        GetMoves().Select(s => new MoveProposition { Target = s, SubsequentMove = MoveType.Standard });

    public override IEnumerable<MoveProposition> GetIntrinsicCaptures() => GetIntrinsicRelocations();

    public override IEnumerable<Square> GetPotentialBlocks(Square destination) => GetMoves();

    private IEnumerable<Square> GetMoves() => Position.GetEnclosingPositiveDiagonal()
        .Concat(Position.GetEnclosingNegativeDiagonal())
        .Where(s => s != Position);

    public override string ToString() => Colour switch
    {
        Colour.White => "♗",
        Colour.Black => "♝",
        _ => throw new ArgumentOutOfRangeException()
    };
}