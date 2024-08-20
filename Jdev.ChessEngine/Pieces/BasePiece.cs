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
    public virtual ISquare Position { get; set; } = default!;
    public bool IsAlive { get; set; } = true;

    protected T CloneObject<T>() where T : IPiece, new() =>
        new()
        {
            Colour = Colour,
            IsAlive = IsAlive,
            Position = Position
        };
}