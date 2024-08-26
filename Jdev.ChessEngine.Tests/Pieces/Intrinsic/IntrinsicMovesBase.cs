namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Board;
using Jdev.ChessEngine.Pieces;
using Models;

public class IntrinsicMovesBase<TPiece>(IntrinsicTestModelBase<TPiece> model) where TPiece : IPiece, new()
{
    private TPiece _piece = default!;
    private ISquare[] _intrinsicRelocations = default!;
    private ISquare[] _intrinsicCaptures = default!;

    [SetUp]
    public void SetUp()
    {
        _piece = model.CreatePiece();
        _intrinsicRelocations = _piece.GetIntrinsicRelocations().ToArray();
        _intrinsicCaptures = _piece.GetIntrinsicCaptures().ToArray();
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