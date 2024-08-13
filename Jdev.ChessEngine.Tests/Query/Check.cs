namespace Jdev.ChessEngine.Tests.Query;

using Board;
using Enums;
using ChessEngine.Pieces;
using Models;

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
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<BasePiece>
            {
                _checkedKing,
                new Queen { Colour = model.CheckingColour, Position = Square.At(File.G, Rank.Three) }
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