namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnH1 : KingBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.H, Rank.One);
        Act();
    }
    
    [Test]
    [TestCase(File.H, Rank.Two)]
    [TestCase(File.G, Rank.Two)]
    [TestCase(File.G, Rank.One)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldOnlyHave3Squares() => AssertHasLength(3);
}