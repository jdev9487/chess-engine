namespace Jdev.ChessEngine.Tests.Query.MoveType;

using Board;
using Enums;
using Jdev.ChessEngine.Pieces;

[TestFixture]
public class Promotion : MoveTypeBase
{
    [Test]
    [TestCaseSource(nameof(_promotionCases))]
    public void ShouldProduceWhitePromotion(File file)
    {
        PieceToMove = new Pawn { Colour = Colour.White };
        Destination = Square.At(file, Rank.Eight);
        var actual = GetMoveType();
        Assert.That(actual, Is.EqualTo(MoveType.Promotion));
    }
    
    [Test]
    [TestCaseSource(nameof(_promotionCases))]
    public void ShouldProduceBlackPromotion(File file)
    {
        PieceToMove = new Pawn { Colour = Colour.Black };
        Destination = Square.At(file, Rank.One);
        var actual = GetMoveType();
        Assert.That(actual, Is.EqualTo(MoveType.Promotion));
    }
    
    [Test]
    [TestCaseSource(nameof(_notPromotionCases))]
    public void ShouldNotProducePromotion(IPiece piece, ISquare destination)
    {
        PieceToMove = piece;
        Destination = destination;
        var actual = GetMoveType();
        Assert.That(actual, Is.Not.EqualTo(MoveType.Promotion));
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