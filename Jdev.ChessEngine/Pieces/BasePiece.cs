namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public abstract class BasePiece : IPiece
{
    public abstract IEnumerable<MoveProposition> GetIntrinsicRelocations();
    public abstract IEnumerable<MoveProposition> GetIntrinsicCaptures();
    public abstract IEnumerable<Square> GetPotentialBlocks(Square destination);
    public abstract object Clone();

    public Colour Colour { get; init; }
    public Square Position { get; set; } = default!;
    public bool IsAlive { get; set; } = true;
    public bool HasMoved { get; set; } = false;

    protected T CloneObject<T>() where T : IPiece, new() =>
        new()
        {
            Colour = Colour,
            HasMoved = HasMoved,
            IsAlive = IsAlive,
            Position = Position
        };
}