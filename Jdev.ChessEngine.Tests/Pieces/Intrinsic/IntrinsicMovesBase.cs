namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Models;
using Jdev.ChessEngine.Pieces;

public class IntrinsicMovesBase<TPiece>(IntrinsicTestModel model) where TPiece : BasePiece, new()
{
    private TPiece _piece = default!;
    private Square[] _intrinsic = default!;

    [SetUp]
    public void SetUp()
    {
        _piece = new TPiece { Position = model.StartingLocation };
        _intrinsic = _piece.GetIntrinsicRelocations()
            .Select(mp => mp.Target)
            .ToArray();
    }

    [Test]
    public void ShouldContainSquares()
    {
        Assert.Multiple(() =>
        {
            foreach (var location in model.ExpectedIntrinsicLocations)
            {
                AssertContains(location);
            }
        });
    }
    
    [Test]
    public void ShouldOnlyHaveCorrectNumberOfSquares() => ShouldHaveLength(model.ExpectedIntrinsicLocations.Count());
    
    private void AssertContains(Square location) =>
        Assert.That(_intrinsic, Contains.Item(location));

    private void ShouldHaveLength(int length) => Assert.That(_intrinsic, Has.Length.EqualTo(length));
}