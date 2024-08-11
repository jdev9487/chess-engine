namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Board;
using Models;

public class IntrinsicTestModel
{
    public Square StartingLocation { get; set; } = default!;
    public IEnumerable<Square> ExpectedIntrinsicLocations { get; set; } = default!;
}