namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Queen;

using Enums;
using Models;

[TestFixture]
public class OnTopBorder : QueenBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.D, Rank.Eight);
        Act();
    }

    [Test]
    [TestCase(File.A, Rank.Eight)]
    [TestCase(File.B, Rank.Eight)]
    [TestCase(File.C, Rank.Eight)]
    [TestCase(File.E, Rank.Eight)]
    [TestCase(File.F, Rank.Eight)]
    [TestCase(File.G, Rank.Eight)]
    [TestCase(File.H, Rank.Eight)]
    [TestCase(File.D, Rank.Seven)]
    [TestCase(File.D, Rank.Six)]
    [TestCase(File.D, Rank.Five)]
    [TestCase(File.D, Rank.Four)]
    [TestCase(File.D, Rank.Three)]
    [TestCase(File.D, Rank.Two)]
    [TestCase(File.D, Rank.One)]
    [TestCase(File.A, Rank.Five)]
    [TestCase(File.B, Rank.Six)]
    [TestCase(File.C, Rank.Seven)]
    [TestCase(File.E, Rank.Seven)]
    [TestCase(File.F, Rank.Six)]
    [TestCase(File.G, Rank.Five)]
    [TestCase(File.H, Rank.Four)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldContain21Squares() => AssertHasLength(21);
}