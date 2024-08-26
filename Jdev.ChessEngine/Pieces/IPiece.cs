namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public interface IPiece : ICloneable
{
    IEnumerable<ISquare> GetIntrinsicRelocations();
    IEnumerable<ISquare> GetIntrinsicCaptures();
    IEnumerable<ISquare> GetPotentialRelocationBlocks(ISquare destination);
    IEnumerable<ISquare> GetPotentialCaptureBlocks(ISquare destination);
    Colour Colour { get; init; }
    ISquare Position { get; set; }
}