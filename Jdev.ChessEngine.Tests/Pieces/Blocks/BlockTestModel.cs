namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

using Board;
using Enums;

public class BlockTestModel
{
    private readonly IEnumerable<ISquare>? _expectedCaptureBlock;
    public required ISquare Origin { get; init; }
    public required ISquare Destination { get; init; }
    public required IEnumerable<ISquare> ExpectedRelocationBlocks { get; init; }

    public IEnumerable<ISquare> ExpectedCaptureBlocks
    {
        get => _expectedCaptureBlock ?? ExpectedRelocationBlocks;
        init => _expectedCaptureBlock = value;
    }

    public Colour? Colour { get; init; }
}