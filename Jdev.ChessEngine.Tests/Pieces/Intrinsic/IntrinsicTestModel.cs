namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Board;
using Enums;

public class IntrinsicTestModel
{
    private readonly IEnumerable<ISquare>? _expectedIntrinsicCaptures;
    public required ISquare StartingLocation { get; init; }
    public required IEnumerable<ISquare> ExpectedIntrinsicRelocations { get; init; }

    public IEnumerable<ISquare> ExpectedIntrinsicCaptures
    {
        get => _expectedIntrinsicCaptures ?? ExpectedIntrinsicRelocations;
        init => _expectedIntrinsicCaptures = value;
    }

    public Colour? Colour { get; init; }
    public bool HasMoved { get; init; } = true;
}