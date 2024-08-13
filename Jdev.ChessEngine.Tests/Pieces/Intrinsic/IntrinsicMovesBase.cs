namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Board;
using Jdev.ChessEngine.Pieces;

public class IntrinsicMovesBase<TPiece>(IntrinsicTestModel model) where TPiece : IPiece, new()
{
    private TPiece _piece = default!;
    private Square[] _intrinsicRelocations = default!;
    private Square[] _intrinsicCaptures = default!;

    [SetUp]
    public void SetUp()
    {
        _piece = new TPiece
            { Position = model.StartingLocation, Colour = model.Colour.GetValueOrDefault(), HasMoved = model.HasMoved };
        _intrinsicRelocations = _piece.GetIntrinsicRelocations()
            .Select(mp => mp.Target)
            .ToArray();
        _intrinsicCaptures = _piece.GetIntrinsicCaptures()
            .Select(mp => mp.Target)
            .ToArray();
    }

    [Test]
    public void RelocationsShouldContainSquares() =>
        Assert.Multiple(() =>
        {
            foreach (var location in model.ExpectedIntrinsicRelocations)
            {
                Assert.That(_intrinsicRelocations, Contains.Item(location));
            }
        });

    [Test]
    public void RelocationsShouldOnlyHaveCorrectNumberOfSquares() =>
        Assert.That(_intrinsicRelocations, Has.Length.EqualTo(model.ExpectedIntrinsicRelocations.Count()));

    [Test]
    public void CapturesShouldContainSquares() =>
        Assert.Multiple(() =>
        {
            foreach (var location in model.ExpectedIntrinsicCaptures)
            {
                Assert.That(_intrinsicCaptures, Contains.Item(location));
            }
        });

    [Test]
    public void CapturesShouldOnlyHaveCorrectNumberOfSquares() =>
        Assert.That(_intrinsicCaptures, Has.Length.EqualTo(model.ExpectedIntrinsicCaptures.Count()));
}