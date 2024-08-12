namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class King : BasePiece
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations() =>
        GetMoves().Select(s => new MoveProposition { Target = s, SubsequentMove = MoveType.Standard });

    public override IEnumerable<MoveProposition> GetIntrinsicCaptures() => GetIntrinsicRelocations();

    public override IEnumerable<Square> GetPotentialBlocks(Square destination) => GetMoves();

    public Rook? GetCastlingRook(Square destination)
    {
        return KingsideRook;
    }

    public Rook KingsideRook { private get; init; } = default!;
    public Rook QueensideRook { private get; init; } = default!;
    
    private IEnumerable<Square> GetMoves() =>
        Enumerable.Range(Position.File.Dec, Position.File.Inc - Position.File.Dec + 1)
            .SelectMany(i => Enumerable.Range(Position.Rank.Dec, Position.Rank.Inc - Position.Rank.Dec + 1)
                .Select(j => Square.At(File.At(i), Rank.At(j))))
            .Where(s => s != Position);
}