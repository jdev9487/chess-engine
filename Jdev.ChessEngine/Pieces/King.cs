namespace Jdev.ChessEngine.Pieces;

using Enums;
using Models;

public class King : BasePiece
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations() =>
        GetMoves().Select(s => new MoveProposition { Target = s, SubsequentMove = MoveType.Standard });

    public override IEnumerable<MoveProposition> GetIntrinsicCaptures() => GetIntrinsicRelocations();

    public override IEnumerable<Square> GetPotentialBlocks(Square destination) => GetMoves();

    public Rook GetCastlingRook(Square destination)
    {
        return KingsideRook;
    }

    public Rook KingsideRook { private get; init; } = default!;
    public Rook QueensideRook { private get; init; } = default!;
    
    private IEnumerable<Square> GetMoves() =>
        Enumerable.Range(FileCoord.Dec, FileCoord.Inc - FileCoord.Dec + 1)
            .SelectMany(i => Enumerable.Range(RankCoord.Dec, RankCoord.Inc - RankCoord.Dec + 1)
                .Select(j => Square.At((File)i, (Rank)j)))
            .Where(s => s != Position);
}