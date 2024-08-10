namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnTopBorder : KingBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.E, Rank.Eight);
        Act();
    }
    
    [Test]
    [TestCase(File.D, Rank.Eight)]
    [TestCase(File.D, Rank.Seven)]
    [TestCase(File.E, Rank.Seven)]
    [TestCase(File.F, Rank.Seven)]
    [TestCase(File.F, Rank.Eight)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldOnlyHave5Squares() => AssertHasLength(5);
}