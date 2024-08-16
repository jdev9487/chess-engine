namespace Jdev.ChessEngine.Tests.Query;

using Board;
using Enums;
using ChessEngine.Pieces;

[TestFixture]
public class MoveType : QueryBase
{
    [Test]
    [TestCaseSource(nameof(_promotionCases))]
    public void ShouldProduceWhitePromotion(File file)
    {
        var piece = new Pawn { Colour = Colour.White };
        var destination = Square.At(file, Rank.Eight);
        var actual = Query.GetMoveType(destination, piece);
        Assert.That(actual, Is.EqualTo(Enums.MoveType.Promotion));
    }
    
    [Test]
    [TestCaseSource(nameof(_promotionCases))]
    public void ShouldProduceBlackPromotion(File file)
    {
        var piece = new Pawn { Colour = Colour.Black };
        var destination = Square.At(file, Rank.One);
        var actual = Query.GetMoveType(destination, piece);
        Assert.That(actual, Is.EqualTo(Enums.MoveType.Promotion));
    }
    
    [Test]
    [TestCaseSource(nameof(_notPromotionCases))]
    public void ShouldNotProducePromotion(IPiece piece, ISquare destination)
    {
        var actual = Query.GetMoveType(destination, piece);
        Assert.That(actual, Is.Not.EqualTo(Enums.MoveType.Promotion));
    }

    [Test]
    public void ShouldProductWhiteKingsideCastle()
    {
        var piece = new King { Colour = Colour.White, HasMoved = false };
        var destination = Square.At(File.G, Rank.One);
        var actual = Query.GetMoveType(destination, piece);
        Assert.That(actual, Is.EqualTo(Enums.MoveType.Castle));
    }

    [Test]
    public void ShouldProductWhiteQueensideCastle()
    {
        var piece = new King { Colour = Colour.White, HasMoved = false };
        var destination = Square.At(File.C, Rank.One);
        var actual = Query.GetMoveType(destination, piece);
        Assert.That(actual, Is.EqualTo(Enums.MoveType.Castle));
    }

    [Test]
    public void ShouldProductBlackKingsideCastle()
    {
        var piece = new King { Colour = Colour.Black, HasMoved = false };
        var destination = Square.At(File.G, Rank.Eight);
        var actual = Query.GetMoveType(destination, piece);
        Assert.That(actual, Is.EqualTo(Enums.MoveType.Castle));
    }

    [Test]
    public void ShouldProductBlackQueensideCastle()
    {
        var piece = new King { Colour = Colour.Black, HasMoved = false };
        var destination = Square.At(File.C, Rank.Eight);
        var actual = Query.GetMoveType(destination, piece);
        Assert.That(actual, Is.EqualTo(Enums.MoveType.Castle));
    }

    private static object[] _promotionCases =
    [
        File.A,
        File.B,
        File.C,
        File.D,
        File.E,
        File.F,
        File.G,
        File.H
    ];

    private static object[] _notPromotionCases =
    [
        new object[] { new King { Colour = Colour.White }, Square.At(File.F, Rank.Eight) },
        new object[] { new King { Colour = Colour.Black }, Square.At(File.F, Rank.One) },
        new object[] { new Queen { Colour = Colour.White }, Square.At(File.F, Rank.Eight) },
        new object[] { new Queen { Colour = Colour.Black }, Square.At(File.F, Rank.One) },
        new object[] { new Rook { Colour = Colour.White }, Square.At(File.F, Rank.Eight) },
        new object[] { new Rook { Colour = Colour.Black }, Square.At(File.F, Rank.One) },
        new object[] { new Bishop { Colour = Colour.White }, Square.At(File.F, Rank.Eight) },
        new object[] { new Bishop { Colour = Colour.Black }, Square.At(File.F, Rank.One) },
        new object[] { new Knight { Colour = Colour.White }, Square.At(File.F, Rank.Eight) },
        new object[] { new Knight { Colour = Colour.Black }, Square.At(File.F, Rank.One) }
    ];
}