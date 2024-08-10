namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnA8 : KingBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.A, Rank.Eight);
        Act();
    }
    
    [Test]
    [TestCase(File.A, Rank.Seven)]
    [TestCase(File.B, Rank.Seven)]
    [TestCase(File.B, Rank.Eight)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldOnlyHave3Squares() => AssertHasLength(3);
}