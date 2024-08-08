namespace Jdev.ChessEngine.Interfaces;

using Enums;
using Models;

public interface IPiece
{
    Colour Colour { get; }
    IEnumerable<MoveProposition> GetIntrinsicRelocations();
    IEnumerable<MoveProposition> GetIntrinsicCaptures();
    Square Position { get; set; }
    List<Square> GetPotentialBlocks(Square destination);
    bool IsAlive { get; set; }
}