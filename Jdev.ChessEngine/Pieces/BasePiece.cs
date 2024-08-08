namespace Jdev.ChessEngine.Pieces;

using Models;

public class BasePiece
{
    public Square Position { get; set; } = default!;
    public bool IsAlive { get; set; }
}