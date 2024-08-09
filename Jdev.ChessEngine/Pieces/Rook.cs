namespace Jdev.ChessEngine.Pieces;

using Enums;
using Models;
using Interfaces;

public class Rook : BasePiece, IPiece
{
    public IEnumerable<MoveProposition> GetIntrinsicRelocations()
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

    public IEnumerable<MoveProposition> GetIntrinsicCaptures() => GetIntrinsicRelocations();

    public List<Square> GetPotentialBlocks(Square destination)
    {
        throw new NotImplementedException();
    }

    public Square CastlingLocation { get; init; } = default!;

    private bool HasMoved { get; set; }
}