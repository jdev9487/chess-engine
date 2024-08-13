namespace Jdev.ChessEngine.Tests.Query;

using Board;
using Enums;
using Models;
using ChessEngine.Pieces;
using Moq;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Check(CheckTestModel model) : QueryBase
{
    private King _checkedKing = default!;
    
    [SetUp]
    public void CheckSetUp()
    {
        _checkedKing = new King { Colour = model.CheckedKingColour, Position = Square.At(File.E, Rank.One) };
        PieceGroupMock
            .Setup(x => x.King(model.CheckedKingColour))
            .Returns(_checkedKing);
    }

    [Test]
    public void ShouldDeemKingToBeInCheckFromQueen()
    {
        var queenMock = new Mock<IPiece>();
        queenMock.SetupGet(x => x.Colour).Returns(model.CheckingColour);
        queenMock
            .Setup(x => x.GetIntrinsicCaptures())
            .Returns(new List<MoveProposition> { new() { Target = _checkedKing.Position } });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                _checkedKing,
                queenMock.Object
            });
        var actual = Query.IsInCheck(model.CheckedKingColour);
        Assert.That(actual, Is.True);
    }

    public static readonly object[] Cases =
    [
        new CheckTestModel { CheckingColour = Colour.Black, CheckedKingColour = Colour.White },
        new CheckTestModel { CheckingColour = Colour.White, CheckedKingColour = Colour.Black }
    ];
}