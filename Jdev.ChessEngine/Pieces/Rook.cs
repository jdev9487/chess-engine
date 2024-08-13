namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class Rook : BasePiece
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations()
    {
        var availableRankSquares = Rank.Enumerate
            .Where(r => r != Position.Rank)
            .Select(r => new MoveProposition
                { Target = Square.At(Position.File, r), SubsequentMove = MoveType.Standard });
        var availableFileSquares = File.Enumerate
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
    
    public override object Clone() => CloneObject<Rook>();

    public Square CastlingLocation { get; init; } = default!;

    public override string ToString() => Colour switch
    {
        Colour.White => "♖",
        Colour.Black => "♜",
        _ => throw new ArgumentOutOfRangeException()
    };
}