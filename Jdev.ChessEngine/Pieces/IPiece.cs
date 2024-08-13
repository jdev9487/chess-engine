namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public interface IPiece
{
    IEnumerable<MoveProposition> GetIntrinsicRelocations();
    IEnumerable<MoveProposition> GetIntrinsicCaptures();
    IEnumerable<Square> GetPotentialBlocks(Square destination);
    Colour Colour { get; init; }
    Square Position { get; set; }
    bool IsAlive { get; set; }
    bool HasMoved { get; set; }
}