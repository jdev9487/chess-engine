namespace Jdev.ChessEngine.Tests.Query;

using Moq;
using Board;
using Enums;
using ChessEngine.Pieces;

public class BlockedForCapture : QueryBase
{
    private Mock<IPiece> _pieceToMove = default!;
    private ISquare _destination = default!;
    private ISquare _blockingLocation = default!;
    
    [SetUp]
    public void BlockedForCaptureSetUp()
    {
        _destination = Square.At(File.F, Rank.Five);
        _blockingLocation = Square.At(File.G, Rank.Two);
        _pieceToMove = new Mock<IPiece>();
        _pieceToMove.SetupGet(x => x.Colour).Returns(Colour.White);
    }

    [Test]
    [TestCase(Colour.White)]
    [TestCase(Colour.Black)]
    public void ShouldBeBlocked(Colour colour)
    {
        _pieceToMove
            .Setup(x => x.GetPotentialCaptureBlocks(_destination))
            .Returns(new List<ISquare> { _blockingLocation });
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

        var actual = Query.IsPieceBlockedForCapture(_destination, _pieceToMove.Object);
        Assert.That(actual, Is.True);
    }
    
    [Test]
    public void ShouldBeBlockedDueToSameColourPieceAtDestination()
    {
        _pieceToMove
            .Setup(x => x.GetPotentialCaptureBlocks(_destination))
            .Returns(new List<ISquare> { _destination });
        var blockingPiece = new Mock<IPiece>();
        blockingPiece.SetupGet(x => x.Colour).Returns(Colour.White);
        PieceGroupMock
            .Setup(x => x.PieceAt(_destination.File, _destination.Rank))
            .Returns(blockingPiece.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _pieceToMove.Object,
                blockingPiece.Object
            });

        var actual = Query.IsPieceBlockedForCapture(_destination, _pieceToMove.Object);
        Assert.That(actual, Is.True);
    }
    
    [Test]
    public void ShouldNotBeBlockedDueToOppositeColourPieceAtDestination()
    {
        _pieceToMove
            .Setup(x => x.GetPotentialCaptureBlocks(_destination))
            .Returns(new List<ISquare> { _destination });
        var blockingPiece = new Mock<IPiece>();
        blockingPiece.SetupGet(x => x.Colour).Returns(Colour.Black);
        PieceGroupMock
            .Setup(x => x.PieceAt(_destination.File, _destination.Rank))
            .Returns(blockingPiece.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _pieceToMove.Object,
                blockingPiece.Object
            });

        var actual = Query.IsPieceBlockedForCapture(_destination, _pieceToMove.Object);
        Assert.That(actual, Is.False);
    }

    [Test]
    [TestCase(Colour.White)]
    [TestCase(Colour.Black)]
    public void ShouldNotBeBlocked(Colour colour)
    {
        _pieceToMove
            .Setup(x => x.GetPotentialCaptureBlocks(_destination))
            .Returns(new List<ISquare> { _blockingLocation });
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

        var actual = Query.IsPieceBlockedForCapture(_destination, _pieceToMove.Object);
        Assert.That(actual, Is.False);
    }
}