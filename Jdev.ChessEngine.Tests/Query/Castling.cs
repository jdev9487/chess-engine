namespace Jdev.ChessEngine.Tests.Query;

using Moq;
using Board;
using Enums;
using ChessEngine.Pieces;

[TestFixture]
public class Castling : QueryBase
{
    [Test]
    public void WhiteKingShouldCastleKingside()
    {
        var rookMock = new Mock<IRook>();
        rookMock.SetupGet(x => x.Colour).Returns(Colour.White);
        rookMock.SetupGet(x => x.Position).Returns(Square.At(File.H, Rank.One));
        rookMock.SetupGet(x => x.HasMoved).Returns(false);
        var kingMock = new Mock<IKing>();
        kingMock.SetupGet(x => x.Position).Returns(Square.At(File.E, Rank.One));
        kingMock.SetupGet(x => x.Colour).Returns(Colour.White);
        kingMock.SetupGet(x => x.HasMoved).Returns(false);
        kingMock.Setup(x => x.GetCastlingRook(Square.At(File.G, Rank.One))).Returns(rookMock.Object);
        kingMock.Setup(x => x.Clone()).Returns(new King { Colour = Colour.White });
        PieceGroupMock
            .SetupGet(x => x.Pieces)
            .Returns(new List<IPiece>
            {
                kingMock.Object,
                rookMock.Object
            });

        var actual = Query.CanKingCastle(kingMock.Object, Square.At(File.G, Rank.One));
        Assert.That(actual, Is.True);
    }
}