namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

using Board;
using Jdev.ChessEngine.Pieces;

public class BlockMovesBase<TPiece>(BlockTestModel model) where TPiece : IPiece, new()
{
    private TPiece _piece = default!;
    private ISquare[] _relocationBlocks = default!;
    private ISquare[] _captureBlocks = default!;

    [SetUp]
    public void SetUp()
    {
        _piece = new TPiece
            { Position = model.Origin, Colour = model.Colour.GetValueOrDefault() };
        _relocationBlocks = _piece.GetPotentialRelocationBlocks(model.Destination)
            .ToArray();
        _captureBlocks = _piece.GetPotentialCaptureBlocks(model.Destination)
            .ToArray();
    }

    [Test]
    public void RelocationBlockShouldContainSquares() =>
        Assert.Multiple(() =>
        {
            foreach (var location in model.ExpectedRelocationBlocks)
            {
                Assert.That(_relocationBlocks, Contains.Item(location));
            }
        });

    [Test]
    public void RelocationBlocksShouldHaveCorrectNumberOfSquares() =>
        Assert.That(_relocationBlocks, Has.Length.EqualTo(model.ExpectedRelocationBlocks.Count()));

    [Test]
    public void CaptureBlocksShouldContainSquares() =>
        Assert.Multiple(() =>
        {
            foreach (var location in model.ExpectedCaptureBlocks)
            {
                Assert.That(_captureBlocks, Contains.Item(location));
            }
        });

    [Test]
    public void CaptureBlocksShouldHaveCorrectNumberOfSquares() =>
        Assert.That(_captureBlocks, Has.Length.EqualTo(model.ExpectedCaptureBlocks.Count()));
}