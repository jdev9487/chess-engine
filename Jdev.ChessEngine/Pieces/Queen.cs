namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class Queen : BasePiece
{
    public override IEnumerable<ISquare> GetIntrinsicRelocations() => GetMoves();

    public override IEnumerable<ISquare> GetIntrinsicCaptures() => GetIntrinsicRelocations();
    public override IEnumerable<ISquare> GetPotentialRelocationBlocks(ISquare destination) =>
        Position.GetDiagonalsInBetween(destination)
            .Concat(Position.GetStraightsInBetween(destination))
            .Where(s => s != Position);

    public override IEnumerable<ISquare> GetPotentialCaptureBlocks(ISquare destination) =>
        GetPotentialRelocationBlocks(destination);
    
    public override object Clone() => CloneObject<Queen>();

    private IEnumerable<ISquare> GetMoves() => Position.GetEnclosingRank()
        .Concat(Position.GetEnclosingFile())
        .Concat(Position.GetEnclosingPositiveDiagonal())
        .Concat(Position.GetEnclosingNegativeDiagonal())
        .Where(s => s != Position);

    public override string ToString() => Colour switch
    {
        Colour.White => "♕",
        Colour.Black => "♛",
        _ => throw new ArgumentOutOfRangeException()
    };
}