namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public abstract class BasePiece : IPiece
{
    public abstract IEnumerable<MoveProposition> GetIntrinsicRelocations();
    public abstract IEnumerable<MoveProposition> GetIntrinsicCaptures();
    public abstract IEnumerable<ISquare> GetPotentialRelocationBlocks(ISquare destination);
    public abstract IEnumerable<ISquare> GetPotentialCaptureBlocks(ISquare destination);

    public abstract object Clone();

    public Colour Colour { get; init; }
    public ISquare Position { get; set; } = default!;
    public bool IsAlive { get; set; } = true;
    public virtual bool HasMoved { get; set; } = false;

    protected T CloneObject<T>() where T : IPiece, new() =>
        new()
        {
            Colour = Colour,
            HasMoved = HasMoved,
            IsAlive = IsAlive,
            Position = Position
        };
}