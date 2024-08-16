namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public interface IPiece : ICloneable
{
    IEnumerable<MoveProposition> GetIntrinsicRelocations();
    IEnumerable<MoveProposition> GetIntrinsicCaptures();
    IEnumerable<ISquare> GetPotentialRelocationBlocks(ISquare destination);
    IEnumerable<ISquare> GetPotentialCaptureBlocks(ISquare destination);
    Colour Colour { get; init; }
    ISquare Position { get; set; }
    bool IsAlive { get; set; }
    bool HasMoved { get; set; }
}