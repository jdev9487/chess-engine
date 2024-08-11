namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Queen;

using Enums;
using Models;

[TestFixture]
public class OnRightBorder : QueenBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.H, Rank.Five);
        Act();
    }

    [Test]
    [TestCase(File.H, Rank.One)]
    [TestCase(File.H, Rank.Two)]
    [TestCase(File.H, Rank.Three)]
    [TestCase(File.H, Rank.Four)]
    [TestCase(File.H, Rank.Six)]
    [TestCase(File.H, Rank.Seven)]
    [TestCase(File.H, Rank.Eight)]
    [TestCase(File.A, Rank.Five)]
    [TestCase(File.B, Rank.Five)]
    [TestCase(File.C, Rank.Five)]
    [TestCase(File.D, Rank.Five)]
    [TestCase(File.E, Rank.Five)]
    [TestCase(File.F, Rank.Five)]
    [TestCase(File.G, Rank.Five)]
    [TestCase(File.E, Rank.Eight)]
    [TestCase(File.F, Rank.Seven)]
    [TestCase(File.G, Rank.Six)]
    [TestCase(File.G, Rank.Four)]
    [TestCase(File.F, Rank.Three)]
    [TestCase(File.E, Rank.Two)]
    [TestCase(File.D, Rank.One)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldContain21Squares() => AssertHasLength(21);
}