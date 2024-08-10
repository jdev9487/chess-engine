namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnH8 : KingBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.H, Rank.Eight);
        Act();
    }
    
    [Test]
    [TestCase(File.H, Rank.Seven)]
    [TestCase(File.G, Rank.Seven)]
    [TestCase(File.G, Rank.Eight)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldOnlyHave3Squares() => AssertHasLength(3);
}