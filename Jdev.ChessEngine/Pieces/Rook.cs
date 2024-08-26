namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class Rook : BasePiece, IRook
{
    public override IEnumerable<ISquare> GetIntrinsicRelocations()
    {
        var availableRankSquares = Rank.Enumerate
            .Where(r => r != Position.Rank)
            .Select(r => Square.At(Position.File, r));
        var availableFileSquares = File.Enumerate
            .Where(f => f != Position.File)
            .Select(f => Square.At(f, Position.Rank));
        return availableFileSquares.Concat(availableRankSquares).AsEnumerable();
    }

    public override IEnumerable<ISquare> GetIntrinsicCaptures() => GetIntrinsicRelocations();
    public override IEnumerable<ISquare> GetPotentialRelocationBlocks(ISquare destination) =>
        Position.GetStraightsInBetween(destination).Where(s => s != Position);

    public override IEnumerable<ISquare> GetPotentialCaptureBlocks(ISquare destination) =>
        GetPotentialRelocationBlocks(destination);
    
    public override object Clone() => CloneObject<Rook>();

    public bool HasMoved { get; set; }
    public ISquare CastlingLocation { get; init; } = default!;

    public override string ToString() => Colour switch
    {
        Colour.White => "♖",
        Colour.Black => "♜",
        _ => throw new ArgumentOutOfRangeException()
    };
}