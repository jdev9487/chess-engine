namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Board;
using Enums;

public class IntrinsicTestModel
{
    private readonly IEnumerable<Square>? _expectedIntrinsicCaptures;
    public required Square StartingLocation { get; init; }
    public required IEnumerable<Square> ExpectedIntrinsicRelocations { get; init; }

    public IEnumerable<Square> ExpectedIntrinsicCaptures
    {
        get => _expectedIntrinsicCaptures ?? ExpectedIntrinsicRelocations;
        init => _expectedIntrinsicCaptures = value;
    }

    public Colour? Colour { get; init; }
}