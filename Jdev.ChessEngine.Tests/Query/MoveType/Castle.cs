namespace Jdev.ChessEngine.Tests.Query.MoveType;

using Board;
using Enums;
using Jdev.ChessEngine.Pieces;

[TestFixture]
public class Castle : MoveTypeBase
{
    [Test]
    public void ShouldProductWhiteKingsideCastle()
    {
        PieceToMove = new King { Colour = Colour.White, HasMoved = false };
        Destination = Square.At(File.G, Rank.One);
        var actual = GetMoveType();
        Assert.That(actual, Is.EqualTo(MoveType.Castle));
    }

    [Test]
    public void ShouldProductWhiteQueensideCastle()
    {
        PieceToMove = new King { Colour = Colour.White, HasMoved = false };
        Destination = Square.At(File.C, Rank.One);
        var actual = GetMoveType();
        Assert.That(actual, Is.EqualTo(MoveType.Castle));
    }

    [Test]
    public void ShouldProductBlackKingsideCastle()
    {
        PieceToMove = new King { Colour = Colour.Black, HasMoved = false };
        Destination = Square.At(File.G, Rank.Eight);
        var actual = GetMoveType();
        Assert.That(actual, Is.EqualTo(MoveType.Castle));
    }

    [Test]
    public void ShouldProductBlackQueensideCastle()
    {
        PieceToMove = new King { Colour = Colour.Black, HasMoved = false };
        Destination = Square.At(File.C, Rank.Eight);
        var actual = GetMoveType();
        Assert.That(actual, Is.EqualTo(MoveType.Castle));
    }
}