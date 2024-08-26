namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public abstract class BasePiece : IPiece
{
    public abstract IEnumerable<ISquare> GetIntrinsicRelocations();
    public abstract IEnumerable<ISquare> GetIntrinsicCaptures();
    public abstract IEnumerable<ISquare> GetPotentialRelocationBlocks(ISquare destination);
    public abstract IEnumerable<ISquare> GetPotentialCaptureBlocks(ISquare destination);

    public abstract object Clone();

    public Colour Colour { get; init; }
    public ISquare Position { get; set; } = default!;

    protected T CloneObject<T>() where T : IPiece, new() =>
        new()
        {
            Colour = Colour,
            Position = Position
        };
}