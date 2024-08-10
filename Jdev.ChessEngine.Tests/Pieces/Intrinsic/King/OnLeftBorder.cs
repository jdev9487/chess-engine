namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnLeftBorder : KingBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.A, Rank.Four);
        Act();
    }
    
    [Test]
    [TestCase(File.B, Rank.Three)]
    [TestCase(File.B, Rank.Four)]
    [TestCase(File.B, Rank.Five)]
    [TestCase(File.A, Rank.Three)]
    [TestCase(File.A, Rank.Five)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldOnlyHave5Squares() => AssertHasLength(5);
}