namespace Jdev.ChessEngine.Tests.Query;

using Moq;
using Board;
using Enums;
using ChessEngine.Pieces;

[TestFixture]
public class Castling : QueryBase
{
    private Mock<IRook> _rookMock;
    private Mock<IKing> _kingMock;
    
    [SetUp]
    public void CastlingSetUp()
    {
        _rookMock = new Mock<IRook>();
        _kingMock = new Mock<IKing>();
    }
    
    [Test]
    public void WhiteKingShouldNotCastleKingsideDueToKingAlreadyHavingMoved()
    {
        _kingMock.SetupGet(x => x.HasMoved).Returns(true);
        PieceGroupMock.SetupGet(x => x.Pieces).Returns(new List<IPiece> { _kingMock.Object });
        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.One));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    public void WhiteKingShouldNotCastleKingsideDueToRookAlreadyHavingMoved()
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.H, Rank.One));
        _rookMock.SetupGet(x => x.HasMoved).Returns(true);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.G, Rank.One))).Returns(_rookMock.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object
            });
        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.One));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(_whiteKingsideBlocks))]
    public void WhiteKingShouldNotCastleKingsideDueToBlocks(ISquare block)
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.H, Rank.One));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.One));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.G, Rank.One))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.White });
        var blockingMock = new Mock<IPiece>();
        PieceGroupMock.Setup(x => x.PieceAt(block.File, block.Rank)).Returns(blockingMock.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object,
                blockingMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.One));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(_whiteKingsideIntermediaryChecks))]
    public void WhiteKingShouldNotCastleKingsideDueToIntermediaryChecks(ISquare intermediaryCheck)
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.H, Rank.One));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.One));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.G, Rank.One))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.White });
        var checkingMock = new Mock<IPiece>();
        checkingMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        checkingMock
            .Setup(x => x.GetIntrinsicCaptures())
            .Returns(new List<MoveProposition>
            {
                new() { Target = intermediaryCheck }
            });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object,
                checkingMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.One));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    public void WhiteKingShouldCastleKingside()
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.H, Rank.One));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.One));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.G, Rank.One))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.White });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.One));
        Assert.That(actual, Is.True);
    }
    
    [Test]
    public void WhiteKingShouldNotCastleQueensideDueToKingAlreadyHavingMoved()
    {
        _kingMock.SetupGet(x => x.HasMoved).Returns(true);
        PieceGroupMock.SetupGet(x => x.Pieces).Returns(new List<IPiece> { _kingMock.Object });
        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.C, Rank.One));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    public void WhiteKingShouldNotCastleQueensideDueToRookAlreadyHavingMoved()
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.A, Rank.One));
        _rookMock.SetupGet(x => x.HasMoved).Returns(true);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.C, Rank.One))).Returns(_rookMock.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object
            });
        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.C, Rank.One));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(_whiteQueensideBlocks))]
    public void WhiteKingShouldNotCastleQueensideDueToBlocks(ISquare block)
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.A, Rank.One));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.One));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.C, Rank.One))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.White });
        var blockingMock = new Mock<IPiece>();
        PieceGroupMock.Setup(x => x.PieceAt(block.File, block.Rank)).Returns(blockingMock.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object,
                blockingMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.C, Rank.One));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(_whiteQueensideIntermediaryChecks))]
    public void WhiteKingShouldNotCastleQueensideDueToIntermediaryChecks(ISquare intermediaryCheck)
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.A, Rank.One));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.One));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.C, Rank.One))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.White });
        var checkingMock = new Mock<IPiece>();
        checkingMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        checkingMock
            .Setup(x => x.GetIntrinsicCaptures())
            .Returns(new List<MoveProposition>
            {
                new() { Target = intermediaryCheck }
            });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object,
                checkingMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.One));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    public void WhiteKingShouldCastleQueenside()
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.A, Rank.One));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.One));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.White);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.C, Rank.One))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.White });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.C, Rank.One));
        Assert.That(actual, Is.True);
    }
    
    [Test]
    public void BlackKingShouldNotCastleKingsideDueToKingAlreadyHavingMoved()
    {
        _kingMock.SetupGet(x => x.HasMoved).Returns(true);
        PieceGroupMock.SetupGet(x => x.Pieces).Returns(new List<IPiece> { _kingMock.Object });
        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.Eight));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    public void BlackKingShouldNotCastleKingsideDueToRookAlreadyHavingMoved()
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.H, Rank.Eight));
        _rookMock.SetupGet(x => x.HasMoved).Returns(true);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.G, Rank.Eight))).Returns(_rookMock.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object
            });
        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.Eight));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(_blackKingsideBlocks))]
    public void BlackKingShouldNotCastleKingsideDueToBlocks(ISquare block)
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.H, Rank.Eight));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.Eight));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.G, Rank.Eight))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.Black });
        var blockingMock = new Mock<IPiece>();
        PieceGroupMock.Setup(x => x.PieceAt(block.File, block.Rank)).Returns(blockingMock.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object,
                blockingMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.Eight));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(_blackKingsideIntermediaryChecks))]
    public void BlackKingShouldNotCastleKingsideDueToIntermediaryChecks(ISquare intermediaryCheck)
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.H, Rank.Eight));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.Eight));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.G, Rank.Eight))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.Black });
        var checkingMock = new Mock<IPiece>();
        checkingMock.SetupGet(x => x.Colour).Returns(Colour.White);
        checkingMock
            .Setup(x => x.GetIntrinsicCaptures())
            .Returns(new List<MoveProposition>
            {
                new() { Target = intermediaryCheck }
            });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object,
                checkingMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.Eight));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    public void BlackKingShouldCastleKingside()
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.H, Rank.Eight));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.Eight));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.G, Rank.Eight))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.Black });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.Eight));
        Assert.That(actual, Is.True);
    }
    
    [Test]
    public void BlackKingShouldNotCastleQueensideDueToKingAlreadyHavingMoved()
    {
        _kingMock.SetupGet(x => x.HasMoved).Returns(true);
        PieceGroupMock.SetupGet(x => x.Pieces).Returns(new List<IPiece> { _kingMock.Object });
        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.C, Rank.Eight));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    public void BlackKingShouldNotCastleQueensideDueToRookAlreadyHavingMoved()
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.A, Rank.Eight));
        _rookMock.SetupGet(x => x.HasMoved).Returns(true);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.C, Rank.Eight))).Returns(_rookMock.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object
            });
        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.C, Rank.Eight));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(_blackQueensideBlocks))]
    public void BlackKingShouldNotCastleQueensideDueToBlocks(ISquare block)
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.A, Rank.Eight));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.Eight));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.C, Rank.Eight))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.Black });
        var blockingMock = new Mock<IPiece>();
        PieceGroupMock.Setup(x => x.PieceAt(block.File, block.Rank)).Returns(blockingMock.Object);
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object,
                blockingMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.C, Rank.Eight));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    [TestCaseSource(nameof(_blackQueensideIntermediaryChecks))]
    public void BlackKingShouldNotCastleQueensideDueToIntermediaryChecks(ISquare intermediaryCheck)
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.A, Rank.Eight));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.Eight));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.C, Rank.Eight))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.Black });
        var checkingMock = new Mock<IPiece>();
        checkingMock.SetupGet(x => x.Colour).Returns(Colour.White);
        checkingMock
            .Setup(x => x.GetIntrinsicCaptures())
            .Returns(new List<MoveProposition>
            {
                new() { Target = intermediaryCheck }
            });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object,
                checkingMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.G, Rank.Eight));
        Assert.That(actual, Is.False);
    }
    
    [Test]
    public void BlackKingShouldCastleQueenside()
    {
        _rookMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _rookMock.SetupGet(x => x.Position).Returns(Square.At(File.A, Rank.Eight));
        _rookMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.Eight));
        _kingMock.SetupGet(x => x.Colour).Returns(Colour.Black);
        _kingMock.SetupGet(x => x.HasMoved).Returns(false);
        _kingMock.Setup(x => x.GetCastlingRook(Square.At(File.C, Rank.Eight))).Returns(_rookMock.Object);
        _kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.Black });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingMock.Object,
                _rookMock.Object
            });

        var actual = Query.CanKingCastle(_kingMock.Object, Square.At(File.C, Rank.Eight));
        Assert.That(actual, Is.True);
    }

    private static object[] _whiteKingsideBlocks =
    [
        Square.At(File.F, Rank.One),
        Square.At(File.G, Rank.One)
    ];
    private static object[] _whiteKingsideIntermediaryChecks =
    [
        Square.At(File.F, Rank.One),
        Square.At(File.G, Rank.One)
    ];
    private static object[] _whiteQueensideBlocks =
    [
        Square.At(File.C, Rank.One),
        Square.At(File.D, Rank.One),
        Square.At(File.B, Rank.One)
    ];
    private static object[] _whiteQueensideIntermediaryChecks =
    [
        Square.At(File.C, Rank.One),
        Square.At(File.D, Rank.One)
    ];
    private static object[] _blackKingsideBlocks =
    [
        Square.At(File.F, Rank.Eight),
        Square.At(File.G, Rank.Eight)
    ];
    private static object[] _blackKingsideIntermediaryChecks =
    [
        Square.At(File.F, Rank.Eight),
        Square.At(File.G, Rank.Eight)
    ];
    private static object[] _blackQueensideBlocks =
    [
        Square.At(File.C, Rank.Eight),
        Square.At(File.D, Rank.Eight),
        Square.At(File.B, Rank.Eight)
    ];
    private static object[] _blackQueensideIntermediaryChecks =
    [
        Square.At(File.C, Rank.Eight),
        Square.At(File.D, Rank.Eight)
    ];
}