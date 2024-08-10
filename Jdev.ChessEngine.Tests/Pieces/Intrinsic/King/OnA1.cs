namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnA1 : KingBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.A, Rank.One);
        Act();
    }
    
    [Test]
    [TestCase(File.A, Rank.Two)]
    [TestCase(File.B, Rank.Two)]
    [TestCase(File.B, Rank.One)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldOnlyHave3Squares() => AssertHasLength(3);
}