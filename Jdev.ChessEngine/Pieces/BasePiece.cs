namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public abstract class BasePiece
{
    public abstract IEnumerable<MoveProposition> GetIntrinsicRelocations();
    public abstract IEnumerable<MoveProposition> GetIntrinsicCaptures();
    public abstract IEnumerable<Square> GetPotentialBlocks(Square destination);
    
    public Colour Colour { get; init; }

    public Square Position { get; set; } = default!;

    public bool IsAlive { get; set; } = true;
    public bool HasMoved { get; set; } = false;
}