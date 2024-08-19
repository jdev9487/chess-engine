namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Models;

using Board;
using Enums;
using Jdev.ChessEngine.Pieces;

public abstract class BlockTestModelBase<TPiece> where TPiece : IPiece
{
    public abstract TPiece CreatePiece();
    public Colour? Colour { get; init; }
    public bool HasMoved { get; init; } = true;
    public required ISquare Origin { get; init; }
    public required ISquare Destination { get; init; }
    public required IEnumerable<ISquare> ExpectedRelocationBlocks { get; init; }

    private readonly IEnumerable<ISquare>? _expectedCaptureBlock;
    public IEnumerable<ISquare> ExpectedCaptureBlocks
    {
        get => _expectedCaptureBlock ?? ExpectedRelocationBlocks;
        init => _expectedCaptureBlock = value;
    }
}