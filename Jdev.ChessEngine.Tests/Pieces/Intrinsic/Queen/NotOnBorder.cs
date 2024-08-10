namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Queen;

using Enums;
using Models;

[TestFixture]
public class NotOnBorder : QueenBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.D, Rank.Four);
        Act();
    }

    [Test]
    [TestCase(File.E, Rank.Four)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);
}