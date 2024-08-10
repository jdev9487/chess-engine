namespace Jdev.ChessEngine.Pieces;

using Enums;
using Models;

public class Rook : BasePiece
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations()
    {
        var availableRankSquares = Enum.GetValues<Rank>()
            .Where(r => r != Position.Rank)
            .Select(r => new MoveProposition
                { Target = Square.At(Position.File, r), SubsequentMove = MoveType.Standard });
        var availableFileSquares = Enum.GetValues<File>()
            .Where(f => f != Position.File)
            .Select(f => new MoveProposition
                { Target = Square.At(f, Position.Rank), SubsequentMove = MoveType.Standard });
        return availableFileSquares.Concat(availableRankSquares).AsEnumerable();
    }

    public override IEnumerable<MoveProposition> GetIntrinsicCaptures() => GetIntrinsicRelocations();

    public override List<Square> GetPotentialBlocks(Square destination)
    {
        throw new NotImplementedException();
    }

    public Square CastlingLocation { get; init; } = default!;
}