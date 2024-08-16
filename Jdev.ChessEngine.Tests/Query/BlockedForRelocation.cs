namespace Jdev.ChessEngine.Tests.Query;

using Moq;
using Board;
using Enums;
using ChessEngine.Pieces;

public class BlockedForRelocation : QueryBase
{
    private Mock<IPiece> _pieceToMove = default!;
    private ISquare _destination = default!;
    private ISquare _blockingLocation = default!;
    
    [SetUp]
    public void BlockedForRelocationSetUp()
    {
        _destination = Square.At(File.F, Rank.Five);
        _blockingLocation = Square.At(File.G, Rank.Two);
        _pieceToMove = new Mock<IPiece>();
        _pieceToMove.SetupGet(x => x.Colour).Returns(Colour.White);
        _pieceToMove
            .Setup(x => x.GetPotentialRelocationBlocks(_destination))
            .Returns(new List<ISquare> { _blockingLocation });
    }

    [Test]
    [TestCase(Colour.White)]
    [TestCase(Colour.Black)]
    public void ShouldBeBlocked(Colour colour)
    {
        var blockingPiece = new Mock<IPiece>();
        blockingPiece.SetupGet(x => x.Colour).Returns(colour);
        PieceGroupMock
            .Setup(x => x.PieceAt(_blockingLocation.File, _blockingLocation.Rank))
            .Returns(blockingPiece.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _pieceToMove.Object,
                blockingPiece.Object
            });

        var actual = Query.IsPieceBlockedForRelocation(_destination, _pieceToMove.Object);
        Assert.That(actual, Is.True);
    }

    [Test]
    [TestCase(Colour.White)]
    [TestCase(Colour.Black)]
    public void ShouldNotBeBlocked(Colour colour)
    {
        var blockingPiece = new Mock<IPiece>();
        blockingPiece.SetupGet(x => x.Colour).Returns(colour);
        PieceGroupMock
            .Setup(x => x.PieceAt(_blockingLocation.File, _blockingLocation.Rank))
            .Returns((IPiece)null!);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _pieceToMove.Object,
                blockingPiece.Object
            });

        var actual = Query.IsPieceBlockedForRelocation(_destination, _pieceToMove.Object);
        Assert.That(actual, Is.False);
    }
}