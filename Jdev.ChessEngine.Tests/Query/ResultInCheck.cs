namespace Jdev.ChessEngine.Tests.Query;

using Moq;
using Board;
using Enums;
using Models;
using ChessEngine.Pieces;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class ResultInCheck(CheckTestModel model) : QueryBase
{
    private King _kingUnderQuestion = default!;
    private Square _kingOrigin = default!;
    private Square _kingDestination = default!;
    private Square _kingNotHere = default!;

    [SetUp]
    public void ResultInCheckSetUp()
    {
        _kingOrigin = Square.At(File.D, Rank.Four);
        _kingDestination = Square.At(File.E, Rank.Four);
        _kingNotHere = Square.At(File.C, Rank.Seven);
    }
    
    [Test]
    public void MovingKingIntoCheckShouldResultInCheck()
    {
        var checkingMock = new Mock<IPiece>();
        checkingMock.SetupGet(x => x.Colour).Returns(model.CheckingColour);
        checkingMock.Setup(x => x.GetIntrinsicCaptures()).Returns(new List<MoveProposition>
            { new() { Target = _kingDestination } });
        _kingUnderQuestion = new King { Colour = model.CheckedKingColour, Position = _kingOrigin };
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingUnderQuestion,
                checkingMock.Object
            });
        var actual = Query.WouldRequestResultInCheck(_kingDestination, _kingUnderQuestion);
        Assert.That(actual, Is.True);
    }
    
    [Test]
    public void NotMovingKingIntoCheckShouldNotResultInCheck()
    {
        var checkingMock = new Mock<IPiece>();
        checkingMock.SetupGet(x => x.Colour).Returns(model.CheckingColour);
        checkingMock.Setup(x => x.GetIntrinsicCaptures()).Returns(new List<MoveProposition>
            { new() { Target = _kingNotHere } });
        _kingUnderQuestion = new King { Colour = model.CheckedKingColour, Position = _kingOrigin };
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _kingUnderQuestion,
                checkingMock.Object
            });
        var actual = Query.WouldRequestResultInCheck(_kingDestination, _kingUnderQuestion);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void PieceGroupShouldBeUnalteredAfterCheck()
    {
        var checkingMock = new Mock<IPiece>();
        checkingMock.SetupGet(x => x.Colour).Returns(model.CheckingColour);
        checkingMock.Setup(x => x.GetIntrinsicCaptures()).Returns(new List<MoveProposition>
            { new() { Target = _kingNotHere } });
        _kingUnderQuestion = new King { Colour = model.CheckedKingColour, Position = _kingOrigin };
        var pawnAtKingDestination = new Pawn { Colour = model.CheckingColour, Position = _kingDestination };
        var pieces = new List<IPiece>
        {
            _kingUnderQuestion,
            checkingMock.Object,
            pawnAtKingDestination
        };
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(pieces);
        Query.WouldRequestResultInCheck(_kingDestination, _kingUnderQuestion);
        Assert.Multiple(() =>
        {
            Assert.That(_kingUnderQuestion.Position, Is.SameAs(_kingOrigin));
            Assert.That(pawnAtKingDestination.Position, Is.SameAs(_kingDestination));
        });
    }

    public static readonly object[] Cases =
    [
        new CheckTestModel { CheckingColour = Colour.Black, CheckedKingColour = Colour.White },
        new CheckTestModel { CheckingColour = Colour.White, CheckedKingColour = Colour.Black }
    ];
}