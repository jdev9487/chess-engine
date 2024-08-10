namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class NotOnBorder : KingBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.D, Rank.Four);
        Act();
    }
    
    [Test]
    [TestCase(File.C, Rank.Three)]
    [TestCase(File.C, Rank.Four)]
    [TestCase(File.C, Rank.Five)]
    [TestCase(File.D, Rank.Three)]
    [TestCase(File.D, Rank.Five)]
    [TestCase(File.E, Rank.Three)]
    [TestCase(File.E, Rank.Four)]
    [TestCase(File.E, Rank.Five)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldOnlyHave8Squares() => AssertHasLength(8);
}