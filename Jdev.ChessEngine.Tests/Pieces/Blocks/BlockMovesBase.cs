namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

using Board;
using Jdev.ChessEngine.Pieces;
using Models;

public class BlockMovesBase<TPiece>(BlockTestModelBase<TPiece> modelBase) where TPiece : IPiece
{
    private TPiece _piece = default!;
    private ISquare[] _relocationBlocks = default!;
    private ISquare[] _captureBlocks = default!;

    [SetUp]
    public void SetUp()
    {
        _piece = modelBase.CreatePiece();
        _piece.Position = modelBase.Origin;
        _relocationBlocks = _piece.GetPotentialRelocationBlocks(modelBase.Destination)
            .ToArray();
        _captureBlocks = _piece.GetPotentialCaptureBlocks(modelBase.Destination)
            .ToArray();
    }

    [Test]
    public void RelocationBlockShouldContainSquares() =>
        Assert.Multiple(() =>
        {
            foreach (var location in modelBase.ExpectedRelocationBlocks)
            {
                Assert.That(_relocationBlocks, Contains.Item(location));
            }
        });

    [Test]
    public void RelocationBlocksShouldHaveCorrectNumberOfSquares() =>
        Assert.That(_relocationBlocks, Has.Length.EqualTo(modelBase.ExpectedRelocationBlocks.Count()));

    [Test]
    public void CaptureBlocksShouldContainSquares() =>
        Assert.Multiple(() =>
        {
            foreach (var location in modelBase.ExpectedCaptureBlocks)
            {
                Assert.That(_captureBlocks, Contains.Item(location));
            }
        });

    [Test]
    public void CaptureBlocksShouldHaveCorrectNumberOfSquares() =>
        Assert.That(_captureBlocks, Has.Length.EqualTo(modelBase.ExpectedCaptureBlocks.Count()));
}