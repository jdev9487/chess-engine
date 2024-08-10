namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnBottomBorder : KingBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.E, Rank.One);
        Act();
    }
    
    [Test]
    [TestCase(File.D, Rank.One)]
    [TestCase(File.D, Rank.Two)]
    [TestCase(File.E, Rank.Two)]
    [TestCase(File.F, Rank.Two)]
    [TestCase(File.F, Rank.One)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldOnlyHave5Squares() => AssertHasLength(5);
}