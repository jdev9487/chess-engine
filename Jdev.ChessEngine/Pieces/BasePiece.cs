namespace Jdev.ChessEngine.Pieces;

using Enums;
using Models;

public class BasePiece
{
    public Colour Colour { get; init; }
    public Square Position { get; set; } = default!;
    public bool IsAlive { get; set; } = true;
}