namespace Jdev.ChessEngine.Interfaces;

using Models;

public interface IPiece
{
    IEnumerable<MoveProposition> GetIntrinsicMoves();
    Square Position { get; set; }
    List<Square> GetPotentialBlocks(Square destination);
    bool IsAlive { get; set; }
}